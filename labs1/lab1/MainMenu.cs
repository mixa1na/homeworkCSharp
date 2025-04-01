using System;

public static class MainMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.WriteLine("Choose task:\n1 - Task 1\n2 - Task 2\n0 - Exit\nYour choice: ");
            switch (Console.ReadLine())
            {
                case "1": Task1.Program.Run(); break;
                case "2": Task2.Program.Run(); break;
                case "0": Console.WriteLine("Exiting..."); return;
                default: Console.WriteLine("Invalid! Enter 1, 2 or 0"); break;
            }
        }
    }
}