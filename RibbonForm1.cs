using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;


namespace ntp_proje


{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=ntp; uid=root; pwd=123456");
        string id;
        public RibbonForm1()
        {
            InitializeComponent();
        }

        private void getSoldiers()
        {
            DataTable table = new DataTable();

            //Sql Command
            string sql = "SELECT * FROM soldiers";
            MySqlDataAdapter sql_da = new MySqlDataAdapter(sql, connection);
            sql_da.Fill(table);

            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderCell.Value = "Id";
            dataGridView1.Columns[1].HeaderCell.Value = "İsim";
            dataGridView1.Columns[2].HeaderCell.Value = "Soyisim";
            dataGridView1.Columns[3].HeaderCell.Value = "TC Kimlik";
            dataGridView1.Columns[4].HeaderCell.Value = "Rütbe";
            dataGridView1.Columns[5].HeaderCell.Value = "İl";
            dataGridView1.Columns[6].HeaderCell.Value = "İlçe";

        }

        private void delSoldiers()
        {

            try
            {


                string sql = "DELETE FROM soldiers WHERE id=@id";

                MySqlCommand sql_cmd = new MySqlCommand(sql, connection);
                sql_cmd.Parameters.AddWithValue("@id", id);
                sql_cmd.ExecuteNonQuery();

                MessageBox.Show("Asker Kaydı Silindi.");

                getSoldiers();
            }
            catch (Exception err)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + err.Message);

            }
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            connection.Open();
            getSoldiers();
            connection.Close();
        }
        //Asker Oluşturma
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddForm add = new AddForm();
            add.Show();
        }
        //Asker Silme
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            connection.Open();
            delSoldiers();
            connection.Close();
        }

        //Yenile
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            connection.Open();
            getSoldiers();
            connection.Close();
        }
        //Tıklanan Satırın id'sini çekme
        private void dataGrid1RowSelect(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = row.Cells["id"].Value.ToString();
            }
        }
    }
}