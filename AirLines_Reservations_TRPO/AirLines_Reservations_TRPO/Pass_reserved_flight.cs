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
    public partial class Pass_reserved_flight : Form
    {
        private DataRow this_flight, pass_data;
        private SqlConnection conn;
        public Pass_reserved_flight(DataRow this_flight, DataRow pass_data, SqlConnection conn)
        {
            InitializeComponent();
            this.this_flight = this_flight;
            this.pass_data = pass_data; 
            this.conn = conn;
        }
        private void Reserved_flight_Load(object sender, EventArgs e)
        {
            Punkt_otpr.Text = this_flight["Punkt_otpr"].ToString();
            Punkt_naz.Text = this_flight["Punkt_naz"].ToString();
            Fly_time_flight.Text = this_flight["Fly_time"].ToString();
            Date_flight.Text = this_flight["Date"].ToString();
            Date_time_flight.Text = this_flight["Date_time"].ToString();
            Bis_seats_left.Text = this_flight["Bis_seats_lft"].ToString();
            Eco_seats_left.Text = this_flight["Eco_seats_lft"].ToString();
            Bis_cost.Text = this_flight["Bis_cost"].ToString();
            Eco_cost.Text = this_flight["Eco_cost"].ToString();
            Bis_choosen.Text = pass_data["Biz_Count"].ToString();
            Eco_choosen.Text = pass_data["Eko_Count"].ToString();
        }
        private void Bis_minus_Click(object sender, EventArgs e)
        {
            int places = Convert.ToInt32(Bis_choosen.Text);
            if (places > 0)
            {
                places--;
            }
            else places = 0;
            Bis_choosen.Text = places.ToString();
        }

        private void Bis_plus_Click(object sender, EventArgs e)
        {
            int places = Convert.ToInt32(this_flight["Bis_seats_lft"].ToString());
            int start_places = Convert.ToInt32(pass_data["Biz_Count"].ToString());
            int ch_places = Convert.ToInt32(Bis_choosen.Text);
            if (ch_places < places + start_places)
            {
                ch_places++;
            }
            else ch_places = places + start_places;
            Bis_choosen.Text = ch_places.ToString();
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
            int places = Convert.ToInt32(this_flight["Eco_seats_lft"].ToString());
            int start_places = Convert.ToInt32(pass_data["Eko_Count"].ToString());
            int ch_places = Convert.ToInt32(Eco_choosen.Text);
            if (ch_places < places + start_places)
            {
                ch_places++;
            }
            else ch_places = places + start_places;
            Eco_choosen.Text = ch_places.ToString();

        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Done_reserve_Click(object sender, EventArgs e)
        {
            int eco_seats = Convert.ToInt32(Eco_choosen.Text), bis_seats = Convert.ToInt32(Bis_choosen.Text);
            int person_id = Convert.ToInt32(pass_data["Id"].ToString()), fly_id = Convert.ToInt32(this_flight["Id"].ToString());
            int first_bis = Convert.ToInt32(pass_data["Biz_Count"]), left_bis= Convert.ToInt32(this_flight["Bis_seats_lft"]);
            int first_eco = Convert.ToInt32(pass_data["Eko_Count"]), left_eco = Convert.ToInt32(this_flight["Eco_seats_lft"]); 
            
            if (eco_seats == 0 && bis_seats == 0)
            {
                SqlCommand cmd = new SqlCommand($@"UPDATE Passangers SET Plane_Id=@planeid, Eko_Count=@ekocount, Biz_Count=@bizcount WHERE Id={person_id}", conn);
                cmd.Parameters.AddWithValue("@planeid", DBNull.Value);
                cmd.Parameters.AddWithValue("@ekocount", DBNull.Value);
                cmd.Parameters.AddWithValue("@bizcount", DBNull.Value);
                int count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    MessageBox.Show("CRITICAL ERROR: Passangers");
                    return;
                }
                cmd.CommandText = string.Empty;
                cmd.Parameters.Clear();
                cmd.CommandText = $"UPDATE Air_flight SET Bis_seats_lft={left_bis + first_bis}, Eco_seats_lft={left_eco + first_eco} WHERE Id={fly_id}";
                count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    MessageBox.Show("CRITICAL ERROR: Air_flight");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Passangers SET Plane_Id={fly_id}, Eko_Count={eco_seats}, Biz_Count={bis_seats} WHERE Id={person_id}", conn);
                int count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    MessageBox.Show("CRITICAL ERROR: Passangers");
                    return;
                }
                cmd.CommandText = string.Empty;
                cmd.Parameters.Clear();
                cmd.CommandText = $"UPDATE Air_flight SET Bis_seats_lft+={first_bis-bis_seats}, Eco_seats_lft+={first_eco-eco_seats} WHERE Id={fly_id}";
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

        private void Cancel_rsrv_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите продолжить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int first_bis = Convert.ToInt32(pass_data["Biz_Count"]);
                int first_eco = Convert.ToInt32(pass_data["Eko_Count"]);
                int person_id = Convert.ToInt32(pass_data["Id"].ToString()), fly_id = Convert.ToInt32(this_flight["Id"].ToString());
                SqlCommand cmd = new SqlCommand($@"UPDATE Passangers SET Plane_Id=@planeid, Eko_Count=@ekocount, Biz_Count=@bizcount WHERE Id={person_id}", conn);
                cmd.Parameters.AddWithValue("@planeid", DBNull.Value);
                cmd.Parameters.AddWithValue("@ekocount", DBNull.Value);
                cmd.Parameters.AddWithValue("@bizcount", DBNull.Value);
                int count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    MessageBox.Show("CRITICAL ERROR: Passangers");
                    return;
                }
                cmd.CommandText = string.Empty;
                cmd.Parameters.Clear();
                cmd.CommandText = $"UPDATE Air_flight SET Bis_seats_lft+={first_bis}, Eco_seats_lft+={first_eco} WHERE Id={fly_id}";
                count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    MessageBox.Show("CRITICAL ERROR: Air_flight");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                return;
            }
            
        }
    }
}
