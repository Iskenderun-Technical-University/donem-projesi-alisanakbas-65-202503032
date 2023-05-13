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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Dövi
{
    public partial class Form3 : Form
    {
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        SqlDataReader dr;
        System.Data.DataSet ds;
        public static string SqlCon = "Data Source=DESKTOP-3BUBNE9\\SQLEXPRESS;Initial Catalog=Döviz;Integrated Security=True";



        public static string İşlem="";
        
        string Ad = Form2.Ad.ToString();
        string Soyad = Form2.Soyad.ToString();
        string IBAN = Form2.IBAN.ToString();
        public Form3()
        {
            InitializeComponent();
            con = new SqlConnection(SqlCon);            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.bloomberght.com/doviz/dolar");
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetExchangeRates();
        }
        private void button2_Click(object sender, EventArgs e)
        {          
            if ((comboBox1.Text == "TL") && (comboBox2.Text == "DOLAR"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label1.Text);
                double b = a / c;
                label10.Text = b.ToString();
            }
             
             if ((comboBox1.Text == "DOLAR") && (comboBox2.Text == "TL"))
             {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label1.Text);
                double b = a * c;
                label10.Text = b.ToString();
             }
            if ((comboBox1.Text == "TL") && (comboBox2.Text == "EURO"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label2.Text);
                double b = a / c;
                label10.Text = b.ToString();
            }
            if ((comboBox1.Text == "EURO") && (comboBox2.Text == "TL"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label2.Text);
                double b = a * c;
                label10.Text = b.ToString();
            }
            if ((comboBox1.Text == "DOLAR") && (comboBox2.Text == "EURO"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label6.Text);
                double b = a / c;
                label10.Text = b.ToString();
            }
            if ((comboBox1.Text == "EURO") && (comboBox2.Text == "DOLAR"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label6.Text);
                double b = a * c;
                label10.Text = b.ToString();
            }
            if (label10.Text.Length > 8)
            {
                label10.Text = label10.Text.Substring(0, 8);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
             
            string ad = Form2.ad.ToString();
            double tl = Convert.ToDouble(Form2.tl.ToString());
            double dolar = Convert.ToDouble(Form2.dolar.ToString());
            double euro = Convert.ToDouble(Form2.euro.ToString());

            
            if ((comboBox1.Text == "TL") && (comboBox2.Text == "DOLAR"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label1.Text);
                double b = a / c;
                label10.Text = b.ToString();

                if (tl - a > 0)
                {
                    double sonuc1 = tl - a;
                    double sonuc2 = dolar + b;
                    MessageBox.Show("Türk Lirası hesabınız     -" + a + " -----> " + sonuc1+"\n"+ "Dolar hesabınız    +" + b + " -----> " + sonuc2+"\n"+ "Türk lirası hesabınız " + sonuc1);
                    İşlem = ("Türk Lirası hesabınız     -" + a + " -----> " + sonuc1 + "\n" + "Dolar hesabınız    +" + b + " -----> " + sonuc2 + "\n" + "Türk lirası hesabınız " + sonuc1);
                    con = new SqlConnection(SqlCon);
                    string sql = "update tbl_login set TL =@TL,DOLAR=@DOLAR where Ad=@Ad";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@TL", sonuc1);
                    cmd.Parameters.AddWithValue("@DOLAR", sonuc2);
                    con.Open();
                    cmd.ExecuteNonQuery();            
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Yetersiz bakiye");
                }
            }
            if ((comboBox1.Text == "DOLAR") && (comboBox2.Text == "TL"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label1.Text);
                double b = a * c;
                label10.Text = b.ToString();
                if (dolar - a > 0)
                {
                    double sonuc1 = dolar - a;
                    double sonuc2 = tl + b;
                    MessageBox.Show("Dolar Hesabınız     -" + a + " -----> " + sonuc1+"\n"+ "Türk Lirası hesabınız    +" + b + " -----> " + sonuc2+"\n"+ "Dolar Hesabınız " + sonuc1);
                    İşlem= ("Dolar Hesabınız     -" + a + " -----> " + sonuc1 + "\n" + "Türk Lirası hesabınız    +" + b + " -----> " + sonuc2 + "\n" + "Dolar Hesabınız " + sonuc1);
                    con = new SqlConnection(SqlCon);
                    string sql = "update tbl_login set TL =@TL,DOLAR=@DOLAR where Ad=@Ad";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@DOLAR", sonuc1);
                    cmd.Parameters.AddWithValue("@TL", sonuc2);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Yetersiz bakiye");
                }

            }
            if ((comboBox1.Text == "TL") && (comboBox2.Text == "EURO"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label2.Text);
                double b = a / c;
                label10.Text = b.ToString();

                if (tl - a > 0)
                {
                    double sonuc1 = tl - a;
                    double sonuc2 = euro + b;
                    MessageBox.Show("Türk Lirası Hesabınız     -" + a + " -----> " + sonuc1+"\n"+ "Euro hesabınız    +" + b + " ----->" + sonuc2+"\n+"+ "Türk Lirası hesabınız " + sonuc1);
                    İşlem = ("Türk Lirası Hesabınız     -" + a + " -----> " + sonuc1 + "\n" + "Euro hesabınız    +" + b + " ----->" + sonuc2 + "\n+" + "Türk Lirası hesabınız " + sonuc1);
                    con.Open();
                    con = new SqlConnection(SqlCon);
                    string sql = "update tbl_login set TL =@TL,EURO=@EURO where Ad=@Ad";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@TL", sonuc1);  
                    cmd.Parameters.AddWithValue("@EURO", sonuc2);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Yetersiz bakiye");
                }

            }
            if ((comboBox1.Text == "EURO") && (comboBox2.Text == "TL"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label2.Text);
                double b = a * c;
                label10.Text = b.ToString();
                if (euro - a > 0)
                {
                    double sonuc1 = euro - a;
                    double sonuc2 = tl + b;
                    MessageBox.Show("Euro Hesabınız     -" + a + " -----> " + sonuc1+"\n"+ "Türk Lirası Hesabınız    +" + b + " -----> " + sonuc2+"\n"+ "Euro Hesabınız " + sonuc1);
                    İşlem= ("Euro Hesabınız     -" + a + " -----> " + sonuc1 + "\n" + "Türk Lirası Hesabınız    +" + b + " -----> " + sonuc2 + "\n" + "Euro Hesabınız " + sonuc1);
                    con.Open();
                    con = new SqlConnection(SqlCon);
                    string sql = "update tbl_login set TL =@TL,EURO=@EURO where Ad=@Ad";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Ad", ad); 
                    cmd.Parameters.AddWithValue("@EURO", sonuc1);
                    cmd.Parameters.AddWithValue("@TL", sonuc2);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Yetersiz bakiye");
                }
            }
            if ((comboBox1.Text == "DOLAR") && (comboBox2.Text == "EURO"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label6.Text);
                double b = a / c;
                label10.Text = b.ToString();
                if (dolar - a > 0)
                {
                    double sonuc1 = dolar - a;
                    double sonuc2 = euro + b;
                    MessageBox.Show("Dolar hesabınız     -" + a + " -----> " + sonuc1 +"\n"+"Euro Hesabınız    +" + b + " -----> " + sonuc2+ "\n"+ "Dolar Hesabınız " + sonuc1);
                    İşlem= ("Dolar hesabınız     -" + a + " -----> " + sonuc1 + "\n" + "Euro Hesabınız    +" + b + " -----> " + sonuc2 + "\n" + "Dolar Hesabınız " + sonuc1);
                    con.Open();
                    con = new SqlConnection(SqlCon);
                    string sql = "update tbl_login set DOLAR=@DOLAR,EURO=@EURO where Ad=@Ad";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@DOLAR", sonuc1);
                    cmd.Parameters.AddWithValue("@EURO", sonuc2);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Yetersiz bakiye");
                }
            }
            if ((comboBox1.Text == "EURO") && (comboBox2.Text == "DOLAR"))
            {
                double a = Convert.ToDouble(textBox1.Text);
                double c = Convert.ToDouble(label6.Text);
                double b = a * c;
                label10.Text = b.ToString();
                if (euro - a > 0)
                {
                    double sonuc1 = euro - a;
                    double sonuc2 = dolar + b;
                    MessageBox.Show("Euro Hesabınız     -" + a + " -----> " + sonuc1+"\n"+ "Dolar Hesabınız    +" + b + " -----> " + sonuc2+"\n"+ "Euro Hesabınız " + sonuc1);
                    İşlem= ("Euro Hesabınız     -" + a + " -----> " + sonuc1 + "\n" + "Dolar Hesabınız    +" + b + " -----> " + sonuc2 + "\n" + "Euro Hesabınız " + sonuc1);
                    con.Open();
                    con = new SqlConnection(SqlCon);
                    string sql = "update tbl_login set DOLAR=@DOLAR,EURO=@EURO where Ad=@Ad";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@EURO", sonuc1);
                    cmd.Parameters.AddWithValue("@DOLAR", sonuc2);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Yetersiz bakiye");
                }               
            }
            con.Open();
            cmd = new SqlCommand("insert into Geçmiş (Ad,Soyad,IBAN,İşlem) values (@p2,@p3,@p4,@p5)", con);
            cmd.Parameters.AddWithValue("@p2", Ad);
            cmd.Parameters.AddWithValue("@p3", Soyad);
            cmd.Parameters.AddWithValue("@p4", IBAN);
            cmd.Parameters.AddWithValue("@p5", İşlem);
            cmd.ExecuteNonQuery();
            con.Close();




            textBox1.Clear();
            label10.Text = "_____________";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;



        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }      
        private void GetExchangeRates()
        {
            HtmlElementCollection htmlElementCollection = webBrowser1.Document.All;
            foreach (HtmlElement name in htmlElementCollection)
            {
                if (name.GetAttribute("className") == "value dolar-bid")
                {
                    label1.Text = name.InnerText;
                }
                if (name.GetAttribute("className") == "value euro-bid")
                {
                    label2.Text = name.InnerText;
                }
                if (name.GetAttribute("className") == "value eur-usd-bid")
                {
                    label6.Text = name.InnerText;
                }
            }



        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }       
    }
}

