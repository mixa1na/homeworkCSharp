using System;

class MainMenu
{
    public static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose a task:");
            Console.WriteLine("1 - Task 1");
            Console.WriteLine("2 - Task 2");
            Console.WriteLine("0 - Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1.Program.Run();
                    break;
                case "2":
                    Task2.Program.Run();
                    break;
                case "0":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please enter 1, 2 or 0.");
                    break;
            }
        }
    }
}
