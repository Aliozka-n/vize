using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace vize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // butona tıklayınca 
        private void button1_Click(object sender, EventArgs e)
        {
            XmlTextReader haber = new XmlTextReader("https://www.ntv.com.tr/son-dakika.rss");

            while (haber.Read()) // haer okunduğu sürece
            {
                if (haber.Name == "title")
                {
                    listBox1.Items.Add(haber.ReadString()); // list box a ekleme
                }
            }

        }
    }
}
