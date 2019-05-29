using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Faktury.Model
{
    public class MojaKolekcja<M> : ObservableCollection<M> where M : KlasaBazowa
    {
        public bool CzyJestJakisZmienionyElement()
        {
            foreach (var element in this)
            {
                if (element.CzyZmieniony) return true;
            }
            
            return false;
        }
    }
}
