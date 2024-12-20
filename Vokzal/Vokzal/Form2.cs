using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vokzal
{
    public partial class Form2 : Form
    {
        MySqlConnection conn;
        public Form2()
        {
            InitializeComponent();
            string constr = "server = localhost ; user = root ; password=; database=vok; charset=utf8";
            conn = new MySqlConnection(constr);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tb1();
        }
        void tb1()
        {
            string qq = "select * from vokr;";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qq, conn);
                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                Frm_t();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }
        void Frm_t()
        {
            dataGridView1.Columns["id"].HeaderText = "id";
            dataGridView1.Columns["passportN"].HeaderText = "passportN";
            dataGridView1.Columns["dis"].HeaderText = "discpunt";
        }
    }
}
