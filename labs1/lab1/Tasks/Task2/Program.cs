namespace Task2
{
    public static class Program
    {
        public static void Run()
        {
            var ui = new ConsoleInterface();
            var manager = new SportsmanManager(ui);

            manager.InputSportsmen();
            manager.DisplayAllSportsmen();
            manager.CountSportsmenInRange();
            manager.DisplayYoungSportsmen();
        }
    }
}