using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkarzeMVVM.Model
{
    class Pilkarz
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public int Waga { get; set; }
        public Pilkarz() { }
        public Pilkarz(string imie, string nazwisko, int wiek, int waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }
        public override string ToString()
        {
            return $"Imię: {Imie} Nazwisko: {Nazwisko} Wiek: {Wiek} Waga: {Waga}";
        }
    }
}

