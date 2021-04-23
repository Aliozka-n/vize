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

        int baslangic = 0;
        


   



        public Form1()
        {
            InitializeComponent();
        }

        public void yazdir()
        {
            // haberler listem
            List<string> haberler = new List<string>();


            XmlTextReader haber = new XmlTextReader("https://www.ntv.com.tr/son-dakika.rss");


            while (haber.Read()) // haer okunduğu sürece
            {
                 if (haber.Name == "title")
                 {
                   haberler.Add(haber.ToString()); // listeme ekle
                   listBox1.Items.Add(haber.ReadString()); // list box a ekleme
                 }
            }

            
        }
        

        // butona tıklayınca 
        public void button1_Click(object sender, EventArgs e)
        {
            yazdir(); // yazdir fonksiyononu çağır
        }

        public void timer1_Tick(object sender, EventArgs e)
        { 
            baslangic++;
            label1.Text = baslangic.ToString();

            if(baslangic % 10 == 0) // her 10 saniyede bir
            {
                yazdir();
            }
        }
    }
}
