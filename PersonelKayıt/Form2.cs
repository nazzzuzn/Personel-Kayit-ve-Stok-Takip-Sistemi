using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayıt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=NAZPC;Initial Catalog=Personel;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            this.urunKayitTableAdapter.Fill(this.personelDataSet1.UrunKayit);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into UrunKayit(UrunAd,StokKodu,UrunAdedi,AlisFiyati,SatisFiyati) values(@UrunAd,@StokKodu,@UrunAdedi,@AlisFiyati,@SatisFiyati)", connection);
            command.Parameters.AddWithValue("@UrunAd", textBox1.Text);
            command.Parameters.AddWithValue("@StokKodu", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@UrunAdedi", maskedTextBox2.Text);
            command.Parameters.AddWithValue("@AlisFiyati", maskedTextBox3.Text);
            command.Parameters.AddWithValue("@SatisFiyati", maskedTextBox4.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.urunKayitTableAdapter.Fill(this.personelDataSet1.UrunKayit);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            textBox1.Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox3.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            maskedTextBox4.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            label6.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commSil = new SqlCommand("delete from UrunKayit where UrunId=@Urunıd", connection);
            commSil.Parameters.AddWithValue("@Urunıd", label6.Text);
            commSil.ExecuteNonQuery();
            connection.Close();
            this.urunKayitTableAdapter.Fill(this.personelDataSet1.UrunKayit);
            MessageBox.Show("Silme İşlemi Tamamlandı");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commGuncelle = new SqlCommand("update UrunKayit set UrunAd=@UrunAd,StokKodu=@StokKodu,UrunAdedi=@UrunAdedi,AlisFiyati=@AlisFiyati,SatisFiyati=@SatisFiyati where UrunID=@Urunid", connection);
            commGuncelle.Parameters.AddWithValue("@UrunAd", textBox1.Text);
            commGuncelle.Parameters.AddWithValue("@StokKodu", maskedTextBox1.Text);
            commGuncelle.Parameters.AddWithValue("@UrunAdedi", maskedTextBox2.Text);
            commGuncelle.Parameters.AddWithValue("@AlisFiyati", maskedTextBox3.Text);
            commGuncelle.Parameters.AddWithValue("@SatisFiyati", maskedTextBox4.Text);
            commGuncelle.Parameters.AddWithValue("@Urunid", label6.Text);
            commGuncelle.ExecuteNonQuery();
            connection.Close();
            this.urunKayitTableAdapter.Fill(this.personelDataSet1.UrunKayit);
            MessageBox.Show("Güncelleme İşlemi Tamamlandı");

        }

    }
}
