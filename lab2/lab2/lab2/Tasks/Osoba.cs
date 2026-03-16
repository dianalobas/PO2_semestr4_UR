using System;
using System.Collections.Generic;
using System.Text;

namespace lab2.Tasks
{
    internal class Osoba
    {
        public string imie;
        public string nazwisko;
        public int wiek;
        public Osoba(string imie, string nazwisko, int wiek)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
        }
        public string Imie
        {
            get
            {

                return this.imie;
            }
            set
            {
                if (string.IsNullOrEmpty(this.imie) || this.imie.Length < 2)
                {
                    this.imie = null;
                }
                else
                {
                    this.imie = value;
                }

            }
        }
        public string Nazwisko
        {
            get
            {
                
                return this.nazwisko;
            }
            set
            {
                if (string.IsNullOrEmpty(this.nazwisko) || this.nazwisko.Length < 2)
                {
                    this.nazwisko = null;
                }else
                {
                    this.nazwisko = value;
                }
                
            }
        }
        public int Wiek
        {
            get { return this.wiek; }
            set
            {
                if (this.wiek >= 0)
                {
                    this.wiek = value;
                }
                else
                {
                    this.wiek = 0;
                }
            }
        }
        public void WyswietlInformacje(){
            Console.WriteLine($"Imię: {this.imie}, Nazwisko: {this.nazwisko}, Wiek: {this.wiek}");
        }
    }
}
