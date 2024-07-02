using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=dblesson; user ID=postgres; password=12345");
        
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from lesson";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into lesson(derskodu,dersadi,kredisi,akts,adsoyad,donem,harfnot) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)",baglanti);
            komut1.Parameters.AddWithValue("@p1", textBox1.Text);
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p5", textBox5.Text);
            komut1.Parameters.AddWithValue("@p6", textBox6.Text);
            komut1.Parameters.AddWithValue("@p7", textBox7.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme işlemi gerçekleşti");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("delete from lesson where derskodu=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", textBox1.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ders siilme işlemi başarılı");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update lesson set dersadi=@p2, kredisi=@p3, akts=@p4, adsoyad=@p5, donem=@p6, harfnot=@p7 where derskodu=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.Parameters.AddWithValue("@p2", textBox2.Text);
            komut3.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
            komut3.Parameters.AddWithValue("@p5", textBox5.Text);
            komut3.Parameters.AddWithValue("@p6", textBox6.Text);
            komut3.Parameters.AddWithValue("@p7", textBox7.Text);
            komut3.ExecuteNonQuery();
            MessageBox.Show("Ders Güncelleme Başarılı");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int puan = Convert.ToInt32(txtpuan.Text);
            if (puan >= 90) { textBox7.Text = "AA"; }
            else if (puan >= 85 && puan<90) { textBox7.Text = "BA"; }
            else if (puan >= 80 && puan <85) { textBox7.Text = "BB"; }
            else if(puan >= 75 && puan<80) { textBox7.Text = "CB"; }
            else if (puan >= 60 && puan<75) { textBox7.Text = "CC"; }
            else if (puan >= 55 && puan<60) { textBox7.Text = "DC"; }
            else if (puan >= 50 && puan<55) { textBox7.Text = "DD"; }
            else if (puan <50 ) { textBox7.Text = "FF"; }

            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("insert into lesson values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)",baglanti);
            komut4.Parameters.AddWithValue("@p1", textBox1.Text);
            komut4.Parameters.AddWithValue("@p2", textBox2.Text);
            komut4.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut4.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
            komut4.Parameters.AddWithValue("@p5", textBox5.Text);
            komut4.Parameters.AddWithValue("@p6", textBox6.Text);
            komut4.Parameters.AddWithValue("@p7", textBox7.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox8.Text = "3.25";
        }
    }
}
