using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdressVerwaltungProjekt
{

    [XmlInclude(typeof(Adresse))]
    public class Adresse
    {
        private string _Strasse;
        private string _Hausnummer;
        private int _PLZ;
        private string _Stadt;
        private string _Land;
   
        public Adresse(string strasse, string hausnummer, int pLZ, string stadt, string land)
        {
            Strasse = strasse;
            Hausnummer = hausnummer;
            PLZ = pLZ;
            Stadt = stadt;
            Land = land;
        }
        public string Strasse
        {
            get { return _Strasse; }
            set { _Strasse = value; }
        }
        public string Hausnummer
        {
            get { return _Hausnummer; }
            set { _Hausnummer = value; }
        }
        public int PLZ
        {
            get { return _PLZ; }
            set { _PLZ = value; }
        }
        public string Stadt
        {
            get { return _Stadt; }
            set { _Stadt = value; }
        }
        public string Land
        {
            get { return _Land; }
            set { _Land = value; }
        }
    }
}
