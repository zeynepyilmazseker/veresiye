using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVeresiyeBL
{
    public class Kisi : INotifyPropertyChanged
    {
        private String id = null;
        private string ad, soyad, telefon, mail, adres;

        public string ID
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Ad
        {
            get => ad;

            set { ad = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("AdSoyad");
            }

        }

        public string Soyad
        {
            get => soyad;
            set { soyad = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("AdSoyad");
            }

        }

        public string AdSoyad => Ad + " " + Soyad;

        public string Telefon
        {
            get => telefon;

            set { telefon = value; NotifyPropertyChanged(); }
        }

        public string Mail
        {
            get => mail;

            set
            {
                mail = value;
                NotifyPropertyChanged();
            }
        }

        public string Adres
        {
            get => adres;

            set
            {
                adres = value;
                NotifyPropertyChanged();
            }
        }

        public string Borc => Girdiler.Sum(o => o.Miktar).ToString("C2");//currency biçimi

        public ObservableCollection<Girdi> Girdiler { get; set; } = new ObservableCollection<Girdi>();

        public void AddGirdi(Girdi g)
        {
            Girdiler.Add(g);
            NotifyPropertyChanged("Borc");
        }
        public void RemoveGirdi(Girdi g)
        {
            Girdiler.Remove(g);
            NotifyPropertyChanged("Borc");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }


}

