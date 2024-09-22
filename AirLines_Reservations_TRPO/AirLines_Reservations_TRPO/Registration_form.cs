using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLines_Reservations_TRPO
{
    public partial class Registration_form : Form
    {
        private SqlConnection conn;
        public Registration_form(SqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }

        private void Reg_but_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(reg_name.Text) && !string.IsNullOrWhiteSpace(reg_password.Text))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Passangers (Login, Password) VALUES ('{reg_name.Text.ToString()}', '{reg_password.Text.ToString()}')", conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show($"Пользователь под ником {reg_name.Text.ToString()} успешно создан");
                    Pass_login_form loginForm = new Pass_login_form();
                    this.Hide();
                    loginForm.ShowDialog();
                    this.Close();
                }
            }
        }

        private void RegForm_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AirlinesDB"].ConnectionString);
            conn.Open();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Pass_login_form loginForm = new Pass_login_form();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
