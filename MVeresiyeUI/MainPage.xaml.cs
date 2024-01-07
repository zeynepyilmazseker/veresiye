using MVeresiyeBL;

namespace MVeresiyeUI;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

    void Switch_Toggled(System.Object sender, Microsoft.Maui.Controls.ToggledEventArgs e)
    {
		if (e.Value) {
			Application.Current.UserAppTheme = AppTheme.Dark;
		}
		else
            Application.Current.UserAppTheme = AppTheme.Light;

    }
	static string error;
    void kisiEkle(System.Object sender, System.EventArgs e)
    {
        Kisi kisi = new Kisi()
        {
            ID = Guid.NewGuid().ToString(),
            Ad = "Veli",
            Soyad = "Beyaz",
            Telefon = "5545228936",
            Mail = "alikara@gmail.com",
            Adres = "Ali Kara'nın ev adresi...."
        };

        var res = BL.KisiEkle(kisi, out error);

        if (!res)
        {
            DisplayAlert("HATA OLUŞTU", error, "OK");
        }

    

        res = BL.GirdiEkle(new Girdi()
        {
            kid = kisi.ID,
            ID = Guid.NewGuid().ToString(),
            Miktar = 100,
            Tarih = DateTime.Now,
            Aciklama = "30'luk yumurta,2 paket makarna"
        }, out error) ;


        if (!res) {
			DisplayAlert("Hata Oluştu", error, "OK");
		}
    }

	

    
}


