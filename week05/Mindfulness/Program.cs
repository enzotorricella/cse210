class Program
{
    static void Main(string[] args)
    {
        // Exceeds the core requirements: the reflection activity cycles through
        // every question before repeating one, and the listing activity cycles
        // through every prompt before repeating one during the same program run.
        bool isRunning = true;

        while (isRunning)
        {
            ClearScreen();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            if (choice == null)
            {
                break;
            }

            Activity activity = null;

            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectingActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": isRunning = false; break;
                default:
                    Console.WriteLine("Please enter a number from 1 to 4.");
                    Thread.Sleep(1500);
                    break;
            }

            if (activity != null)
            {
                activity.Run();
            }
        }
    }

    private static void ClearScreen()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
}
