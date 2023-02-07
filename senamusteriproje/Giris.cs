using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace senamusteriproje
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string cs = @"server=93.89.225.112;username=pehozgun_admina;password=Admin5050;database=pehozgun_verita";
            var con = new MySqlConnection(cs); 
             MySqlDataReader dr;

            try
            {
                con.Open();
                string stm = "select eposta,sifre from kullanici Where eposta=@Name AND sifre=@Password";
                var cmd=new MySqlCommand(stm,con);

                cmd.Parameters.AddWithValue("@Name", txt_username.Text);
                cmd.Parameters.AddWithValue("@Password", txt_password.Text);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    musteri_form();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
        private void musteri_form()
        {
            this.Hide();
            Musteri frm = new Musteri();
            frm.ShowDialog();
            this.Close();
        }
    }
}
