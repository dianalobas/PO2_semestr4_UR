using System;
using System.Collections.Generic;
using System.Text;

namespace lab2.Tasks
{
    internal class BankAccount
    {
        private int saldo;
        public string wlasciciel;

        public BankAccount(int saldo, string wlasciciel)
        {
            this.saldo = saldo;
            this.wlasciciel = wlasciciel;
        }
        public void Wplata(int kwota)
        {
            saldo += kwota;
        }
        public void Wyplata(int kwota)
        {   
            if (kwota > saldo)
            {
                saldo -= kwota;
            } else
            {
                Console.WriteLine("Nie można wypłacić więcej niż posiadane saldo.");
            }
        }
        public void WyswietlijInformacje()
        {
            Console.WriteLine($"Właściciel: {wlasciciel}, Saldo: {saldo}");
        }

    }
}
