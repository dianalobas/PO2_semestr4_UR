using System;
using System.Collections.Generic;
using System.Text;

namespace lab2.Tasks
{
    internal class Student
    {
        public string imie;
        public string nazwisko;
        public float[] oceny;
        public Student(string imie, string nazwisko, float[] oceny)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.oceny = oceny;
        }
        public Student(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.oceny = new float[0];
        }
        public float SredniaOcen()
        {
            float sum = 0;
            for (int i = 0; i < oceny.Length; i++)
            {
                sum += oceny[i];
            }
            return sum / oceny.Length;
        }
        public void DodajOcene(float ocena)
        {
            this.oceny = this.oceny.Append(ocena).ToArray();
        }

    }
}
