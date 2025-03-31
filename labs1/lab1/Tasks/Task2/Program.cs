using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        public static void Run()
        {
            IUserInterface ui = new ConsoleInterface();
            SportsmanManager manager = new SportsmanManager(ui);

            manager.InputSportsmen();
            manager.DisplayAllSportsmen();
            manager.CountSportsmenInRange();
            manager.DisplayYoungSportsmen();
        }
    }
}