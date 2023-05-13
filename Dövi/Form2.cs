using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        public static string tl = "",dolar = "",euro="", ad = "";
        public static string ID ="",Ad = "", Soyad = "",IBAN="";

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(SqlCon);
        }       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Form2_Load(sender, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();         
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string query = "SELECT ıD, TC, Ad, Soyad, IBAN,TL, DOLAR, EURO FROM tbl_login WHERE Tc = @Tc";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Tc",Form1.Tc.ToString() );
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form3 form3 = new Form3();
                label6.Text = dr.GetInt32(0).ToString();
                label7.Text = dr.GetString(2);
                ad = label7.Text;
                Ad= label7.Text;
                label8.Text = dr.GetString(3);
                Soyad = label8.Text;
                label9.Text = dr.GetDecimal(4).ToString();
                IBAN = label9.Text;
                label14.Text = dr.GetSqlMoney(5).ToString();
                tl = label14.Text;
                label15.Text = dr.GetSqlMoney(6).ToString();
                dolar = label15.Text;
                label16.Text = dr.GetSqlMoney(7).ToString();
                euro = label16.Text;
            }
             dr.Close();
             con.Close();
        }       
    }
}
