using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Tasks
{
    public class Reader : Person
    {
        public Book[] booksList  = new Book[10];
        public Reader(string firstName, string lastName, int age, Book[] bookslist) : base(firstName, lastName, age)
        {
            this.booksList = bookslist;
        }
        public virtual void DisplayInformation()
        {
            base.DisplayInformation();
            ViewBooks();
            /*if (booksList == null || booksList.Length == 0)
            {
                Console.WriteLine("Brak książek.");
                return;
            }
            Console.WriteLine("Lista przeczytanych książek:");
            foreach (Book b in booksList)
            {
                if (b == null) continue;
                b.DisplayInformation();
            }
            Console.WriteLine();*/
        }
        public void ViewBooks()
        {
            if (booksList == null || booksList.Length == 0)
            {
                Console.WriteLine("Brak książek.");
                return;
            }
            Console.Write("Lista przeczytanych książek: ");
            foreach (Book b in booksList)
            {
                if (b == null) continue;
                Console.Write($"{b.Title}, ");
            }
            Console.WriteLine();

        }

    }
}
