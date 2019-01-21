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



namespace AdoGiris
{
    public partial class Form1 : Form
    {
        SqlConnection con;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
            }
            catch(System.ApplicationException ex)
            {
                Console.WriteLine("Error reading from {0}.Message= {1}", ex.Source, ex.Message);
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //bağlantı oluşturmak,açmak için.
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                MessageBox.Show("baglantı acıldı.");
            }
            else
            {
                MessageBox.Show("açık bir bağlantı var.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                MessageBox.Show("bağlantı kapatıldı.");

            }
            else
            {
                MessageBox.Show("bağlantı açık değil.");
            }
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    MessageBox.Show("baglantı acıldı.");
                }
                else
                {
                    con.Close();
                    MessageBox.Show("bağlantı kapatıldı.");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
