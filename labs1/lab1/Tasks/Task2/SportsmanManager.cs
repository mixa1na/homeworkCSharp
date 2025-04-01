using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class SportsmanManager
    {
        private readonly List<Sportsman> _sportsmen = new();
        private readonly IUserInterface _ui;

        public SportsmanManager(IUserInterface ui)
        {
            _ui = ui;
        }

        public void InputSportsmen()
        {
            int count = _ui.GetStrictlyPositiveInteger("Enter number of sportsmen:");

            for (int i = 0; i < count; i++)
            {
                _ui.ShowMessage($"Sportsman {i + 1}");
                string surname = _ui.GetNonEmptyString("Enter surname:");
                int birthYear = _ui.GetStrictlyPositiveInteger("Enter birth year:");
                double[] results = _ui.GetDoubleArray("Enter space-separated results :");

                _sportsmen.Add(new Sportsman(surname, birthYear, results));
            }
        }

        public void DisplayAllSportsmen()
        {
            _ui.ShowMessage("All sportsmen sorted by average:");
            foreach (var s in _sportsmen.OrderBy(s => s.AverageResult))
            {
                _ui.ShowMessage(s.ToString());
            }
        }

        public void CountSportsmenInRange()
        {
            double min = _ui.GetDouble("Enter minimum result:");
            double max = _ui.GetDouble("Enter maximum result:");

            _ui.ShowMessage("Sportsmen in result range by birth year:");
            foreach (var group in _sportsmen
                .Where(s => s.AverageResult >= min && s.AverageResult <= max)
                .GroupBy(s => s.BirthYear)
                .OrderBy(g => g.Key))
            {
                _ui.ShowMessage($"{group.Key}: {group.Count()} sportsmen");
            }
        }

        public void DisplayYoungSportsmen()
        {
            int maxAge = _ui.GetStrictlyPositiveInteger("Enter maximum age:");
            int currentYear = DateTime.Now.Year;
            var young = _sportsmen.Where(s => currentYear - s.BirthYear < maxAge).ToList();

            if (young.Count == 0)
            {
                _ui.ShowMessage("No young sportsmen found.");
            }
            else
            {
                _ui.ShowMessage($"Young sportsmen (<{maxAge} years):");
                foreach (var s in young)
                {
                    _ui.ShowMessage(s.ToString());
                }
            }
        }
    }
}