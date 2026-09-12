class PromptGenerator
{
    private readonly List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What are you grateful for today?",
        "What did you learn today?",
        "What was a challenge you faced today?",
        "What is something you want to accomplish tomorrow?"
    };

    private readonly Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}