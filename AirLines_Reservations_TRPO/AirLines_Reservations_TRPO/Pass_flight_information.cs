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
    public partial class Pass_flight_information : Form
    {
        private DataGridViewRow flight_data;
        private DataRow pass_data;
        private SqlConnection conn;
        public Pass_flight_information(DataGridViewRow flight_data, DataRow pass_data, SqlConnection conn)
        {
            InitializeComponent();
            this.flight_data = flight_data;
            this.pass_data = pass_data;
            this.conn = conn;
        }

        private void Flight_information_Load(object sender, EventArgs e)
        {
            string date_flight= flight_data.Cells[3].Value.ToString(); 
            string[] arr=date_flight.Split(' ');
            date_flight = arr[0];
            Punkt_otpr.Text = flight_data.Cells[2].Value.ToString();
            Punkt_naz.Text= flight_data.Cells[1].Value.ToString();
            Date_flight.Text = date_flight;
            Date_time_flight.Text = flight_data.Cells[4].Value.ToString();
            Fly_time_flight.Text = flight_data.Cells[5].Value.ToString();
            Bis_seats_left.Text = flight_data.Cells[8].Value.ToString();
            Bis_cost.Text = flight_data.Cells[7].Value.ToString()+"$";
            Eco_seats_left.Text = flight_data.Cells[11].Value.ToString();
            Eco_cost.Text = flight_data.Cells[10].Value.ToString()+"$";

        }

        private void Cancel_reserve_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bis_minus_Click(object sender, EventArgs e)
        {
            int places=Convert.ToInt32(Bis_choosen.Text);
            if (places > 0)
            {
                places--;
            }
            else  places = 0; 
            Bis_choosen.Text=places.ToString();
        }

        private void Bis_plus_Click(object sender, EventArgs e)
        {
            int places = Convert.ToInt32(flight_data.Cells[8].Value.ToString());
            if (places == 0)
            {
                MessageBox.Show("Мест больше нет. Выберите другой тип мест или другой рейс");
            }
            else
            {
                int ch_places = Convert.ToInt32(Bis_choosen.Text);
                if (ch_places < places)
                {
                    ch_places++;
                }
                else ch_places = places;
                Bis_choosen.Text = ch_places.ToString();
            }
        }
        private void Eco_minus_Click(object sender, EventArgs e)
        {
            int places = Convert.ToInt32(Eco_choosen.Text);
            if (places > 0)
            {
                places--;
            }
            else places = 0;
            Eco_choosen.Text = places.ToString();
        }
        private void Eco_plus_Click(object sender, EventArgs e)
        {
            int places = Convert.ToInt32(flight_data.Cells[11].Value.ToString());
            if (places == 0)
            {
                MessageBox.Show("Мест больше нет. Выберите другой тип мест или другой рейс");
            }
            else
            {
                int ch_places = Convert.ToInt32(Eco_choosen.Text);
                if (ch_places < places)
                {
                    ch_places++;
                }
                else ch_places = places;
                Eco_choosen.Text = ch_places.ToString();
            } 
        }

        private void Done_reserve_Click(object sender, EventArgs e)
        {
            int eco_places= Convert.ToInt32(flight_data.Cells[11].Value.ToString());
            int bis_places= Convert.ToInt32(flight_data.Cells[8].Value.ToString());
            int eco_choosen = Convert.ToInt32(Eco_choosen.Text);
            int bis_choosen = Convert.ToInt32(Bis_choosen.Text);
            if (pass_data["Plane_Id"]!=DBNull.Value)
            {
                MessageBox.Show("Вы уже забронировали рейс. Отмените заброниранный рейс, если хотите забронировать новый");
                return;
            }
            if (bis_places == 0 && eco_places == 0)
            {
                MessageBox.Show("На данный рейс нет мест. Выберите другой рейс");
            }
            else if (eco_choosen == 0 && bis_choosen == 0)
            {
                MessageBox.Show("Места не выбраны. Выберите места и завершите бронирование");
            }
            else
            {
                int person_id = Convert.ToInt32(pass_data["Id"].ToString());
                int fly_id = Convert.ToInt32(flight_data.Cells[0].Value.ToString());
                SqlCommand cmd = new SqlCommand($"UPDATE Passangers SET Plane_Id={fly_id}, Eko_Count={eco_choosen}, Biz_Count={bis_choosen} WHERE Id={person_id}", conn);
                int count = cmd.ExecuteNonQuery();
                if(count == 0)
                {
                    MessageBox.Show("CRITICAL ERROR: Passangers");
                    return;
                }
                cmd.CommandText = string.Empty;
                cmd.Parameters.Clear();
                cmd.CommandText = $"UPDATE Air_flight SET Bis_seats_lft={bis_places-bis_choosen}, Eco_seats_lft={eco_places-eco_choosen} WHERE Id={fly_id}";
                count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    MessageBox.Show("CRITICAL ERROR: Air_flight");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
