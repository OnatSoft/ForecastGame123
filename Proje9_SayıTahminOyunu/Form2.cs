using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje9_SayıTahminOyunu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void startGame()
        {
            Random random = new Random();
            rastgele = random.Next(9,101);
            label2.Text = Convert.ToString(rastgele);
            button3.Enabled = false;
            hak = 6;
        }

        int rastgele;
        int hak = 6;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            int tahmin = Convert.ToInt32(textBox1.Text);
            hak = hak - 1;

            if (rastgele > tahmin)
            {
                MessageBox.Show(tahmin + " Sayısı Bilmeniz Gereken Sayıdan Küçük", "YANLIŞ CEVAP");
                label3.Text = "Kalan Tahmin Hakkınız: " + hak;
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                textBox1.Focus();
                
            }
            if (rastgele < tahmin)
            {
                MessageBox.Show(tahmin + " Sayısı Bilmeniz Gereken Sayıdan Büyük", "YANLIŞ CEVAP");
                label3.Text = "Kalan Tahmin Hakkınız: " + hak;
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                textBox1.Focus();
                
            }
            if (hak == 0)
            {
                frm.BackColor = Color.Coral;
                textBox1.Enabled = false;
                textBox1.Text = "";
                label4.Visible = false;
                label1.Visible = true;
                label1.Text = "Tüm hakkınız bu oturumda bitti ve maalesef\noyunu kaybettiniz!\nDoğru Cevap: "+rastgele;
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                button3.Enabled = true;
                button1.Enabled = false;
            }
            if (rastgele == tahmin)
            {
                frm.BackColor = Color.LimeGreen;
                textBox1.Text = "";
                textBox1.Enabled = false;
                label1.Visible = false;
                label4.Visible = true;
                label4.Text = "Tebrikler, Doğru Sayıyı Bildiniz!\nTahmininiz: "+tahmin;
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
                button1.Enabled = false;
                button3.Enabled = true;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen 10-100 arasında bir tahmin yapınız.", "TAHMİN HATASI");
                textBox1.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            startGame();
            label1.Visible = false;
            label4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label4.Visible = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = false;
            label3.Text = "Kalan Tahmin Hakkınız: 6";
            textBox1.Text = "";
            textBox1.ReadOnly = false;
            textBox1.Enabled = true;
            button1.Enabled = true;
            MessageBox.Show("Tahminler ve haklar sıfırlandı, yeni bir sayı üretildi!", "Yeni Oyun Başladı");
            startGame();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            startGame();
        }
    }
}
