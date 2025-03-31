using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class SportsmanManager
    {
        private List<Sportsman> sportsmen;
        private IUserInterface ui;

        public SportsmanManager(IUserInterface userInterface)
        {
            this.ui = userInterface;
            sportsmen = new List<Sportsman>();
        }

        public void InputSportsmen()
        {
            int count = ui.GetIntegerInput("Enter the number of sportsmen:");

            for (int i = 0; i < count; i++)
            {
                ui.ShowMessage($"Sportsman {i + 1}:");

                string surname;
                do
                {
                    surname = ui.GetStringInput("Enter surname:");
                } while (string.IsNullOrWhiteSpace(surname));

                int birthYear = ui.GetIntegerInput("Enter birth year:");
                double[] results = ui.GetDoubleArray("Enter competition results separated by space:");

                sportsmen.Add(new Sportsman(surname, birthYear, results));
            }
        }

        public void DisplayAllSportsmen()
        {
            ui.ShowMessage("\nList of sportsmen sorted by average result:");
            var sorted = sportsmen.OrderBy(s => s.AverageResult).ToList();

            foreach (var s in sorted)
                ui.ShowMessage(s.ToString());
        }

        public void CountSportsmenInRange()
        {
            double min = ui.GetDoubleInput("Enter minimum result:");
            double max = ui.GetDoubleInput("Enter maximum result:");

            var grouped = sportsmen
                .GroupBy(s => s.BirthYear)
                .Select(g => new
                {
                    Year = g.Key,
                    Count = g.Count(s => s.AverageResult >= min && s.AverageResult <= max)
                });

            ui.ShowMessage("\nNumber of sportsmen in range by birth year:");
            foreach (var g in grouped)
                ui.ShowMessage($"Year {g.Year}: {g.Count} sportsmen");
        }

        public void DisplayYoungSportsmen()
        {
            int ageLimit = ui.GetIntegerInput("Enter max age:");
            int currentYear = DateTime.Now.Year;

            var youngSportsmen = sportsmen.Where(s => (currentYear - s.BirthYear) < ageLimit).ToList();

            if (youngSportsmen.Any())
            {
                ui.ShowMessage("\nYoung sportsmen:");
                foreach (var s in youngSportsmen)
                    ui.ShowMessage(s.ToString());
            }
            else
            {
                ui.ShowMessage("No sportsmen younger than the specified age.");
            }
        }
    }
}
