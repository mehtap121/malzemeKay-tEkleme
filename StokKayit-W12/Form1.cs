
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // veritabaný baðlantýsý için
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokKayit_W12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();

        }
        private void listele()//veri tabanýndaki kayýtlarýn görüntülenmesi
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from malzemeler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {//ekle
            String t1 = textBox1.Text;
            String t2 = textBox2.Text;
            String t3 = textBox3.Text;
            String t4 = textBox4.Text;
            String t5 = textBox5.Text;
            String t6 = textBox6.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO malzemeler (malzemekodu,malzemeadi,yýllýksatis,birimfiyat,minstok,tsüresi)VALUES('" + t1
                + "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "','" + t6 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LT3MUVA\\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");


        private void button2_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text; //seçilen satýrýn malzeme kodunu alýr.
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM malzemeler WHERE malzemekodu=('" + t1 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;
            String t2 = textBox2.Text;
            String t3 = textBox3.Text;
            String t4 = textBox4.Text;
            String t5 = textBox5.Text;
            String t6 = textBox6.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE malzemeler SET malzemekodu='" + t1 + "' , malzemeadi='" + t2 + "',yýllýksatis='" + t3 + "', birimfiyat='" + t4 + "' , minstok='" + t5 + "' , tsüresi='" + t6 + "'  WHERE malzemekodu='" + t1 + "'", baglanti);
            komut.ExecuteNonQuery();

            baglanti.Close();
            listele();
        }
    }
}
