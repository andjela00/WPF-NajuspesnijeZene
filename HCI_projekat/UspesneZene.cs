using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_projekat
{
    [Serializable]
    public class UspesneZene
    {
        private string ime;
        private string prezime;
        private int brojNagrada;
        private string slika;
        private string datum;
        private string opis;
        private string referenca;

        public UspesneZene(string ime, string prezime, int brojNagrada, string datum, string slika, string referenca)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.brojNagrada = brojNagrada;
            this.slika = slika;
            this.datum = datum;
            this.referenca = referenca;
        }

        public UspesneZene(string ime, string prezime, int brojNagrada, string datum)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.brojNagrada = brojNagrada;
            this.datum = datum;
            this.slika = "";
            this.referenca = "";
        }

        public UspesneZene() { }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public int BrojNagrada { get => brojNagrada; set => brojNagrada = value; }
        public string Slika { get => slika; set => slika = value; }
        public string Datum { get => datum; set => datum = value; }
        public string Opis { get => opis; set => opis = value; }
        public string Referenca { get => referenca; set => referenca = value; }
    }
}
