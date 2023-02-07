using System;
using System.Windows.Forms;

namespace senamusteriproje
{
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }

        public static string id = null;
        public static string cariadi=null;
        public static string vno=null;
        public static string vergidairesi=null;
        public static string adres=null;
        public static string telefon=null;
        public static string sehir=null;

        public void Disp()
        {
            dataGridView1.DataSource = mysql.GetData($"select * from musteri");
            dataGridView1.ClearSelection();
        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            Disp();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            Button btnText = (Button)sender;
            switch (btnText.Text)
            {
                case "Ekle":
                    new MusteriEkle("Müşteri Ekle").Show();
                    break;

                case "Düzenle":
                    if(dataGridView1.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Kayıt Seçilmedi");
                    }
                    else
                    {
                        new MusteriEkle("Müşteri Düzenle").Show();
                    }
                    break;

                case "Sil":
                    if(dataGridView1.SelectedRows.Count==0)
                    {
                        MessageBox.Show("Kayıt Seçilmedi");
                    }
                    else
                    {
                        try
                        {
                            DialogResult dr = MessageBox.Show("Seçili kaydı silmek ister misiniz?", "Onayla", MessageBoxButtons.YesNo);
                            if(dr== DialogResult.Yes)
                            {
                                mysql.Query($"delete from musteri where id='{id}'");
                                Disp();
                                MessageBox.Show("Başarıyla silindi...");
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;

            

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            cariadi = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            vno = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            vergidairesi = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            adres = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            telefon = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            sehir = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
        }
    }
}
