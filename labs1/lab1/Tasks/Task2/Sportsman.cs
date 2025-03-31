using System;
using System.Linq;

namespace Task2
{
    class Sportsman
    {
        private string surname;
        private int birthYear;
        private double[] results;

        public Sportsman(string surname, int birthYear, double[] results)
        {
            this.surname = surname;
            this.birthYear = birthYear;
            this.results = results;
        }

        public string Surname => surname;
        public int BirthYear => birthYear;
        public double AverageResult => results.Average();

        public double this[int index]
        {
            get => results[index];
            set => results[index] = value;
        }

        public override string ToString()
        {
            return $"{surname} ({birthYear}) - Result: {AverageResult:F2}";
        }
    }
}
