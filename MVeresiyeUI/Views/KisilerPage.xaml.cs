using Microsoft.Maui.Controls;
using MVeresiyeBL;

namespace MVeresiyeUI.Views;

public partial class KisilerPage : ContentPage
{
	public KisilerPage()
	{
		InitializeComponent();
		KisileriYukle();
        listKisiler.ItemsSource = BL.Kisiler;
    }

	string error;

    private void KisileriYukle()
    {
		bool res = BL.KisileriYukle(out error);
		if (!res)
		{
			DisplayAlert("hata oluştu", error, "OK");
		}


    }

	void AddKisi (Kisi k)
	{
		var res = BL.KisiEkle(k, out error);
		if (!res)
		{
			DisplayAlert("hata oluştu", error, "OK");
		}
	}

   private void KisiEkleClicked(System.Object sender, System.EventArgs e)
    {
		KisiEditPage page = new KisiEditPage() { AddMetod = AddKisi };
		Navigation.PushModalAsync(page);
    }

    void KisileriYukleClicked(System.Object sender, System.EventArgs e)
    {
		KisileriYukle();
        refreshView.IsRefreshing = false;
    }

    void KisiDuzenleClicked(System.Object sender, System.EventArgs e)
    {
		var b = sender as ImageButton;
		if(b != null)
		{ 
		var kisi =  BL.Kisiler.First(o => o.ID == b.CommandParameter.ToString());
        KisiEditPage page = new KisiEditPage(kisi) {EditMetod = EditKisi};
        Navigation.PushModalAsync(page);
        }
    }

    private void EditKisi(Kisi k)
    {
		BL.KisiDuzenle(k, out error);
    }

    async void KisiSilClicked(System.Object sender, System.EventArgs e)
    {
        var b = sender as ImageButton;
        if (b != null)
        {
            var y = await DisplayAlert("silinsin mi?","silmeyi onayla","OK","CANCEL");
            if (y)
            {
                var kisi = BL.Kisiler.First(o => o.ID == b.CommandParameter.ToString());
                var res = BL.KisiSil(kisi, out error);
                if (!res)
                {
                    await DisplayAlert("hata oluştu", error, "OK");
                }
            }
           
            
        }
    }

    void listKisiler_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection?.Count == 0)
            return;
        var kisi = e.CurrentSelection[0] as Kisi;
        GirdilerPage page = new GirdilerPage(kisi);
        Navigation.PushAsync(page);
        

    }
}
