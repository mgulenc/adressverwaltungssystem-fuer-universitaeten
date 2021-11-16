using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressVerwaltungProjekt
{
    public class Student : Person
    {
        private int _Matrikelnummer;
        private int _Fachsemester;
        private string _Studiengang;
        private int _Fachbereich;
        private bool _Bafoeg;

        public Student(string anrede, string vorname, string nachname,string geburtsdatum, string telefon, Adresse adresse, string email,
                        int matrikelNummer, int fachSemester, string studiengang, int fachBereich, bool bafoeg):
                        base(anrede, vorname, nachname, geburtsdatum, telefon, adresse, email)
        {
            Matrikelnummer = matrikelNummer;
            Fachsemester = fachSemester;
            Studiengang = studiengang;
            Fachbereich = fachBereich;
            Bafoeg = bafoeg;
        }
        //Parameterloser Konstruktur um xmlSerialiser korrekt verwenden zu können. 
        public Student() : base("","","","","",null,"")
        {

        }
        public int Matrikelnummer
        {
            get { return _Matrikelnummer; }
            set { _Matrikelnummer = value; }
        }
        public int Fachsemester
        {
            get { return _Fachsemester; }
            set { _Fachsemester = value; }
        }
        public string Studiengang
        {
            get { return _Studiengang; }
            set { _Studiengang = value; }
        }
        public int Fachbereich
        {
            get { return _Fachbereich; }
            set { _Fachbereich = value; }
        }
        public bool Bafoeg
        {
            get { return _Bafoeg; }
            set { _Bafoeg = value; }
        }
        public string IsType
        {
            get { return "Studierende"; }
        }

    }
}
