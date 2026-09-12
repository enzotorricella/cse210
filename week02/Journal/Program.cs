using System;

class Program
{
    static void Main(string[] args)
    {
        // Reference: https://byui-cse.github.io/cse210-ww-course/week02/develop.html
        // EXCEEDING REQUIREMENTS:
        // I added a mood field to each journal entry.
        // The user's mood is stored, saved to the file,
        // loaded from the file, and displayed with each entry.
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    Console.Write("Mood: ");
                    string mood = Console.ReadLine();
                    theJournal.AddEntry(new Entry(DateTime.Now.ToShortDateString(), prompt, response, mood));
                    break;
                case "2":
                    theJournal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter the filename: ");
                    theJournal.SaveToFile(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter the filename: ");
                    theJournal.LoadFromFile(Console.ReadLine());
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}