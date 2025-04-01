using System;
using System.Linq;

namespace Task2
{
    public class Sportsman
    {
        public string Surname { get; }
        public int BirthYear { get; }
        public double[] Results { get; }
        public double AverageResult => Results.Average();

        public Sportsman(string surname, int birthYear, double[] results)
        {
            Surname = surname;
            BirthYear = birthYear;
            Results = results;
        }

        public override string ToString()
        {
            return $"{Surname} ({BirthYear}) - Results: {string.Join(", ", Results)} (Avg: {AverageResult:F2})";
        }
    }
}