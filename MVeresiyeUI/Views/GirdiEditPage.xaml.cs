using MVeresiyeBL;
namespace MVeresiyeUI.Views;

public partial class GirdiEditPage : ContentPage
{
    Girdi girdi;

    public Action<Girdi> AddMetod { get; internal set; }

    public Action<Girdi> EditMetod { get; internal set; }

   // public Action<Girdi> RemoveMetod { get; internal set; }

    public GirdiEditPage(Girdi g=null)
	{
		InitializeComponent();
        if (g != null)
        {
            txtMiktar.Text = g.Miktar.ToString();
            txtAciklama.Text = g.Aciklama;
            dtTarih.Date = new DateTime(dtTarih.Date.Year, dtTarih.Date.Month, dtTarih.Date.Day);
            dtSaat.Time = new TimeSpan(dtSaat.Time.Hours, dtSaat.Time.Minutes, dtSaat.Time.Seconds);


        }
        else
        {
            dtTarih.Date = DateTime.Now;
            dtSaat.Time = DateTime.Now.TimeOfDay;
        }
        girdi = g;

	}

    void OkClicked(System.Object sender, System.EventArgs e)
    {
        if (girdi == null)
        {
            girdi = new Girdi()
            {
                Miktar = txtMiktar.Text.ToFloat(),
                Aciklama = txtAciklama.Text,
                Tarih = getDateTime()

            };

            if (AddMetod != null)
                AddMetod(girdi);
        }

        else
        {
            girdi.Miktar = txtMiktar.Text.ToFloat();
            girdi.Aciklama = txtAciklama.Text;
            girdi.Tarih = getDateTime();

            if (EditMetod != null)
                EditMetod(girdi);
        }
        Navigation.PopModalAsync();
       
    }

    DateTime getDateTime ()
    {
        return new DateTime(dtTarih.Date.Year, dtTarih.Date.Month, dtTarih.Date.Day,
            dtSaat.Time.Hours, dtSaat.Time.Minutes,dtSaat.Time.Seconds);
    }

    void CancelClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}

