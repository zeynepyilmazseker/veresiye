using MVeresiyeDL;

namespace MVeresiyeBL;

public static class BL
{
    public static List<Kisi> Kisiler = new List<Kisi>();

    public static bool KisiEkle(Kisi k, out string error)
    {

        var res = DL.KisiEkle(k.ID, k.Ad, k.Soyad, k.Telefon, k.Mail, k.Adres, out error);
        if (res != -1)
        {
            Kisiler.Add(k);
            return true;
        }

        return false;
    }

    public static bool KisiDuzenle(Kisi k, out string error)
    {

        var res = DL.KisiDuzenle(k.ID, k.Ad, k.Soyad, k.Telefon, k.Mail, k.Adres, out error);
        if (res != -1)
        {
            var kisi = Kisiler.Find(o => o.ID == k.ID);
            if (kisi != null)
            {
                kisi.Ad = k.Ad;
                kisi.Soyad = k.Soyad;
                kisi.Telefon = k.Telefon;
                kisi.Mail = k.Mail;
                kisi.Adres = k.Adres;
            }
            return true;
        }
        return false;
    }

    public static bool KisiSil(Kisi k, out string error)
    {

        var res = DL.KisiSil(k.ID, out error);
        if (res != -1)
        {
            var kisi = Kisiler.Find(o => o.ID == k.ID);
            if (kisi != null)
            {
                Kisiler.Remove(kisi);
            }

            return true;
        }
        return false;
    }

    public static bool GirdiEkle(Girdi g, out string error)
    {

        var res = DL.GirdiEkle(g.ID, g.kid, g.Miktar, g.Tarih, g.Aciklama, out error);
        if (res != -1)
        {
            var kisi = Kisiler.Find(o => o.ID == g.kid);
            if (kisi != null)
            {
                kisi.Girdiler.Add(g);
            }
            return true;
        }

        return false;
    }

    public static bool GirdiDuzenle(Girdi g, out string error)
    {

        var res = DL.GirdiDuzenle(g.ID, g.Miktar, g.Tarih, g.Aciklama, out error);
        if (res != -1)
        {
            var kisi = Kisiler.Find(o => o.ID == g.kid);
            var girdi = kisi.Girdiler.First(o => o.ID == g.ID);
            if (girdi != null)
            {

                girdi.Miktar = g.Miktar;
                girdi.Tarih = g.Tarih;
                girdi.Aciklama = g.Aciklama;
            }
            return true;
        }
        return false;
    }

    public static bool GirdiSil(Girdi g, out string error)
    {

        var res = DL.GirdiSil(g.ID, out error);
        if (res != -1)
        {
            var kisi = Kisiler.Find(o => o.ID == g.kid);
            if (kisi != null)
            {
                var girdi = kisi.Girdiler.First(o => o.ID == g.ID);
                if (girdi != null)
                {
                    kisi.Girdiler.Remove(girdi);
                }
            }

            return true;
        }
        return false;
    }

    public static bool KisileriYukle(out string error)
    {
        var liste = DL.TumKisiler(out error);
        if (liste == null)
            return false;
        else
        {
            Kisiler.Clear();
            foreach (var e in liste)
            {
                Kisiler.Add(
                    new Kisi
                    {
                        ID = e.kid,
                        Ad = e.ad,
                        Soyad = e.soyad,
                        Telefon = e.telefon,
                        Mail = e.mail,
                        Adres = e.adres,

                    }
                    );
            }


        }
        var liste2 = DL.TumGirdiler(out error);
        if (liste2 == null)
            return false;
        else
        {


            foreach (var e in liste2)
            {
                var kisi = Kisiler.First(o => o.ID == e.kid);
                if (kisi != null)
                {
                    kisi.Girdiler.Add(
                        new Girdi
                        {
                            ID = e.gid,
                            Miktar = e.miktar,
                            Aciklama = e.aciklama,
                            Tarih = e.tarih
                        });
                }
            }
        }
        return true;
    }
}

public static class Ext
{
    public static float ToFloat(this string val)
    {
        float f = 0;
        if (float.TryParse(val, out f))
            return f;
        else
            return 0;
    }
}

