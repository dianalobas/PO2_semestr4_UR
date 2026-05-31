using lab3.Tasks;

/// <summary>
/// Lab 3
/// </summary>
/// <remarks>
/// autor: Diana Lobas
/// data: 23.03.2026
/// środowisko: .net10
/// </remarks> 

///<summary>
///Zadanie 1: Utwórz klasę Osoba z polami imie, nazwisko i wiek. Dodaj konstruktor do 
///inicjalizacji tych pól oraz metodę WyswietlInformacje(), która wyświetla informacje o osobie.
/// </summary>

BaseFunctions baseFunctions = new BaseFunctions();

int numer = baseFunctions.inputInt("Podaj numer zadania: ");
if (numer == 1)
{
    /*Person osoba1 = new Person("Aleksandra", "Kowalska", 19);
    Person osoba2 = new Person("Michał", "Nowak", 18);
    osoba1.DisplayInformation();
    osoba2.DisplayInformation();
    Console.WriteLine();

    Book book1 = new Book("Wiedźmin", "Andrzej Sapkowski", 1990);
    Book book2 = new Book("Harry Potter", "J.K. Rowling", 1997);
    Book book3 = new Book("Władca Pierścieni", "J.R.R. Tolkien", 1954);
    book1.DisplayInformation(); 
    book2.DisplayInformation();
    Console.WriteLine();

    Reader reader1 = new Reader("Anna", "Wiśniewska", 25, new Book[] { book1, book2 });
    Reader reader2 = new Reader(osoba1.FirstName, osoba1.LastName, osoba1.Age, new Book[] { book1, book3 });
    reader1.DisplayInformation();
    Console.WriteLine("Reader1 książki:");
    reader1.ViewBooks();

    Console.WriteLine(); 
    reader2.DisplayInformation();

    Person reader3 = new Reader("Jan", "Kowalski", 30, new Book[] { book2, book3 });
    reader3.DisplayInformation();*/

    Reviewer reviewer1 = new Reviewer("Ewa", "Zielińska", 28, new Book[] { new Book("Lalka", "Bolesław Prus", 1890), new Book("Zbrodnia i kara", "Fiodor Dostojewski", 1866) });
}
else if (numer == 2)
{

}
/*else if (numer == 3)
{
    
}
else if (numer == 4)
{

}
else if (numer == 5)
{
    
}*/
else
{
    Console.WriteLine("Nie ma zadania po tym numerem");
}

