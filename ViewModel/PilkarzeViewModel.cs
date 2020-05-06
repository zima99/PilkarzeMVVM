using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PilkarzeMVVM.Model;
using PilkarzeMVVM.ViewModel.BaseClass;

namespace PilkarzeMVVM.ViewModel
{
    internal class PilkarzeViewModel : ViewModelBase
    {
        private Pilkarze _pilkarze = new Pilkarze();
        public ObservableCollection<Pilkarz> ListaPilkarzy
        {
            get => _pilkarze.ListaPilkarzy;
            set
            {
                _pilkarze.ListaPilkarzy = value;
                OnPropertyChanged(nameof(ListaPilkarzy));
            }
        }
        private string _imie = "Wprowadź imię: ";
        public string Imie
        {
            get => _imie;
            set
            {
                _imie = value;
                OnPropertyChanged(nameof(Imie));
            }
        }
        private string _nazwisko = "Wprowadź nazwisko: ";
        public string Nazwisko
        {
            get => _nazwisko;
            set
            {
                _nazwisko = value;
                OnPropertyChanged(nameof(Nazwisko));
            }
        }
        private int _wiek = 16;
        public int Wiek
        {
            get => _wiek;
            set
            {
                _wiek = value;
                OnPropertyChanged(nameof(Wiek));
            }
        }
        private int _waga = 50;
        public int Waga
        {
            get => _waga;
            set
            {
                _waga = value;
                OnPropertyChanged(nameof(Waga));
            }
        }
        private int _nr = -1;
        public int Nr
        {
            get => _nr;
            set
            {
                _nr = value;
                OnPropertyChanged(nameof(Nr));
            }
        }
        public IEnumerable<string> SuwakWiek
        {
            get
            {
                for (int i = 16; i <= 55; i++)
                {
                    yield return i.ToString();
                }
            }
        }
        private ICommand _dodaj;
        public ICommand Dodaj
        {
            get
            {
                if (_dodaj == null)
                {
                    _dodaj = new RelayCommand(x => { _pilkarze.DodajPilkarza(_imie, _nazwisko, _wiek, _waga); Reset(); }, x => (!string.IsNullOrEmpty(_imie) && !_imie.Equals("Wprowadź imię: ") && !string.IsNullOrEmpty(_nazwisko) && !_nazwisko.Equals("Wprowadź nazwisko: ")));

                }
                return _dodaj;
            }
        }
        private ICommand _modyfikuj;
        public ICommand Modyfikuj
        {
            get
            {
                if (_modyfikuj == null)
                {
                    _modyfikuj = new RelayCommand(x => { _pilkarze.ModyfikujPilkarza(_imie, _nazwisko, _wiek, _waga, _nr); Reset(); }, x => (!string.IsNullOrEmpty(_imie) && !_imie.Equals("Wprowadź imię: ") && !string.IsNullOrEmpty(_nazwisko) && !_nazwisko.Equals("Wprowadź nazwisko: ") && _nr >= 0));
                }
                return _modyfikuj;
            }
        }
        private ICommand _wczytaj;
        public ICommand Wczytaj
        {
            get
            {
                if (_wczytaj == null)
                {
                    _wczytaj = new RelayCommand(x => { Imie = ListaPilkarzy[Nr].Imie; Nazwisko = ListaPilkarzy[Nr].Nazwisko; Wiek = ListaPilkarzy[Nr].Wiek; Waga = ListaPilkarzy[Nr].Waga; }, x => _nr >= 0);
                }
                return _wczytaj;
            }
        }
        private ICommand _wyczyscImie;
        public ICommand WyczyscImie
        {
            get
            {
                if (_wyczyscImie == null)
                {
                    _wyczyscImie = new RelayCommand(x => { if (Imie.Equals("Wprowadź imię: ")) Imie = ""; });
                }
                return _wyczyscImie;
            }
        }
        private ICommand _usun;
        public ICommand Usun
        {
            get
            {
                if (_usun == null)
                {
                    _usun = new RelayCommand(x => { _pilkarze.UsunPilkarza(_nr); Reset(); }, x => _nr >= 0);

                }
                return _usun;
            }
        }
        private ICommand _wyczyscNazwisko;
        public ICommand WyczyscNazwisko
        {
            get
            {
                if (_wyczyscNazwisko == null)
                {
                    _wyczyscNazwisko = new RelayCommand(x => { if (Nazwisko.Equals("Wprowadź nazwisko: ")) Nazwisko = ""; });
                }
                return _wyczyscNazwisko;
            }
        }
        private ICommand _zapisz;
        public ICommand Zapisz
        {
            get
            {
                if (_zapisz == null)
                {
                    _zapisz = new RelayCommand(x => _pilkarze.Zapisz());
                }
                return _zapisz;
            }
        }
        private void Reset()
        {
            Imie = "Wprowadź imię: ";
            Nazwisko = "Wprowadź nazwisko: ";
            Wiek = 16;
            Waga = 50;
            Nr = -1;
        }
    }
}
