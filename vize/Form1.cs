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
        int tur = 0;
        // haberler listem
        List<string> haberler = new List<string>();






        public Form1()
        {
            InitializeComponent();
        }

        public void yazdir()
        {
            

            XmlTextReader haber = new XmlTextReader("https://www.ntv.com.tr/son-dakika.rss");

            while (haber.Read()) // haber okunduğu sürece
            {
                 if (haber.Name == "title")
                 {
                   String deger = haber.ReadString(); 

                   if (tur == 0) //program  başladığında kayıtları ekle
                       { 
                        haberler.Add(deger); // listeme ekle
                        listBox1.Items.Add(deger); // list box a ekleme
                       }
                    else // kayıtlardan sonra
                    {
                        if (haberler.Contains(deger))
                        {
                            continue;
                        }
                        else
                        {
                            MessageBox.Show(deger,"Yeni haber"); // Yeni haber gelince uyar
                            haberler.Add(deger); // listeme ekle
                            listBox1.Items.Add(deger); // list box a ekleme
                          
                        }
                    }
                }
            }

            tur = 1;
            
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
