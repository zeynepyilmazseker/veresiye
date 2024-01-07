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

        /* 
                var res =  BL.KisiEkle(new Kisi()
               {
                   ID = Guid.NewGuid().ToString(),
                   Ad="Ali",
                   Soyad="Kara",
                   Telefon ="5545228936",
                   Mail = "alikara@gmail.com",
                   Adres="Ali Kara'nın ev adresi...."


               }, out error);

              var res = BL.KisiDuzenle(new Kisi()
               {
                   ID= "87bbe9f9-82ac-4500-aaa6-5c7a1e38eb5a",
                   Ad="Alican",
                   Soyad="Beyaz",
                   Telefon="5454623728",
                   Mail="ali@gmail.com",
                   Adres="iş adresi"
               },out error); 



               var res = BL.KisiSil(new Kisi()
               {
                   ID = "87bbe9f9-82ac-4500-aaa6-5c7a1e38eb5a",

               }, out error); */

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


