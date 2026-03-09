using System;
using System.Collections.Generic;
using System.Text;

namespace lab1.Task1
{
    internal class TaskLab
    {
        /// <summary>
        /// Metoda urushomienia dla zadań
        /// </summary>
        /// <remarks>
        /// autor: Diana Lobas
        /// data: 02.03.2026
        /// środowisko: .net10
        /// </remarks>  
        public void Run()
        {
            int numer = inputInt("Podaj numer zadania: ");
            if (numer == 1)
            {
                rownanieKW();
            }
            else if (numer == 2)
            {
                obliczenie10liczb();
            }
            else if (numer == 3)
            {
                show20Numb();
            }
            else if (numer == 4) 
            {
                negativeNumberStop();
            }
            else if (numer == 5)
            {
                insertionSort();
            }
            else
            {
                Console.WriteLine("Nie ma zadania po tym numerem");
            }    
            
        }
        ///<summary>
        ///pozostałe metody prywatne dla rozwiązań zadań
        ///Metoda obliczająca wyróżnik delta i pierwiastki trójmianu kwadratowego
        /// </summary>

        private void rownanieKW()
        {
            Console.WriteLine("Rozwiązanie równania kwadratowego: ax^2 + bx + c = 0");

            double a = inputDouble("Podaj współczynnik a: ");
            double b = inputDouble("Podaj współczynnik b: ");
            double c = inputDouble("Podaj współczynnik c: ");

            if (a == 0)
            {
                Console.WriteLine("To nie jest równaie kwadratowe");
            }

            double delta = Math.Pow(b, 2) - (4 - a * c);

            if (delta > 0)
            {
                double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b + Math.Sqrt(delta)) / (2 * a);

                Console.WriteLine($"Równanie ma dwa pierwiastki rzeczywiste\nx1 = {x1:F2}; x2 = {x2:F2}"); // F2 - wyświetlenie liczby do 2 miejsc
            }
            else if (delta == 0)
            {
                double x = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"x = {x:F2}");
            }
            else
            {
                Console.WriteLine("Nie ma rozwiązanie w liczbach reczywistych");
            }
        }

        ///<summary>
        ///Metoda która pobiera string usera i wykonuje konwersje na double. Wymusza poprawne podanie liczby
        /// </summary>
        private double inputDouble(string prompt)
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
        private int inputInt(string prompt)
        {
            int liczba;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if(int.TryParse(input, out liczba)){
                    return liczba;
                }
                Console.WriteLine("Błędna wartość, podaj poprawną liczbę!");
            }
        }

        ///<summary>
        ///Metoda która umożliwia wprowadzanie 10-ciu liczb i oblicznia ich sumy, średniej, iloczyn, min i max   
        /// </summary>
        private void obliczenie10liczb()
        {
            double[] liczby = new double[10];
            double suma = 0;
            double iloczyn = 1;

            for (int i = 0; i < 10; i++)
            {
                double elem = inputDouble("Podaj liczbę " + (i+1) + ": ");
                liczby[i] = elem;
                suma += elem;
                iloczyn *= elem;
            }
            double min = Math.Min(liczby[0], liczby[9]);
            double max = Math.Max(liczby[0], liczby[9]);
            Console.WriteLine($"Suma: {suma}, Średnia: {suma / 10}, Iloczyn: {iloczyn}, Min: {min}, Max: {max}");
        }

        ///<summary>
        ///Metoda wyświetlająca liczby od 20-0, z wyłączeniem liczb {2,6,9,15,19}. 
        /// </summary>
        
        private void show20Numb()
        {
            for (int i = 20; i > 0; i--)
            {
                if (i == 2 || i == 6 || i == 9 || i == 15 || i == 19)
                {
                    continue;
                } else
                {
                    Console.WriteLine(i);
                }
            }
        }

        ///<summary>
        ///Metoda, która w nieskończoność pyta użytkownika o liczby całkowite. Ona się zatrzymuje, gdy użytkownik wprowadzi liczbę mniejszą od zera.
        /// </summary>
        private void negativeNumberStop()
        {
            while (true)
            {
                double liczba = inputDouble("Podaj liczbę: ");
                if (liczba < 0)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Metoda umożliwiająca wprowadzanie n liczb oraz sortuje te liczby metodą bąbelkową lub wstawiania. (Od najmniejszego do największego)
        /// </summary>

        private void insertionSort()
        {
            int n = inputInt("Podaj liczbę n: ");
            double[] liczby = new double[n];

            for (int i = 0; i < n; i++)
            {
                double elem = inputDouble("Podaj liczbę " + (i + 1) + ": ");
                //double elem = LosujLiczbeOdUzytkownika();
                liczby[i] = elem;
            }
            
            for (int i = 0; i < n; i++)    /// 2, 3, 8, 9, 6
            {   
                double current = liczby[i];
                int j = i - 1;

                // Przesuwanie elementów większych od klucza
                while (j >= 0 && liczby[j] > current)
                {   
                    liczby[j+1] = liczby[j];
                    j--;   
                }
                liczby[j+1] = current;
                
            }
             for (int i = 0; i < n; i++)
             {
                Console.Write($"{liczby[i]} ");
             }
        }

        /// <summary>
        /// Metoda umożliwiająca wprowadzanie min i max. Zwraca liczbe typu double, ktra znajduje się w tym przedziale.
        /// </summary>
        private double LosujLiczbeOdUzytkownika()
        {
            Console.Write("Podaj dolną granicę przedziału (min): ");
            double min = Convert.ToDouble(Console.ReadLine());
            Console.Write("Podaj górną granicę przedziału (max): ");
            double max = Convert.ToDouble(Console.ReadLine());
            if (min > max)
            {
                double temp = min;
                min = max;
                max = temp;
                Console.WriteLine($"Zamieniono granice. Nowy przedział: [{min}, {max}]");
            }
            Random rng = new Random();
            double wynik = min + rng.NextDouble() * (max - min);
            Console.WriteLine($"Wylosowana liczba: {wynik:F2}");
            return wynik;
        }

        
    }
}
