using System;

// EXCEEDS REQUIREMENTS (5 pts):
// I added a Leveling system inside GoalManager.DisplayPlayerInfo() that automatically
// calculates the user's level based on their total score (1 Level per 1000 points).
// The level is updated dynamically whenever points are earned or loaded from a file.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}