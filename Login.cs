using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace ntp_proje
{
    public partial class Login : Form
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=ntp; uid=root;pwd=123456");


        /**
         * Form
         */
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {


        }

        /**
         * Login Btn
         */
        private void button1_Click(object sender, EventArgs e)
        {

            string name = nameText.Text;
            string password = passwordText.Text;

            if (name != "" && password != "")
            {

                connection.Open();
                //Sql Command
                MySqlCommand sql_cmd = new MySqlCommand("SELECT * FROM users WHERE name='" + name + "' AND password='" + password + "'", connection);
                MySqlDataReader sql_dr = sql_cmd.ExecuteReader();

                if (sql_dr.Read())
                {
                    this.Hide();
                    RibbonForm1 ribbon = new RibbonForm1();
                    ribbon.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
                }
                connection.Close();

            }
            else
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz.");
            }

        }


    }
}
