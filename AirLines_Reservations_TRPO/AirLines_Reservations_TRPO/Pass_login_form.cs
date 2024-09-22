using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace AirLines_Reservations_TRPO
{
    public partial class Pass_login_form : Form
    {
        private SqlConnection conn=null;
        public Pass_login_form()
        {
            InitializeComponent();
        }

        public Admin_login_form Admin_login_form
        {
            get => default;
            set
            {
            }
        }

        public Registration_form Registration_form
        {
            get => default;
            set
            {
            }
        }

        public Pass_main_form Pass_main_form
        {
            get => default;
            set
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn= new SqlConnection(ConfigurationManager.ConnectionStrings["AirlinesDB"].ConnectionString);
            conn.Open();
            this.AcceptButton = Login_but;
        }


        private void Login_but_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter= new SqlDataAdapter("SELECT * FROM Passangers", conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable table1= dataSet.Tables[0];
            int count = 0;
            if (!string.IsNullOrWhiteSpace(login_name.Text) && !string.IsNullOrWhiteSpace(login_password.Text))
            {
                foreach(DataRow row in table1.Rows)
                {
                    string login = row["Login"].ToString();
                    string password = row["Password"].ToString();
                    if(login_name.Text.Equals(login)&& login_password.Text.Equals(password))
                    {
                        Pass_main_form pass_form = new Pass_main_form(conn, row);
                        this.Hide();
                        pass_form.ShowDialog();
                        this.Close();
                    }
                    else count++;
                }  
                if(count == table1.Rows.Count)
                {
                    MessageBox.Show("Такой пользователь не найден");
                }
            }
            else MessageBox.Show("Введите ваши данные или зарегистрируйтесь");
            
        }

        private void Go_Reg_Click(object sender, EventArgs e)
        {
            Registration_form regForm = new Registration_form(conn);
            this.Hide();
            regForm.ShowDialog();
            this.Close();
        }

        private void Go_adm_Click(object sender, EventArgs e)
        {
            Admin_login_form admForm = new Admin_login_form(conn);
            this.Hide();
            admForm.ShowDialog();
            this.Close();
        }

        private void login_name_Leave(object sender, EventArgs e)
        {
            login_name.Text = login_name.Text.TrimEnd();
        }
        private void login_password_Leave(object sender, EventArgs e)
        {
            login_password.Text = login_password.Text.TrimEnd();
        }
    }
}
