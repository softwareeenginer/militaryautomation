using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace ntp_proje
{
    public partial class AddForm : DevExpress.XtraEditors.XtraForm

    {
        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=ntp; uid=root; pwd=123456");

        public AddForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {

                string name = nameInput.Text;
                string surname = surnameInput.Text;
                string identity = identityInput.Text;
                string rank = rankInput.Text;
                string city = cityInput.Text;
                string district = districtInput.Text;

                string sql = "insert into soldiers (name,surname,identity,_rank,city,district) values (@name,@surname,@identity,@rank,@city,@district)";
                connection.Open();
                MySqlCommand sql_cmd = new MySqlCommand(sql, connection);
                sql_cmd.Parameters.AddWithValue("@name", name);
                sql_cmd.Parameters.AddWithValue("@surname", surname);
                sql_cmd.Parameters.AddWithValue("@identity", identity);
                sql_cmd.Parameters.AddWithValue("@rank", rank);
                sql_cmd.Parameters.AddWithValue("@city", city);
                sql_cmd.Parameters.AddWithValue("@district", district);
                sql_cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Asker Kayıt İşlemi Gerçekleşti.");
                
                this.Hide();
            }
            catch (Exception err)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + err.Message);
                
            }

        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }
    }
}