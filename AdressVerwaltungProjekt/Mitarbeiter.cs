using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressVerwaltungProjekt
{
    public class Mitarbeiter : Person
    {
        private string _Titel;
        private string _Raum;

        public Mitarbeiter(string anrede, string vorname, string nachname,string geburtsdatum, string telefon, 
             Adresse adresse,string email,string titel, string raum) 
            :base(anrede, vorname, nachname,geburtsdatum, telefon, adresse, email)
        {
            Titel = titel;
            Raum = raum;
        }
        //Parameterloser Konstruktur um xmlSerialiser korrekt verwenden zu können. 
        public Mitarbeiter() : base("","","","","",null,"")
        {

        }
        public string Titel
        {
            get { return _Titel; }
            set { _Titel = value; }
        }
        public string Raum
        {
            get { return _Raum; }
            set { _Raum = value; }
        }
        public string IsType
        {
            get { return "Mitarbeiter"; }
        }
     
    }
}
