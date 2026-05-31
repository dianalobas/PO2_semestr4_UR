using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Tasks
{
    internal class BaseFunctions
    {
        public int inputInt(string prompt)
        {
            int liczba;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out liczba))
                {
                    return liczba;
                }
                Console.WriteLine("Błędna wartość, podaj poprawną liczbę!");
            }
        }
        public double inputDouble(string prompt)
        {
            double liczba;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out liczba))
                {
                    return liczba;
                }
                Console.WriteLine("Błędna wartość, podaj poprawną liczbę!");
            }
        }
    }
}
