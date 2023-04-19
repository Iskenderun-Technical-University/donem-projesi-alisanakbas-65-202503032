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
    public partial class Form2 : Form
    {
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        SqlDataReader dr;
        System.Data.DataSet ds;
        public static string SqlCon = "Data Source=DESKTOP-3BUBNE9\\SQLEXPRESS;Initial Catalog=Döviz;Integrated Security=True";

        
        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(SqlCon);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 a = new Form3();
            a.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string query = "SELECT ıD, TC, Ad, Soyad, IBAN,TL, DOLAR, EURO FROM tbl_login WHERE 1 = @Tc";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Tc",Form1.Tc.ToString() );
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label6.Text = dr.GetInt32(0).ToString();
                label7.Text = dr.GetString(2);
                label8.Text = dr.GetString(3);
                label9.Text = dr.GetInt32(4).ToString();
                label14.Text = dr.GetSqlMoney(5).ToString();
                label15.Text = dr.GetSqlMoney(6).ToString();
                label16.Text = dr.GetSqlMoney(7).ToString();
            }
             dr.Close();
             con.Close();
        }
    }
}
