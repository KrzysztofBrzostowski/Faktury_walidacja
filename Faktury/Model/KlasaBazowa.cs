using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace Faktury.Model
{
    public abstract class KlasaBazowa : ICloneable, INotifyPropertyChanged,  IDataErrorInfo
    {
        public bool CzyZmieniony { get; set; }
        public bool CzyZaznaczony { get; set; }

        public object Clone()
        {
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void WysliPowiadomienie(string nazwaWlasciwosci)
        {
            WysliPowiadomienie(this, nazwaWlasciwosci);
        }

        protected void WysliPowiadomienie(object objektPowiadmjajacy, string nazwaWlasciwosci)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(objektPowiadmjajacy, new PropertyChangedEventArgs(nazwaWlasciwosci));
            }
        }
        /*
        public virtual bool IsValid()
        {
            return false;
        }
        */

        Dictionary<string, object> _stanObjektu = new Dictionary<string, object>();
        public void ZapiszStan()
        {
            WyczyscStan();

            var mojeWlascwiosci = this.GetType().GetProperties();
            foreach (var wlasciwosc in mojeWlascwiosci)
            {
                if (wlasciwosc.CanRead && wlasciwosc.CanWrite)
                {
                    _stanObjektu.Add(
                        wlasciwosc.Name,
                        wlasciwosc.GetValue(this, null));
                }
            }
        }

        public void PrzywrocStan()
        {
            var mojeWlascwiosci = this.GetType().GetProperties();
            foreach (var wlasciwosc in mojeWlascwiosci)
            {
                if (wlasciwosc.CanRead && wlasciwosc.CanWrite)
                {
                    wlasciwosc.SetValue(this, _stanObjektu[wlasciwosc.Name], null);
                }
            }
            
            WyczyscStan();
        }

        public void WyczyscStan()
        {
            _stanObjektu.Clear();
        }



        #region Walidacja objektow
        protected Dictionary<string, string> _bledyWalidacji = new Dictionary<string, string>();
        public string Error
        {
            get { return ""; }
        }

        public virtual string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsValid()
        {
            return _bledyWalidacji.Count == 0;
        }

        public string ListaBledow()
        {
            var sb = new StringBuilder();
            foreach (var blad in _bledyWalidacji)
            {
                sb.AppendLine(blad.Value);
            }

            return sb.ToString();
        }

        #endregion
    }
}
