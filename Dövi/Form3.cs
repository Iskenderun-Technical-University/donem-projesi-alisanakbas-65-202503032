using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dövi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.bloomberght.com/doviz/dolar");
            webBrowser1.ScriptErrorsSuppressed = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
