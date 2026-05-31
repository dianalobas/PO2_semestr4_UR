using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.Tasks
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public int Age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public virtual void DisplayInformation()
        {
            Console.WriteLine($"Imię: {FirstName}, Nazwisko: {LastName}, Wiek: {Age}");
        }
    }
}
