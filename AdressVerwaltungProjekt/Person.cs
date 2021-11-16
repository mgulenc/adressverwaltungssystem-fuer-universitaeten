using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdressVerwaltungProjekt
{
    [XmlInclude(typeof(Mitarbeiter)), XmlInclude(typeof(Student))]

    public abstract class Person : IComparable
    {
        private string _Anrede;
        private string _Vorname;
        private string _Nachname;
        private string _Telefon;
        private Adresse _Adresse;
        private string _Email;
        private string _Geburtsdatum;
        private DateTime _ErstellungsDatum;

        public Person(string anrede, string vorname, string nachname,string geburtsdatum, string telefon, Adresse adresse, string email)
        {
            Anrede = anrede;
            Vorname = vorname;
            Nachname = nachname;
            Geburtsdatum = geburtsdatum;
            Telefon = telefon;
            _Adresse = adresse;
            Email = email;
            ErstellungsDatum = DateTime.Now; // Das Erstellungsdatum soll bei der Erzeugung des Datensatzes automatisch gesetzt werden.
        }
        public string Anrede
        {
            get { return _Anrede; }
            set { _Anrede = value; }
        }
        public string Vorname
        {
            get { return _Vorname; }
            set { _Vorname = value; }
        }
        public string Nachname
        {
            get { return _Nachname; }
            set { _Nachname = value; }
        }
        public string Geburtsdatum
        {
            get { return _Geburtsdatum; }
            set { _Geburtsdatum = value; }
        }
        public string Telefon
        {
            get { return _Telefon; }
            set { _Telefon = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public DateTime ErstellungsDatum
        {
            get { return _ErstellungsDatum; }
            set { _ErstellungsDatum = value; }
        }
        public Adresse GetAdresse()
        {
            return _Adresse;
        }
        public void SetAdresse(Adresse NewAdresse)
        {
            _Adresse = NewAdresse;
        }
 
        public int CompareTo(object obj)
        {
            Person meineVergleichendenPersonen = (Person)obj;
            if (this.Nachname.ToLower()[0] < meineVergleichendenPersonen.Nachname.ToLower()[0])
            {
                return -1;
            }
            else if (this.Nachname.ToLower()[0] > meineVergleichendenPersonen.Nachname.ToLower()[0])
            {
                return 1;
            }
            else return 0;
        }

    }
}
