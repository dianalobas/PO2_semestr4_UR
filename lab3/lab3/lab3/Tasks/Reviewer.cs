using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Tasks
{
    internal class Reviewer : Reader
    {
        Random rnd = new Random();
        public Reviewer(string firstName, string lastName, int age, Book[] booksList) : base(firstName, lastName, age, booksList)
        {
        }
        public override void DisplayInformation() {
            base.DisplayInformation();
            if (booksList == null || booksList.Length == 0)
            {
                Console.WriteLine("Brak książek.");
                return;
            }
            Console.WriteLine("Lista przeczytanych książek: ");
            foreach (Book b in booksList)
            {
                if (b == null) continue;
                Console.WriteLine($"{b.ToString}, {rnd.Next()}");
            }
            Console.WriteLine();

        }
    }
}
