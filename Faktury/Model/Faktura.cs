using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Faktury.Model
{
    public class Faktura : KlasaBazowa
    {
        private DateTime _dataSprzedazy = DateTime.Now;
        public DateTime DataSprzedazy
        {
            get { return _dataSprzedazy; }
            set { _dataSprzedazy = value; }
        }

        private string _klient;
        public string Klient
        {
            get { return _klient; }
            set { _klient = value; }
        }

        private string _numerFaktury;
        public string NumerFatury
        {
            get { return _numerFaktury; }
            set { _numerFaktury = value; }
        }

        private MojaKolekcja<PozycjaFatury> _pozycjeFaktury = new MojaKolekcja<PozycjaFatury>();
        public MojaKolekcja<PozycjaFatury> PozycjeFaktury
        {
            get { return _pozycjeFaktury; }
            set { _pozycjeFaktury = value; }
        }

        public decimal WartoscFaktury
        {
            get
            {
                decimal ret = 0;

                foreach (var pozycja in PozycjeFaktury)
                {
                    ret += pozycja.Wartosc;
                }

                return ret;
            }
        }
    }
}
