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


namespace Dövi
{
    public partial class Form1 : Form
    {
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        SqlDataReader dr;
        System.Data.DataSet ds;
        public static string SqlCon = "Data Source=DESKTOP-3BUBNE9\\SQLEXPRESS;Initial Catalog=Döviz;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();

            con = new SqlConnection(SqlCon);


        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
                

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sorgu = "select * from tbl_login where kullanici ='"+txtKullaniciAdi.Text+"' and sifre='"+txtSifre.Text+"' ";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
                txtKullaniciAdi.Clear();
                txtSifre.Clear();
                txtKullaniciAdi.Focus();
            }
            con.Close();

        }
    }
}
