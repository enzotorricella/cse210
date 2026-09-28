using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video raftingVideo = new Video("Beginner Whitewater Rafting Guide", "Summit Surge", 542);
        raftingVideo.AddComment(new Comment("Maria", "The safety tips were very clear."));
        raftingVideo.AddComment(new Comment("Lucas", "This helped me prepare for my first trip."));
        raftingVideo.AddComment(new Comment("Sofia", "The river scenery looks amazing!"));
        videos.Add(raftingVideo);

        Video pastaVideo = new Video("Homemade Pasta in 15 Minutes", "Kitchen Corner", 615);
        pastaVideo.AddComment(new Comment("Diego", "I tried this recipe and it worked perfectly."));
        pastaVideo.AddComment(new Comment("Ana", "Could you make a gluten-free version?"));
        pastaVideo.AddComment(new Comment("Mateo", "Simple ingredients and great instructions."));
        videos.Add(pastaVideo);

        Video codingVideo = new Video("C# Classes Explained", "Code Step by Step", 728);
        codingVideo.AddComment(new Comment("Camila", "Now I understand constructors much better."));
        codingVideo.AddComment(new Comment("Nicolas", "The examples made abstraction easy to follow."));
        codingVideo.AddComment(new Comment("Valentina", "Please make another video about encapsulation."));
        codingVideo.AddComment(new Comment("Tomas", "Very useful for my programming course."));
        videos.Add(codingVideo);

        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetDisplayText());
            Console.WriteLine(new string('-', 60));
        }
    }
}
