public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            int remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            Console.Write("\nBreathe in... ");
            ShowCountdown(Math.Min(4, remainingSeconds));

            remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            if (remainingSeconds <= 0)
            {
                break;
            }

            Console.Write("\nBreathe out... ");
            ShowCountdown(Math.Min(6, remainingSeconds));
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
