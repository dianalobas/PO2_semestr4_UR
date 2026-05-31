using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Tasks
{
    public class Book
    {
        protected string title; 
        public string Title 
        {
            get { return title; }
            protected set { title = value; }
        }

        protected string Author;
        protected int PublicationYear;
        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }
        public void DisplayInformation()
        {
            Console.WriteLine($"Tytuł: {Title}, Autor: {Author}, Rok publikacji: {PublicationYear}");
        }
    }
}
