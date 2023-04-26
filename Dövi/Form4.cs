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
    public partial class Form4 : Form
    {

        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        SqlDataReader dr;
        System.Data.DataSet ds;
        public static string SqlCon = "Data Source=DESKTOP-3BUBNE9\\SQLEXPRESS;Initial Catalog=Döviz;Integrated Security=True";
        public Form4()
        {
            InitializeComponent();
            con = new SqlConnection(SqlCon);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string query = "SELECT ıD, TC, Ad, Soyad, IBAN,TL, DOLAR, EURO FROM tbl_login WHERE 1 = @Tc";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Tc", Form1.Tc.ToString());
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               
            }
            dr.Close();
            con.Close();

        }
    }
}
