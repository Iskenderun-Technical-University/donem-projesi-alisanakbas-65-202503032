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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        void Geçmiş ()
        {
            con.Open ();
            da = new SqlDataAdapter("select *from Geçmiş", con);
            ds= new DataSet();
            da.Fill (ds,"Geçmiş");
            dataGridView1.DataSource = ds.Tables["Geçmiş"];
            con.Close ();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            Geçmiş ();
        }

        private void button1_Click(object sender, EventArgs e)
        {   con.Open ();
            string kayit = "Select *from Geçmiş Where Ad LIKE '%' + @Ad + '%' ";
            SqlCommand komut = new SqlCommand(kayit, con);
            komut.Parameters.AddWithValue("@Ad", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            if (textBox1.Text == "") 
            Geçmiş();
        }
    }
}
