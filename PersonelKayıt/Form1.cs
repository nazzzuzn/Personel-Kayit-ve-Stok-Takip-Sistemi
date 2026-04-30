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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=NAZPC;Initial Catalog=Personel;Integrated Security=True");
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label5.Text = "Kadın";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label5.Text = "Erkek";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into PersonelKayit (KullaniciAdSoyad, eposta, cinsiyet, sifre) values (@AdSoyad, @eposta, @cinsiyet, @sifre)", connection);
            command.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
            command.Parameters.AddWithValue("@eposta", txtEposta.Text);
            command.Parameters.AddWithValue("@cinsiyet", label5.Text);
            command.Parameters.AddWithValue("@sifre", txtSifre.Text);
            command.ExecuteNonQuery();
            SqlCommand comm = new SqlCommand("insert into PersonelGiris (AdSoyad, sifre) values (@AdSoyad, @sifre)", connection);
            comm.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
            comm.Parameters.AddWithValue("@sifre", txtSifre.Text);
            comm.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Başarılı");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from PersonelGiris where AdSoyad=@AdSoyad and sifre=@sifre", connection);
            command.Parameters.AddWithValue("@AdSoyad", txtAdSoyadG.Text);
            command.Parameters.AddWithValue("@sifre", txtSifreG.Text);
            SqlDataReader kayit = command.ExecuteReader();
            if (kayit.Read())
            {
                Form2 form2 = new Form2();
                form2.Show();

            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
            }
            connection.Close();

        }
    }
}
