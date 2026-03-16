using System;
using System.Collections.Generic;
using System.Text;

namespace lab2.Tasks
{
    internal class Licz
    {
        private int value;
        public Licz(int value) {
            this.value = value;
        }

        public void Dodaj(int liczba)
        {
            this.value += liczba;
        }
        public void Odejmij(int liczba)
        {
            this.value -= liczba;
        }

        public int Value{
            get{ return this.value; }
            set { this.value = value; }
        }
    }
}
