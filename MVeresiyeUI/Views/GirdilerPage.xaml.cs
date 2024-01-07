using MVeresiyeBL;

namespace MVeresiyeUI.Views;

public partial class GirdilerPage : ContentPage
{
    Kisi kisi;
	public GirdilerPage(Kisi k)
	{
		InitializeComponent();
        kisi = k;
        this.Title = k.AdSoyad;
        listGirdiler.ItemsSource = kisi.Girdiler;

        this.BindingContext = kisi;
	}
    string error;

    void AddGirdi(Girdi g)
    {
        g.kid = kisi.ID;
        var res = BL.GirdiEkle(g, out error);
        if (!res)
        {
            DisplayAlert("hata oluştu", error, "OK");

        }
    }

    void EditGirdi(Girdi g)
    {
        var res = BL.GirdiDuzenle(g, out error);
        if (!res)
        {
            DisplayAlert("hata oluştu", error, "OK");

        }
    }

    void RemoveGirdi(Girdi g)
    {
        var res = BL.GirdiSil(g, out error);
        if (!res)
        {
            DisplayAlert("hata oluştu", error, "OK");

        }
    }

    void GirdiEkleClicked(System.Object sender, System.EventArgs e)
    {
        GirdiEditPage page = new GirdiEditPage() { AddMetod = AddGirdi };
        Navigation.PushModalAsync(page);
    }

    void GirdiDuzenleClicked(System.Object sender, System.EventArgs e)
    {
        var b = sender as MenuItem;
        if(b != null)
        {
            var g = kisi.Girdiler.First(o => o.ID == b.CommandParameter.ToString());
            GirdiEditPage page = new GirdiEditPage(g)
            {
                EditMetod = EditGirdi
            };
            Navigation.PushModalAsync(page);
        }
    }

    async void GirdiSilClicked(System.Object sender, System.EventArgs e)
    {
        var b = sender as MenuItem;
        if (b != null)
        {
            var y = await DisplayAlert("silinsin mi?", "silmeyi onayla", "OK", "CANCEL");
            if (y)
            {
                var g = kisi.Girdiler.First(o => o.ID == b.CommandParameter.ToString());
                RemoveGirdi(g);
            }
        }
    }
}
