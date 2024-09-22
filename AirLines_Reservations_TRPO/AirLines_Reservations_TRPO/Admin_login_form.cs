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
    public partial class Admin_login_form : Form
    {
        private SqlConnection conn;
        public Admin_login_form(SqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }

        public Admin_main_form Admin_main_form
        {
            get => default;
            set
            {
            }
        }

        private void Admin_login_form_Load(object sender, EventArgs e)
        {
            this.AcceptButton = Login_but;
        }

        private void Login_but_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Admin_access", conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            DataRow dr = dataSet.Tables[0].Rows[0];
            if (!string.IsNullOrWhiteSpace(adm_name.Text) && !string.IsNullOrWhiteSpace(adm_password.Text))
            {
                if (dr["Login_adm"].ToString() == adm_name.Text && dr["Password_adm"].ToString() == adm_password.Text)
                {
                    Admin_main_form adm = new Admin_main_form(conn);
                    this.Hide();
                    adm.ShowDialog();
                    this.Close();
                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Pass_login_form loginForm = new Pass_login_form();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void adm_name_Leave(object sender, EventArgs e)
        {
            adm_name.Text = adm_name.Text.TrimEnd();
        }

        private void adm_password_Leave(object sender, EventArgs e)
        {
            adm_password.Text = adm_password.Text.TrimEnd();   
        }
    }
}
