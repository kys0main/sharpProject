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
using Microsoft.VisualBasic;

namespace AirLines_Reservations_TRPO
{
    public partial class Admin_edit_flight : Form
    {
        private SqlConnection conn;
        private DataRow dataRow;
        private string dateText, bis_lft, eco_lft, reserved_bis, reserved_eco;
        private int sensor=0;
        public Admin_edit_flight(SqlConnection conn, DataRow dataRow)
        {
            InitializeComponent();
            this.conn = conn;
            this.dataRow = dataRow;
        } 
        private void Adm_flight_info_Load(object sender, EventArgs e)
        {
            flight_id.Text = dataRow["Id"].ToString();
            punkt_naz.Text = dataRow["Punkt_naz"].ToString();
            punkt_otpr.Text = dataRow["Punkt_otpr"].ToString();
            int index = dataRow["Date"].ToString().IndexOf(' ');
            if (index >= 0)
            {
                date.Text = dataRow["Date"].ToString().Substring(0, index);
                date.Text = date.Text.Replace(".", "/");
                string[] dateParts = date.Text.Split('/');
                date.Text = $"{dateParts[1]}/{dateParts[0]}/{dateParts[2]}";
                dateText = date.Text;
            }
            //date.Text = dataRow["Date"].ToString();
            date_time.Text = dataRow["Date_Time"].ToString();
            fly_time.Text = dataRow["Fly_time"].ToString();
            avg_bis_count.Text = dataRow["Bis_seats_avg"].ToString();
            bis_cost.Text = dataRow["Bis_cost"].ToString();
            bis_lft = dataRow["Bis_seats_lft"].ToString();
            avg_eco_count.Text = dataRow["Eco_seats_avg"].ToString();
            eco_cost.Text = dataRow["Eco_cost"].ToString();
            eco_lft = dataRow["Eco_seats_lft"].ToString();
            reserved_bis = Convert.ToString(Convert.ToInt32(avg_bis_count.Text) - Convert.ToInt32(bis_lft));
            reserved_eco = Convert.ToString(Convert.ToInt32(avg_eco_count.Text) - Convert.ToInt32(eco_lft));
        }

        private void flight_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
            else if (flight_id.Text.Length >= 7 && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
        }
        private void flight_id_Validating(object sender, CancelEventArgs e)
        {
            sensor = 0;
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Air_flight WHERE Id=@id", conn);
            adapter.SelectCommand.Parameters.AddWithValue("id", Convert.ToInt32(flight_id.Text));
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Данный Id рейса уже используется. Введите другой Id");
                e.Cancel = true;
            }
            else
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Passangers WHERE Plane_Id=@old_id", conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@old_id", Convert.ToInt32(dataRow["Id"].ToString()));
                DataSet pass_dataSet=new DataSet();
                dataAdapter.Fill(pass_dataSet);
                DataTable pass_dataTable = new DataTable();
                pass_dataTable = pass_dataSet.Tables[0];
                if (pass_dataTable.Rows.Count > 0)
                {
                    sensor = 1;
                }
                else
                {
                    sensor = -5;
                }
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
        private void punkt_naz_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(punkt_naz.Text))
            {
                punkt_naz.Text= dataRow["Punkt_naz"].ToString();
            }
            else
            {
                punkt_naz.Text = char.ToUpper(punkt_naz.Text[0]) + punkt_naz.Text.Substring(1);
            }
        }


        private void punkt_otpr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                if (!char.IsLetter(e.KeyChar) || char.ToLower(e.KeyChar) != e.KeyChar)
                {
                    e.Handled = true;
                }
            }
        }
        private void punkt_otpr_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(punkt_otpr.Text))
            {
                punkt_otpr.Text = dataRow["Punkt_otpr"].ToString();
            }
            else
            {
                punkt_otpr.Text = char.ToUpper(punkt_otpr.Text[0]) + punkt_otpr.Text.Substring(1);
            }
        }


        private void date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F' && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }
        private void date_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(date.Text))
            {
                date.Text=dateText;
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
        private void date_time_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(date_time.Text))
            {
                date_time.Text = dataRow["Date_Time"].ToString();
                return;
            }
            string pattern = @"^(0[1-9]|1[0-9]|2[0-4]):([0-5][0-9]):([0-5][0-9])$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(date_time.Text) && !string.IsNullOrEmpty(date_time.Text))
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
        private void fly_time_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(fly_time.Text))
            {
                fly_time.Text = dataRow["Fly_time"].ToString();
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


        private void avg_bis_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
            else if (avg_bis_count.Text.Length >= 2 && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
        }
        private void avg_bis_count_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(dataRow["Bis_seats_lft"].ToString()) == 0 && Convert.ToInt32(avg_bis_count.Text) - Convert.ToInt32(dataRow["Bis_seats_avg"].ToString())<0)
            {
                MessageBox.Show($"Вы не можете уменьшить число мест. Введите число большее либо равное {dataRow["Bis_seats_avg"].ToString()}");
                e.Cancel = true;
            }
            if (string.IsNullOrEmpty(avg_bis_count.Text))
            {
                avg_bis_count.Text = dataRow["Bis_seats_avg"].ToString();
                return;
            }
            if (Convert.ToInt32(avg_bis_count.Text) < Convert.ToInt32(reserved_bis))
            {
                MessageBox.Show($"Вы ввели некорректное число. Введите число большее либо равное {reserved_bis}");
                e.Cancel = true;
            }
            else
            {
                int delta = Convert.ToInt32(avg_bis_count.Text) - Convert.ToInt32(dataRow["Bis_seats_avg"].ToString());
                bis_lft = Convert.ToString(Convert.ToInt32(dataRow["Bis_seats_lft"].ToString()) + delta);
            }
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
        private void bis_cost_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(bis_cost.Text))
            {
                bis_cost.Text = dataRow["Bis_cost"].ToString();
                return;
            }
        }


        private void avg_eco_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
            else if (avg_eco_count.Text.Length >= 2 && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
        }
        private void avg_eco_count_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(dataRow["Eco_seats_lft"].ToString()) == 0 && Convert.ToInt32(avg_eco_count.Text) - Convert.ToInt32(dataRow["Eco_seats_avg"].ToString()) < 0)
            {
                MessageBox.Show($"Вы не можете уменьшить число мест. Введите число большее либо равное {dataRow["Eco_seats_avg"].ToString()}");
                e.Cancel = true;
            }
            if (string.IsNullOrEmpty(avg_eco_count.Text))
            {
                avg_eco_count.Text = dataRow["Eco_seats_avg"].ToString();
                return;
            }
            if (Convert.ToInt32(avg_eco_count.Text) < Convert.ToInt32(reserved_eco))
            {
                MessageBox.Show($"Вы ввели некорректное число. Введите число большее либо равное {reserved_eco}");
                e.Cancel = true;
            }
            else
            {
                int delta = Convert.ToInt32(avg_eco_count.Text) - Convert.ToInt32(dataRow["Eco_seats_avg"].ToString());
                eco_lft = Convert.ToString(Convert.ToInt32(dataRow["Eco_seats_lft"].ToString()) + delta);
            }
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

        private void eco_cost_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(eco_cost.Text))
            {
                eco_cost.Text = dataRow["Eco_cost"].ToString();
                return;
            }
        }

        private void accept_button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Air_flight SET Id=@new_id, Punkt_naz=@Punkt_naz, Punkt_otpr=@Punkt_otpr, Date=@Date, Date_Time=@Date_Time, Fly_time=@Fly_time, Bis_seats_avg=@Bis_seats_avg, Bis_cost=@Bis_cost, Bis_seats_lft=@Bis_seats_lft, Eco_seats_avg=@Eco_seats_avg, Eco_cost=@Eco_cost, Eco_seats_lft=@Eco_seats_lft WHERE Id=@Id ", conn);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(dataRow["Id"].ToString()));
                command.Parameters.AddWithValue("@new_id", Convert.ToInt32(flight_id.Text.ToString()));
                command.Parameters.AddWithValue("@Punkt_naz", punkt_naz.Text.ToString());
                command.Parameters.AddWithValue("@Punkt_otpr", punkt_otpr.Text.ToString());
                command.Parameters.AddWithValue("@Date", date.Text.ToString());
                command.Parameters.AddWithValue("@Date_Time", date_time.Text.ToString());
                command.Parameters.AddWithValue("@Fly_time", fly_time.Text.ToString());
                command.Parameters.AddWithValue("@Bis_seats_avg", Convert.ToInt32(avg_bis_count.Text));
                command.Parameters.AddWithValue("@Bis_cost", Convert.ToInt32(bis_cost.Text));
                command.Parameters.AddWithValue("@Bis_seats_lft", Convert.ToInt32(bis_lft));
                command.Parameters.AddWithValue("@Eco_seats_avg", Convert.ToInt32(avg_eco_count.Text));
                command.Parameters.AddWithValue("@Eco_cost", Convert.ToInt32(eco_cost.Text));
                command.Parameters.AddWithValue("@Eco_seats_lft", Convert.ToInt32(eco_lft));
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
            MessageBox.Show("Данные по рейсу успешно добавлены в БД");
            if (sensor > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Passangers SET Plane_Id=@new_id WHERE Plane_Id=@id", conn);
                cmd.Parameters.AddWithValue("@new_id", Convert.ToInt32(flight_id.Text));
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataRow["Id"].ToString()));
                int count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    MessageBox.Show("CRITICAL ERROR: Passangers");
                    return;
                }
                MessageBox.Show("Изменение Id рейса и у пассажиров успешно");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void delete_flight_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите продолжить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlCommand command = null;
                SqlDataAdapter pass_adapter = new SqlDataAdapter("SELECT * FROM Passangers", conn);
                DataTable passangersBackup = new DataTable();
                pass_adapter.Fill(passangersBackup);

                SqlDataAdapter flight_adapter = new SqlDataAdapter("SELECT * FROM Air_flight", conn);
                DataTable flightsBackup = new DataTable();
                flight_adapter.Fill(flightsBackup);


                try
                {
                    string selectFlightQuery = "SELECT * FROM Air_flight WHERE Id = @FlightId";
                    command = new SqlCommand(selectFlightQuery, conn);
                    command.Parameters.AddWithValue("@FlightId", Convert.ToInt32(dataRow["Id"].ToString()));
                    var reader = command.ExecuteReader();
                    int ecoSeatsLeft, bizSeatsLeft;

                    if (reader.Read())
                    {
                        ecoSeatsLeft = Convert.ToInt32(reader["Eco_seats_lft"]);
                        bizSeatsLeft = Convert.ToInt32(reader["Bis_seats_lft"]);
                    }
                    else
                    {
                        MessageBox.Show("Рейс не найден");
                        return;
                    }
                    reader.Close();
                    string selectPassengersQuery = "SELECT * FROM Passangers WHERE Plane_Id = @FlightId";
                    command = new SqlCommand(selectPassengersQuery, conn);
                    command.Parameters.AddWithValue("@FlightId", Convert.ToInt32(dataRow["Id"].ToString()));
                    var passengers = command.ExecuteReader();

                    if (!passengers.HasRows)
                    {
                        passengers.Close();
                        command = new SqlCommand("DELETE FROM Air_flight WHERE Id = @FlightId", conn);
                        command.Parameters.AddWithValue("@FlightId", Convert.ToInt32(dataRow["Id"].ToString()));
                        command.ExecuteNonQuery();
                        MessageBox.Show("Рейс успешно удален.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                    while (passengers.Read())
                    {
                        int passengerId = (int)passengers["Id"];
                        int ekoCount = (int)passengers["Eko_Count"];
                        int bizCount = (int)passengers["Biz_Count"];
                        string selectAvailableFlightsQuery = "SELECT * FROM Air_flight WHERE Id <> @FlightId " +
                                    "AND @EkoCount <= Eco_seats_lft AND @BizCount <= Bis_seats_lft " +
                                    "ORDER BY ABS(DATEDIFF(DAY, Date, GETDATE())) ASC";
                        command = new SqlCommand(selectAvailableFlightsQuery, conn);
                        command.Parameters.AddWithValue("@FlightId", Convert.ToInt32(dataRow["Id"].ToString()));
                        command.Parameters.AddWithValue("@EkoCount", ekoCount);
                        command.Parameters.AddWithValue("@BizCount", bizCount);
                        passengers.Close();
                        var availableFlights = command.ExecuteReader();
                        if (!availableFlights.HasRows)
                        {
                            availableFlights.Close();
                            SqlCommand cmd = new SqlCommand("TRUNCATE TABLE Passangers", conn);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            cmd.CommandText = "TRUNCATE TABLE Air_flight";
                            cmd.ExecuteNonQuery();
                            SqlBulkCopy CopyPass = new SqlBulkCopy(conn);
                            CopyPass.DestinationTableName = "Passangers";
                            CopyPass.WriteToServer(passangersBackup);
                            SqlBulkCopy CopyFlight = new SqlBulkCopy(conn);
                            CopyPass.DestinationTableName = "Air_flight";
                            CopyPass.WriteToServer(flightsBackup);
                            MessageBox.Show("Невозможно перераспределить пассажиров на другие рейсы. Обратитесь к руководству за дальнейшими указаниями");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        availableFlights.Read();
                        int selectedFlightId = (int)availableFlights["Id"];
                        int selectedFlightEcoSeatsLeft = (int)availableFlights["Eco_seats_lft"];
                        int selectedFlightBizSeatsLeft = (int)availableFlights["Bis_seats_lft"];
                        availableFlights.Close();
                        string updatePassengerQuery = "UPDATE Passangers SET Plane_Id = @SelectedFlightId WHERE Id = @PassengerId";
                        command = new SqlCommand(updatePassengerQuery, conn);
                        command.Parameters.AddWithValue("@SelectedFlightId", selectedFlightId);
                        command.Parameters.AddWithValue("@PassengerId", passengerId);
                        command.ExecuteNonQuery();
                        string updateSelectedFlightQuery = "UPDATE Air_flight SET Eco_seats_lft = @SelectedFlightEcoSeatsLeft, " +
                                                           "Bis_seats_lft = @SelectedFlightBizSeatsLeft WHERE Id = @SelectedFlightId";
                        command = new SqlCommand(updateSelectedFlightQuery, conn);
                        command.Parameters.AddWithValue("@SelectedFlightEcoSeatsLeft", selectedFlightEcoSeatsLeft - ekoCount);
                        command.Parameters.AddWithValue("@SelectedFlightBizSeatsLeft", selectedFlightBizSeatsLeft - bizCount);
                        command.Parameters.AddWithValue("@SelectedFlightId", selectedFlightId);
                        command.ExecuteNonQuery();
                        string selectPassengersQuery1 = "SELECT * FROM Passangers WHERE Plane_Id = @FlightId";
                        command = new SqlCommand(selectPassengersQuery1, conn);
                        command.Parameters.AddWithValue("@FlightId", Convert.ToInt32(dataRow["Id"].ToString()));
                        passengers = command.ExecuteReader();
                    }
                    passengers.Close();
                    string deleteFlightQuery = "DELETE FROM Air_flight WHERE Id = @FlightId";
                    command = new SqlCommand(deleteFlightQuery, conn);
                    command.Parameters.AddWithValue("@FlightId", Convert.ToInt32(dataRow["Id"].ToString()));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Рейс успешно удален, пассажиры перераспределены.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
