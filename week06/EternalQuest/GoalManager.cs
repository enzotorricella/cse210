using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        
        // REQUISITO DE CREATIVIDAD (5 pts extra): Sistema de Niveles/Rangos
        int level = (_score / 1000) + 1;
        Console.WriteLine($"Current Level: Level {level}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found. Create one first!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = ReadIntInput("Points: ");

        if (typeChoice != "1" && typeChoice != "2" && typeChoice != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        if (typeChoice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeChoice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = ReadIntInput("Target completions: ");

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = ReadIntInput("Completion bonus: ");

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

private int ReadIntInput(string prompt)
{
    int value;
    Console.Write(prompt);
    while (!int.TryParse(Console.ReadLine(), out value))
    {
        Console.Write("Por favor, ingresa un número entero válido: ");
    }
    return value;
}

    public void RecordEvent()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create one first.");
            return;
        }

        int goalIndex = ReadIntInput("Which goal did you accomplish? ") - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            
            // Verificamos el estado antes de registrar
            if (goal.IsComplete())
            {
                Console.WriteLine("This goal is already completed!");
                return;
            }

            goal.RecordEvent();
            int pointsEarned = goal.GetPoints();
            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Guardamos la puntuación total en la primera línea
            outputFile.WriteLine(_score);

            // Guardamos cada meta en formato de texto parseable
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0) return;

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");

            string goalType = parts[0];
            string[] data = parts[1].Split(",");

            if (goalType == "SimpleGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                bool isComplete = bool.Parse(data[3]);

                SimpleGoal sg = new SimpleGoal(name, description, points, isComplete);
                _goals.Add(sg);
            }
            else if (goalType == "EternalGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);

                EternalGoal eg = new EternalGoal(name, description, points);
                _goals.Add(eg);
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                int bonus = int.Parse(data[3]);
                int target = int.Parse(data[4]);
                int amountCompleted = int.Parse(data[5]);

                ChecklistGoal cg = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                _goals.Add(cg);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}