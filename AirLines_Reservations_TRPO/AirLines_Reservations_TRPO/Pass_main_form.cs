using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLines_Reservations_TRPO
{
    public partial class Pass_main_form : Form
    {
        private SqlConnection conn;
        private DataRow pass_data;
        public Pass_main_form(SqlConnection conn, DataRow pass_data)
        {
            InitializeComponent();
            this.conn = conn;
            this.pass_data = pass_data;
        }

        public Pass_reserved_flight Pass_reserved_flight
        {
            get => default;
            set
            {
            }
        }

        public Pass_flight_information Pass_flight_information
        {
            get => default;
            set
            {
            }
        }

        void Refresh_grid()
        {
            int person_id = Convert.ToInt32(pass_data["Id"].ToString());
            SqlDataAdapter person_adapter=new SqlDataAdapter($"SELECT * FROM Passangers WHERE Id={person_id}", conn);
            DataSet ds=new DataSet();
            person_adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            pass_data = dr;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Punkt_naz AS N'Пункт назначения', Punkt_otpr AS N'Пункт отправления', Date AS N'День отправления', Date_Time AS N'Время отправления', Fly_time AS N'Время полета', Bis_seats_lft AS N'Бизнесс места', Bis_cost AS N'Цена бизнеса', Eco_seats_lft AS N'Эконом места', Eco_cost AS N'Цена эконома' FROM Air_flight", conn);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            pass_flights.DataSource = dataSet.Tables[0];
            pass_flights.Refresh();
            bool abc = pass_data["Plane_Id"] != DBNull.Value;
            if (abc)
            {
                int id = Convert.ToInt32(pass_data["Id"].ToString());
                int plane_id = Convert.ToInt32(pass_data["Plane_Id"].ToString());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT Air_flight.Punkt_naz AS N'Пункт назначения', Air_flight.Punkt_otpr AS N'Пункт отправления', Air_flight.Date AS N'День отправления', Air_flight.Date_Time AS N'Время отправления', Air_flight.Fly_time AS N'Время полета', Passangers.Biz_Count AS N'Забронированные бизнесс места', Air_flight.Bis_cost AS N'Цена бизнеса', Passangers.Eko_Count AS N'Забронированные эконом места', Air_flight.Eco_cost AS N'Цена эконома' FROM Air_flight, Passangers WHERE Air_flight.Id={plane_id} AND Passangers.Id={id}", conn);
                DataSet dataSet1 = new DataSet();
                sqlDataAdapter.Fill(dataSet1);
                if (dataSet1.Tables.Count > 0)
                {
                    my_reserve_grid.DataSource = dataSet1.Tables[0];
                    my_reserve_grid.Refresh();
                }
            }
            else if (my_reserve_grid != null && my_reserve_grid.Rows.Count > 0)
            {
                my_reserve_grid.DataSource = null;
                my_reserve_grid.Rows.Clear();
                my_reserve_grid.Columns.Clear();
                my_reserve_grid.Refresh();
            }
        }

        private void PassForm_Load(object sender, EventArgs e)
        {
            Refresh_grid();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Pass_login_form loginForm = new Pass_login_form();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void pass_flights_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = pass_flights.Rows[e.RowIndex];
                string date = row.Cells[2].Value.ToString().Replace(".","/");
                string[] parts= date.Split(' ');
                date= parts[0];
                string time = row.Cells[3].Value.ToString().Replace(".",":");
                SqlDataAdapter choosen_flight = new SqlDataAdapter($@"SELECT Id, Punkt_naz, Punkt_otpr, Date, Date_Time, Fly_time, Bis_seats_avg, Bis_cost, Bis_seats_lft, Eco_seats_avg, Eco_cost, Eco_seats_lft 
                FROM Air_flight 
                WHERE Punkt_naz=N'{row.Cells[0].Value.ToString()}' AND Punkt_otpr=N'{row.Cells[1].Value.ToString()}' AND Date=@date AND Date_Time=@time AND Fly_time=@time1 AND Bis_cost=@cost1 AND Eco_cost=@cost2", conn); 

                choosen_flight.SelectCommand.Parameters.AddWithValue("@date", row.Cells[2].Value);
                choosen_flight.SelectCommand.Parameters.AddWithValue("@time", row.Cells[3].Value.ToString());
                choosen_flight.SelectCommand.Parameters.AddWithValue("@time1", row.Cells[4].Value.ToString());
                choosen_flight.SelectCommand.Parameters.AddWithValue("@cost1", row.Cells[6].Value);
                choosen_flight.SelectCommand.Parameters.AddWithValue("@cost2", row.Cells[8].Value);
                DataSet cf_dataSet=new DataSet();
                choosen_flight.Fill(cf_dataSet);

                if (cf_dataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow dataRow = cf_dataSet.Tables[0].Rows[0];
                    object[] values = new object[dataRow.ItemArray.Length];
                    for (int i = 0; i < dataRow.ItemArray.Length; i++)
                    {
                        values[i] = dataRow[i];
                    }
                    DataGridViewRow choosen_flight_row = new DataGridViewRow();
                    for (int i = 0; i < values.Length; i++)
                    {
                        DataGridViewCell cell = new DataGridViewTextBoxCell();
                        cell.Value = values[i];
                        choosen_flight_row.Cells.Add(cell);
                    }
                    Pass_flight_information flight = new Pass_flight_information(choosen_flight_row, pass_data, conn);
                    if (flight.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_grid();
                    }
                    else
                    {
                        return;
                    }
                    
                }
                else MessageBox.Show("Ошибка в системе. Обратитесь к администратору или выполните запрос позже");
            }
        }

        private void my_reserve_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int flight_id = Convert.ToInt32(pass_data["Plane_Id"].ToString());
                SqlDataAdapter adapter= new SqlDataAdapter($"SELECT * FROM Air_flight WHERE Id={flight_id}",conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow this_flight = dataSet.Tables[0].Rows[0];
                    Pass_reserved_flight newForm= new Pass_reserved_flight(this_flight, pass_data, conn);
                    if (newForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_grid();
                    }
                    else return;
                }
            }
        }

    }
    
}

