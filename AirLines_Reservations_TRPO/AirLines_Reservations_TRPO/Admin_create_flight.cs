using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace AirLines_Reservations_TRPO
{
    public partial class Admin_create_flight : Form
    {
        private SqlConnection conn;
        private DataTable flights;
        public Admin_create_flight(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
        private void _Enter(TextBox textBox, string hint)
        {
            if (textBox.Text.Equals(hint))
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }
        private void _Leave(TextBox textBox, string hint)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text.ToString()))
            {
                textBox.Text = hint;
                textBox.ForeColor = Color.Gray;
            }
        }
        private void Addnewflight_Load(object sender, EventArgs e)
        {
            _Leave(flight_id, "Пример: 1234567");
            _Leave(punkt_naz, "Пример: tokyo");
            _Leave(punkt_otpr, "Пример: tokyo");
            _Leave(date, "Пример: ММ/ДД/ГГГГ");
            _Leave(date_time, "Пример: ЧЧ:ММ:СС");
            _Leave(fly_time, "Пример: ЧЧ:ММ:СС");
            _Leave(bis_count, "Пример: 12");
            _Leave(bis_cost, "Пример: 123");
            _Leave(eco_count, "Пример: 12");
            _Leave(eco_cost, "Пример: 123");
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Air_flight", conn);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            flights = dataSet.Tables[0];

        }
        private void flight_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
            else if (flight_id.Text.Length >= 6 && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
        }
        private void flight_id_Enter(object sender, EventArgs e)
        {
            _Enter(flight_id, "Пример: 1234567");
        }
        private void flight_id_Leave(object sender, EventArgs e)
        {
            _Leave(flight_id, "Пример: 1234567");
        }
        private void flight_id_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(flight_id.Text) || flight_id.Text.Contains("Пример"))
            {
                return;
            }
            DataRow[] rows = flights.Select("Id = " + Convert.ToInt32(flight_id.Text.ToString()));
            if (rows.Length > 0)
            {
                MessageBox.Show("Рейс с таким Id уже существует. Смените Id","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }


        private void punkt_naz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                if (!char.IsLetter(e.KeyChar) || char.ToLower(e.KeyChar) != e.KeyChar)
                {
                    e.Handled = true;
                }
            }
        }
        private void punkt_naz_Enter(object sender, EventArgs e)
        {
            _Enter(punkt_naz, "Пример: tokyo");
        }
        private void punkt_naz_Leave(object sender, EventArgs e)
        {
            _Leave(punkt_naz, "Пример: tokyo");
        }
        private void punkt_naz_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(punkt_naz.Text) || punkt_naz.Text.Contains("Пример"))
            {
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(punkt_naz.Text))
                {
                    punkt_naz.Text = char.ToUpper(punkt_naz.Text[0]) + punkt_naz.Text.Substring(1);
                }
            }
        }



        private void punkt_otpr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                if (!char.IsLetter(e.KeyChar) || char.ToLower(e.KeyChar) != e.KeyChar)
                {
                    e.Handled = true;
                }
            }  
        }
        private void punkt_otpr_Enter(object sender, EventArgs e)
        {
            _Enter(punkt_otpr, "Пример: tokyo");
        }
        private void punkt_otpr_Leave(object sender, EventArgs e)
        {
            _Leave(punkt_otpr, "Пример: tokyo");
        }
        private void punkt_otpr_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(punkt_otpr.Text) || punkt_otpr.Text.Contains("Пример"))
            {
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(punkt_otpr.Text))
                {
                    punkt_otpr.Text = char.ToUpper(punkt_otpr.Text[0]) + punkt_otpr.Text.Substring(1);
                }
            }
        }


        private void date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }
        private void date_Enter(object sender, EventArgs e)
        {
            _Enter(date, "Пример: ММ/ДД/ГГГГ");
        }
        private void date_Leave(object sender, EventArgs e)
        {
            _Leave(date, "Пример: ММ/ДД/ГГГГ");
        }
        private void date_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(date.Text) || date.Text.Contains("Пример"))
            {
                return;
            }
            string pattern = @"^(0[1-9]|1[0-2])\/(0[1-9]|[12][0-9]|3[01])\/(2023|2024)$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(date.Text))
            {
                MessageBox.Show("Неверный формат даты. Введите дату в формате ММ/ДД/ГГГГ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }



        private void date_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }
        private void date_time_Enter(object sender, EventArgs e)
        {
            _Enter(date_time, "Пример: ЧЧ:ММ:СС");
        }
        private void date_time_Leave(object sender, EventArgs e)
        {
            _Leave(date_time, "Пример: ЧЧ:ММ:СС");
        }
        private void date_time_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(date_time.Text)||date_time.Text.Contains("Пример"))
            {
                return;
            }
            string pattern = @"^(0[1-9]|1[0-9]|2[0-4]):([0-5][0-9]):([0-5][0-9])$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(date_time.Text)&&!string.IsNullOrEmpty(date_time.Text))
            {
                MessageBox.Show("Неверный формат времени. Введите время в формате ЧЧ:ММ:СС.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }


        private void fly_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }
        private void fly_time_Enter(object sender, EventArgs e)
        {
            _Enter(fly_time, "Пример: ЧЧ:ММ:СС");
        }
        private void fly_time_Leave(object sender, EventArgs e)
        {
            _Leave(fly_time, "Пример: ЧЧ:ММ:СС");
        }
        private void fly_time_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(fly_time.Text) || fly_time.Text.Contains("Пример"))
            {
                return;
            }
            string pattern = @"^(0[1-9]|1[0-9]|2[0-4]):([0-5][0-9]):([0-5][0-9])$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(fly_time.Text) && !string.IsNullOrEmpty(fly_time.Text))
            {
                MessageBox.Show("Неверный формат времени. Введите время в формате ЧЧ:ММ:СС.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }


        private void bis_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
            else if(bis_count.Text.Length>=2 && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled=true;
            }
        }
        private void bis_count_Enter(object sender, EventArgs e)
        {
            _Enter(bis_count, "Пример: 12");
        }
        private void bis_count_Leave(object sender, EventArgs e)
        {
            _Leave(bis_count, "Пример: 12");
        }



        private void bis_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
            else if (bis_cost.Text.Length >= 3 && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
        }
        private void bis_cost_Enter(object sender, EventArgs e)
        {
            _Enter(bis_cost, "Пример: 123");
        }
        private void bis_cost_Leave(object sender, EventArgs e)
        {
            _Leave(bis_cost, "Пример: 123");
        }



        private void eco_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
            else if (eco_count.Text.Length >= 2 && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
        }
        private void eco_count_Enter(object sender, EventArgs e)
        {
            _Enter(eco_count, "Пример: 12");
        }
        private void eco_count_Leave(object sender, EventArgs e)
        {
            _Leave(eco_count, "Пример: 12");
        }



        private void eco_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
            else if (eco_cost.Text.Length >= 3 && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
        }
        private void eco_cost_Enter(object sender, EventArgs e)
        {
            _Enter(eco_cost, "Пример: 123");
        }
        private void eco_cost_Leave(object sender, EventArgs e)
        {
            _Leave(eco_cost, "Пример: 123");
        }

        private void cancel_flight_Click(object sender, EventArgs e)
        {
            Admin_main_form admForm = new Admin_main_form(conn);
            this.Hide();
            admForm.ShowDialog();
            this.Close();
        }

        private void add_flight_Click(object sender, EventArgs e)
        {
            int all_count = 0, not_null_count = 0;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    all_count++;
                    TextBox textBox = (TextBox)control;
                    if (!string.IsNullOrEmpty(textBox.Text))
                    {
                        if (!textBox.Text.Contains("Пример"))
                        {
                            not_null_count++;
                        }
                    }
                    
                }
            }
            if (all_count == not_null_count)
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Air_flight (Id, Punkt_naz, Punkt_otpr, Date, Date_Time, Fly_time, Bis_seats_avg, Bis_cost, Bis_seats_lft, Eco_seats_avg, Eco_cost, Eco_seats_lft) VALUES (@Id, @Punkt_naz, @Punkt_otpr, @Date, @Date_Time, @Fly_time, @Bis_seats_avg, @Bis_cost, @Bis_seats_lft, @Eco_seats_avg, @Eco_cost, @Eco_seats_lft)", conn);
                    command.Parameters.AddWithValue("@Id", Convert.ToInt32(flight_id.Text));
                    command.Parameters.AddWithValue("@Punkt_naz", punkt_naz.Text.ToString());
                    command.Parameters.AddWithValue("@Punkt_otpr", punkt_otpr.Text.ToString());
                    command.Parameters.AddWithValue("@Date", date.Text.ToString());
                    command.Parameters.AddWithValue("@Date_Time", date_time.Text.ToString());
                    command.Parameters.AddWithValue("@Fly_time", fly_time.Text.ToString());
                    command.Parameters.AddWithValue("@Bis_seats_avg", Convert.ToInt32(bis_count.Text));
                    command.Parameters.AddWithValue("@Bis_cost", Convert.ToInt32(bis_cost.Text));
                    command.Parameters.AddWithValue("@Bis_seats_lft", Convert.ToInt32(bis_count.Text));
                    command.Parameters.AddWithValue("@Eco_seats_avg", Convert.ToInt32(eco_count.Text));
                    command.Parameters.AddWithValue("@Eco_cost", Convert.ToInt32(eco_cost.Text));
                    command.Parameters.AddWithValue("@Eco_seats_lft", Convert.ToInt32(eco_count.Text));
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
                MessageBox.Show("Данные успешно добавлены в БД");
                Admin_main_form admForm = new Admin_main_form(conn);
                this.Hide();
                admForm.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Вы не заполнили некоторое(ые) поля. Заполните их, а затем нажимаете добавить");
        }
    }
}
