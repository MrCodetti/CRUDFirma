using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDFirma.Classes
{
    class Kunde
    {
        private int kundeID;
        private string firma;
        private string titel;
        private string anrede;
        private string vorname;
        private string nachname;
        private string strasse;
        private string telefon;
        private string mail;
        private string plz;
        private string ort;
        private string land;

        public Kunde(int kundeID, string firma, string titel, string anrede,
                    string vorname, string nachname, string strasse, string telefon,
                    string mail, string plz, string ort, string land)
        {
            this.kundeID = kundeID;
            this.firma = firma;
            this.titel = titel;
            this.anrede = anrede;
            this.vorname = vorname;
            this.nachname = nachname;
            this.strasse = strasse;
            this.telefon = telefon;
            this.mail = mail;
            this.plz = plz;
            this.ort = ort;
            this.land = land;
        }

        public int KundeID { get { return (this.kundeID); } }
        public string Firma { get { return (this.firma); } }
        public string Titel { get { return (this.titel); } }
        public string Anrede { get { return (this.anrede); } }
        public string Vorname { get { return (this.vorname); } }
        public string Nachname { get { return (this.nachname); } }
        public string Strasse { get { return (this.strasse); } }
        public string Telefon { get { return (this.telefon); } }
        public string Mail { get { return (this.mail); } }
        public string Plz { get { return (this.plz); } }
        public string Ort { get { return (this.ort); } }
        public string Land { get { return (this.land); } }
    }
}
