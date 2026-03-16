using lab2.Tasks;

/// <summary>
/// Lab 2
/// </summary>
/// <remarks>
/// autor: Diana Lobas
/// data: 16.03.2026
/// środowisko: .net10
/// </remarks> 

///<summary>
///Zadanie 1: Utwórz klasę Osoba z polami imie, nazwisko i wiek. Dodaj konstruktor do 
///inicjalizacji tych pól oraz metodę WyswietlInformacje(), która wyświetla informacje o osobie.
/// </summary>

Osoba osoba = new Osoba("Diana", "Lobas", 19);
osoba.WyswietlInformacje();
Console.WriteLine("\n");


///<summary>
///Zadanie 2: Utwórz klasę BankAccount (z polami saldo i wlasciciel), która będzie symulowała konto bankowe.
/// </summary>

BankAccount konto = new BankAccount(1000, "Diana");
konto.Wplata(500);
konto.WyswietlijInformacje();
Console.WriteLine("\n");


///<summary>
/// Zadanie 3: Utwórz klasę Student z polami imie, nazwisko i oceny (tablica float). 
/// </summary>

Student student = new Student("Diana", "Lobas", new float[] {4.5f, 3.0f, 5.0f});
Console.WriteLine(student.SredniaOcen());
student.DodajOcene(4.8f);
Console.WriteLine(student.SredniaOcen() + "\n");


///<summary>
/// Zadanie 4: Utwórz klasę Licz z polem value (int) i metodami Dodaj(int liczba) oraz 
/// Odejmij(int liczba), które będą odpowiednio dodawać lub odejmować podaną liczbę od pola value.
/// </summary>

Licz licz1 = new Licz(5);
Console.WriteLine("Licz1: " + licz1.Value);
licz1.Dodaj(3);
Console.WriteLine("Licz1: " + licz1.Value);

Licz licz2 = new Licz(10);
Console.WriteLine("Licz2: " + licz2.Value);
licz2.Odejmij(4);
Console.WriteLine("Licz2: " + licz2.Value + "\n");


///<summary>
/// Zadanie 5: Utwórz klasę Kalkulator z metodami Dodaj(int a, int b), Odejmij(int a, int b),
/// </summary>

Sumator sumator = new Sumator(new int[] {2, 4, 6, 7, 6});
Console.WriteLine(sumator.Suma());
Console.WriteLine(sumator.IleElementow());
sumator.WypiszWszstko();
Console.WriteLine("\n"+ sumator.Liczby[0]);
sumator.WypiszZakres(1, 3);  
sumator.WypiszZakres2(-1, 1); 
sumator.WypiszZakres2(-2, 9);
sumator.WypiszZakres2(1, 4); 