using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressVerwaltungProjekt
{
    public class ErstellungsDatumSortieren :IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int compareDate = x.ErstellungsDatum.CompareTo(y.ErstellungsDatum);

            return compareDate;
        }
    }
}
