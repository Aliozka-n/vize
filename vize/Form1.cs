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
using System.IO;

namespace vize
{
    public partial class Form1 : Form
    {
        StreamWriter sw;

        int baslangic = 0;  // zaman için
        int tur = 0;       // ilk verileri alırken sorun yaşamamak için

        string ensonhaber = "Yeni bir haber gelmedi";

        // haberler listem
        List<string> haberler = new List<string>();

        // array list
        

        // yazı boyutu
        int boyut = 9; 

        public Form1()
        {
            InitializeComponent();
            dosyaolustur();
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
                            haberler.Add(deger+"\n"); // listeme ekle
                            listBox1.Items.Add(deger); // list box a ekleme

                            // txt dosyası işlemleri

                            string[] satir = File.ReadAllLines(@"D:\\Haberler.txt");
                        
                        
                            if (satir.Contains(deger))
                            {
                                continue;
                            }
                            else
                            {
                                File.AppendAllText(@"D:\\Haberler.txt", deger + "\n");
                                MessageBox.Show(deger, "Yeni haber geldi ve eklendiiii");
                                ensonhaber = deger;
                            }
                        

                    }
                    else // kayıtlardan sonra
                    {
                        if (haberler.Contains(deger+"\n")) //listemdeki değerlerden farklı mı
                        {
                            continue;
                        }
                        else // listemdeki değerlerden farklı geldiyse
                        {
                            ensonhaber = deger;
                            MessageBox.Show(deger,"Yeni haber geldi "); // Yeni haber gelince uyar
                            haberler.Add(deger+"\n"); // listeme ekle
                            listBox1.Items.Add(deger); // list box a ekleme
                            File.AppendAllText(@"D:\\Haberler.txt", deger + "\n");
                        }
                    }
                }
            }

            tur = 1; // ilk  veriler alındı
            
        }
        

        // butona tıklayınca 
        public void button1_Click(object sender, EventArgs e)
        {
            yazdir(); // yazdir fonksiyononu çağır
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            if (tur != 0)
            {
                baslangic++;
                label1.Text = baslangic.ToString();

                if (baslangic % 10 == 0) // her 10 saniyede bir
                {
                    yazdir();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ensonhaber;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            boyut += 1;
            if (boyut <= 5)
            {
                listBox1.Font = new Font("Arial", 6);
            }
            else
            {
                listBox1.Font = new Font("Arial", boyut);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            boyut -= 1;
            if (boyut <= 5)
            {
                listBox1.Font = new Font("Arial", 5);
                if (boyut<5) // boyutu en az 5 olarak ayarlama ve Büyüt tusundaki hata düzeltmesi
                {
                    boyut = 5; // sayının azalmasını engelleme ve buyut tuşunun doğru çalışması
                }
            }
            else
            {
                listBox1.Font = new Font("Arial", boyut);
            }

        }

        

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            dosyaolustur();
        }



        // txt dosyasını oluştur
        public void dosyaolustur()
        {
            String dosya = "D:\\Haberler.txt";

            if (File.Exists(dosya) == false) // daha onceden dosya var mı yok mu
            { 
            // varsayılan dosya ismi Haberler.txt
            sw = File.CreateText("D:\\Haberler.txt"); // d klasoru altında haberler.txt
            sw.Close(); // dosyayı kapat
            }
        }

 
    }
}
