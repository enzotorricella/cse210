public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public abstract void Run();

    protected int GetDuration()
    {
        return _duration;
    }

    protected void DisplayStartingMessage()
    {
        ClearScreen();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = ReadPositiveDuration();
        ClearScreen();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[frameIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frameIndex = (frameIndex + 1) % frames.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int number = seconds; number > 0; number--)
        {
            string display = number.ToString();
            Console.Write(display);
            Thread.Sleep(1000);
            Console.Write(new string('\b', display.Length));
            Console.Write(new string(' ', display.Length));
            Console.Write(new string('\b', display.Length));
        }
    }

    protected void ClearScreen()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }

    private int ReadPositiveDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string response = Console.ReadLine();

            if (int.TryParse(response, out int duration) && duration > 0)
            {
                return duration;
            }

            Console.WriteLine("Please enter a positive whole number.");
        }
    }
}
