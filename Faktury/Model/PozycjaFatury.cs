using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Faktury.Model
{
    public class PozycjaFatury : KlasaBazowa
    {
        Faktura _referencjaDoFaktury;

        public PozycjaFatury(Faktura referencjaDoFaktury)
        {
            _referencjaDoFaktury = referencjaDoFaktury;
        }

        private int _pozycjaID;
        public int PozycjaID
        {
            get { return _pozycjaID; }
            set { _pozycjaID = value; }
        }

        private string _produkt = "";
        public string Produkt
        {
            get { return _produkt; }
            set 
            {
                /*
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new Exception("Błędna nazwa produktu");
                }
                */
                _produkt = value;
                WysliPowiadomienie("Produkt"); 
            }
        }

        private decimal _ilosc;
        public decimal Ilosc
        {
            get { return _ilosc; }
            set { _ilosc = value; 
                WysliPowiadomienie("Ilosc"); 
                WysliPowiadomienie("Wartosc"); 
                WysliPowiadomienie(_referencjaDoFaktury, "WartoscFaktury"); }
        }

        private decimal _cena;
        public decimal Cena
        {
            get { return _cena; }
            set { _cena = value; 
                WysliPowiadomienie("Cena"); 
                WysliPowiadomienie("Wartosc");
                WysliPowiadomienie(_referencjaDoFaktury, "WartoscFaktury");
            }
        }

        public decimal Wartosc
        {
            get { return Ilosc * Cena; }
        }

        /*
        public override bool IsValid()
        {
            return Produkt.Length > 2 
                && Cena > 10 
                && Ilosc > 1;
        }
        */
        public override string this[string columnName]
        {
            get
            {
                string ret = null;

                switch (columnName)
                {
                    case "Produkt":
                        if (Produkt.Length < 3) ret = "Dlugosc musi byc wieksza od 2 znakow";
                        break;

                    case "Ilosc":
                        if (Ilosc < 5) ret = "Ilosc produktow nie moze byc mniejsza niz 5";
                        break;

                    case "Cena":
                        if (Cena < 10) ret = "Cena produktu nie moze byc mniejsza od 10";
                        break;
                }

                if (string.IsNullOrEmpty(ret))
                {
                    //brak bledu
                    if (_bledyWalidacji.ContainsKey(columnName))
                    {
                        _bledyWalidacji.Remove(columnName);
                    }
                }
                else
                {
                    //mamy blad
                    if (!_bledyWalidacji.ContainsKey(columnName)) _bledyWalidacji.Add(columnName, "");

                    _bledyWalidacji[columnName] = ret;
                }

                return ret;
            }
        }
    }
}
