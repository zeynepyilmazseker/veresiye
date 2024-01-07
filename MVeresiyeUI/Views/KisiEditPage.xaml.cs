using MVeresiyeBL;
namespace MVeresiyeUI.Views;

public partial class KisiEditPage : ContentPage
{
    Kisi kisi;

    public Action<Kisi> AddMetod { get; internal set; }

    public Action<Kisi> EditMetod { get; internal set; }


    public KisiEditPage(Kisi k=null)
	{
		InitializeComponent();
        if (k != null)
        {
            txtAd.Text = k.Ad;
            txtSoyad.Text = k.Soyad;
            txtTelefon.Text = k.Telefon;
            txtMail.Text = k.Mail;
            txtAdres.Text = k.Adres;

        }

        kisi = k;
	}

    void OkClicked(System.Object sender, System.EventArgs e)
    {

        if (kisi == null)
        {
            kisi = new Kisi()
            {
                Ad = txtAd.Text,
                Soyad=txtSoyad.Text,
                Telefon = txtTelefon.Text,
                Mail = txtMail.Text,
                Adres = txtAdres.Text

            };

            if (AddMetod != null)
            {
                AddMetod(kisi);
            }
        }
        else
        {
            kisi.Ad = txtAd.Text;
            kisi.Soyad = txtSoyad.Text;
            kisi.Telefon = txtSoyad.Text;
            kisi.Mail = txtMail.Text;
            kisi.Adres = txtAdres.Text;

            EditMetod(kisi);
        }
        Navigation.PopModalAsync(); //asıl sayfasına geri dönecek

    }

    void CancelClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
