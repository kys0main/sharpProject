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
using Microsoft.VisualBasic;

namespace AirLines_Reservations_TRPO
{
    public partial class Admin_main_form : Form
    {
        private SqlConnection conn;
        public Admin_main_form(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        public Admin_create_flight Admin_create_flight
        {
            get => default;
            set
            {
            }
        }

        public Admin_flights_list Admin_flights_list
        {
            get => default;
            set
            {
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Pass_login_form loginForm = new Pass_login_form();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void Add_flight_Click(object sender, EventArgs e)
        {
            //string input = Interaction.InputBox("Введите текст:", "Заголовок", "Текст по умолчанию");
            Admin_create_flight addnewflight = new Admin_create_flight(conn);
            this.Hide();
            addnewflight.ShowDialog();
            this.Close();
        }

        private void Edit_flight_Click(object sender, EventArgs e)
        {
            Admin_flights_list edit_Flights = new Admin_flights_list(conn);
            this.Hide();
            edit_Flights.ShowDialog();
            this.Close();
        }
    }
}
