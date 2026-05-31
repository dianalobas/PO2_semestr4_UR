using System;
using System.Collections.Generic;
using System.Text;

namespace lab2.Tasks
{
    internal class Sumator
    {
        private int[] liczby;

        public Sumator(int[] liczby)
        {
            this.liczby = liczby;
        }
        public int[] Liczby{
            get { return this.liczby; }
            set { this.liczby = value; }
        }
        public int Suma()
        {
            int sum = 0;
            for (int i = 0; i < liczby.Length; i++)
            {
                sum += liczby[i];
            }
            return sum;
        }

        public float SumaPodziel2()
        {
            return Suma()/2;
        }

        public int IleElementow()
        {
            return liczby.Length;
        }

        public void WypiszWszstko()
        {
            for (int i = 0; i < liczby.Length; i++)
            {
                Console.Write(liczby[i] + ", ");
            }
        }
        public void WypiszZakres(int lowIndex, int highIndex)
        {
            if(lowIndex >= 0 && highIndex <= liczby.Length)
            {
                for (int i = lowIndex; i < highIndex + 1; i++)
                {
                    Console.Write(liczby[i] + ", ");
                }
            } else
            {
                Console.WriteLine("Podane indeksy są po za zakresem!");
            }
            Console.WriteLine("\n");

        }
        public void WypiszZakres2(int lowIndex, int highIndex)
        {
            int temp;
            int temp2;
            if (lowIndex >= 0) { temp = lowIndex; }  // 
            else { temp = 0; }

            if (highIndex >= liczby.Length-1) { temp2 = liczby.Length-1; }
            else { temp2 =  highIndex; }

            for (int i = temp; i <= temp2; i++)
            {
                Console.Write(liczby[i] + ", ");
            }
            Console.WriteLine("\n");
        }
    }
}
