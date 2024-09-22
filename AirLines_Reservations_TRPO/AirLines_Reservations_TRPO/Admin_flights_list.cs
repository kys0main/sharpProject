using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLines_Reservations_TRPO
{
    public partial class Admin_flights_list : Form
    {
        private SqlConnection conn;
        public Admin_flights_list(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        public Admin_edit_flight Admin_edit_flight
        {
            get => default;
            set
            {
            }
        }

        void Refresh_grid()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Punkt_naz AS N'Пункт назначения', Punkt_otpr AS N'Пункт отправления', Date AS N'День отправления', Date_Time AS N'Время отправления', Fly_time AS N'Время полета', Bis_seats_lft AS N'Бизнесс места', Bis_cost AS N'Цена бизнеса', Eco_seats_lft AS N'Эконом места', Eco_cost AS N'Цена эконома' FROM Air_flight", conn);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            All_flights.DataSource = dataSet.Tables[0];
            All_flights.Refresh();
        }
        private void Edit_flights_Load(object sender, EventArgs e)
        {
            Refresh_grid();
        }
        private void All_flights_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = All_flights.Rows[e.RowIndex];
                string date = row.Cells[2].Value.ToString().Replace(".", "/");
                string[] parts = date.Split(' ');
                date = parts[0];
                string time = row.Cells[3].Value.ToString().Replace(".", ":");
                SqlDataAdapter choosen_flight = new SqlDataAdapter($@"SELECT Id, Punkt_naz, Punkt_otpr, Date, Date_Time, Fly_time, Bis_seats_avg, Bis_cost, Bis_seats_lft, Eco_seats_avg, Eco_cost, Eco_seats_lft 
                FROM Air_flight 
                WHERE Punkt_naz=N'{row.Cells[0].Value.ToString()}' AND Punkt_otpr=N'{row.Cells[1].Value.ToString()}' AND Date=@date AND Date_Time=@time AND Fly_time=@time1 AND Bis_cost=@cost1 AND Eco_cost=@cost2", conn);

                choosen_flight.SelectCommand.Parameters.AddWithValue("@date", row.Cells[2].Value);
                choosen_flight.SelectCommand.Parameters.AddWithValue("@time", row.Cells[3].Value.ToString());
                choosen_flight.SelectCommand.Parameters.AddWithValue("@time1", row.Cells[4].Value.ToString());
                choosen_flight.SelectCommand.Parameters.AddWithValue("@cost1", row.Cells[6].Value);
                choosen_flight.SelectCommand.Parameters.AddWithValue("@cost2", row.Cells[8].Value);
                DataSet cf_dataSet = new DataSet();
                choosen_flight.Fill(cf_dataSet);

                if (cf_dataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow dataRow = cf_dataSet.Tables[0].Rows[0];
                    Admin_edit_flight flight_info = new Admin_edit_flight(conn, dataRow);
                    if (flight_info.ShowDialog() == DialogResult.OK)
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

        private void Back_Click(object sender, EventArgs e)
        {
            Admin_main_form admForm=new Admin_main_form(conn);
            this.Hide();
            admForm.ShowDialog();
            this.Close();
        }

    }
}
