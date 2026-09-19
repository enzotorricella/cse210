using System;
using System.Collections.Generic;

/*
EXCEEDING REQUIREMENTS / CREATIVITY DESCRIPTION:
1. Scripture Library: Instead of using a single hardcoded scripture, this program includes a library 
   (List) of multiple scriptures. Upon starting, the program randomly selects one scripture from 
   the library to present to the user.
2. Smart Random Hiding: The Scripture class specifically selects words from a list of currently 
   visible words. This prevents the program from randomly "picking" words that are already hidden, 
   ensuring consistent progress on every user input.
*/

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptureLibrary = new List<Scripture>
            {
                new Scripture(
                    new Reference("Proverbs", 3, 5, 6), 
                    "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
                ),
                new Scripture(
                    new Reference("John", 3, 16), 
                    "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
                ),
                new Scripture(
                    new Reference("Nephi", 3, 7), 
                    "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded."
                )
            };

            Random random = new Random();
            Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine();

                if (currentScripture.IsCompletelyHidden())
                {
                    break;
                }

                Console.Write("Press enter to continue or type 'quit' to finish: ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "quit")
                {
                    break;
                }

                currentScripture.HideRandomWords(3);
            }
        }
    }
}