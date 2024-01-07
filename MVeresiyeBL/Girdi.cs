using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVeresiyeBL
{
    public class Girdi : INotifyPropertyChanged
    {
        private float miktar;
        private string id = null;
        private DateTime tarih;
        private string aciklama;


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
        public string kid { get; set; }
        public float Miktar
        {
            get => miktar;
            set
            {
                miktar = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime Tarih
        {
            get => tarih;
            set
            {
                tarih = value;
                NotifyPropertyChanged();
            }
        }
        public string Aciklama
        {
            get => aciklama;
            set
            {
                aciklama = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

