using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.ObjectModel;

namespace PilkarzeMVVM.Model
{
    class Pilkarze
    {
        public ObservableCollection<Pilkarz> ListaPilkarzy { get; set; } = new ObservableCollection<Pilkarz>();
        public Pilkarze()
        {
            byte[] json = File.ReadAllBytes("Pilkarze.json");
            var readOnlySpan = new ReadOnlySpan<byte>(json);
            ListaPilkarzy = JsonSerializer.Deserialize<ObservableCollection<Pilkarz>>(readOnlySpan);
        }
        public void DodajPilkarza(string imie, string nazwisko, int wiek, int waga)
        {
            ListaPilkarzy.Add(new Pilkarz(imie, nazwisko, wiek, waga));
        }
        public void ModyfikujPilkarza(string imie, string nazwisko, int wiek, int waga, int nr)
        {
            ListaPilkarzy[nr] = new Pilkarz(imie, nazwisko, wiek, waga);
        }
        public void UsunPilkarza(int nr)
        {
            ListaPilkarzy.RemoveAt(nr);
        }
        public void Zapisz()
        {
            var opcje = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            byte[] json = JsonSerializer.SerializeToUtf8Bytes(ListaPilkarzy, opcje);
            File.WriteAllBytes("Pilkarze.json", json);
        }
    }
}

