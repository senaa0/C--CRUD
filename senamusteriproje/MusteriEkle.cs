using System;
using System.Windows.Forms;

namespace senamusteriproje
{
    public partial class MusteriEkle : Form
    {
        public MusteriEkle(string title)
        {
            InitializeComponent();
            lbl_Title.Text = title;
        }

        public static string id=null;

        public void MusteriEkle_Load(object sender, EventArgs e)
        {
            ((Musteri)Application.OpenForms["Musteri"]).Enabled = false;    

            switch(lbl_Title.Text)
            {
                case "Müşteri Ekle":
                    break;

                case "Müşteri Düzenle":
                    button1.Text = "Düzenle";
                    txt_id.Text = Musteri.id;
                    txt_cariadi.Text = Musteri.cariadi;
                    txt_vno.Text = Musteri.vno;
                    txt_vergidairesi.Text = Musteri.vergidairesi;   
                    txt_adres.Text = Musteri.adres;
                    txt_telefon.Text = Musteri.telefon;
                    txt_sehir.Text = Musteri.sehir;
                    break;
            }
        }

        public void MusteriEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Musteri)Application.OpenForms["Musteri"]).Enabled = true;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch(lbl_Title.Text)
                {
                    case "Müşteri Ekle":
                        mysql.Query($"insert into musteri(cariadi,vno,vergidairesi,adres,telefon,sehir) values('{txt_cariadi.Text}','{txt_vno.Text}','{txt_vergidairesi.Text}','{txt_adres.Text}','{txt_telefon.Text}','{txt_sehir.Text}')");
                        break;

                    case "Müşteri Düzenle":
                        mysql.Query($"update musteri set cariadi='{txt_cariadi.Text}',vno='{txt_vno.Text}',vergidairesi='{txt_vergidairesi.Text}'" +
                            $",adres='{txt_adres.Text}',telefon='{txt_telefon.Text}',sehir='{txt_sehir.Text}' Where id='{txt_id.Text}'");
                        break;

                }
                ((Musteri)Application.OpenForms["Musteri"]).Disp();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
