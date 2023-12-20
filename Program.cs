using System;
using System.Collections.Generic;
using System.Linq;

namespace ChipSecuritySystem
{
    internal class Program
    {
        private static readonly List<ColorChip> Chips = new List<ColorChip>();
        private static readonly Random Rand = new Random();

        private static void Main()
        {
            Console.Clear();
            Console.WriteLine("Enter how many chips you would like to generate.");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || (option < 2))
            {
                Console.WriteLine("Invalid input. Please enter a number greater than 2.");
            }
            
            GenerateRandomChips(option);

            Console.WriteLine("\nYour Chips\n----------\n");

            foreach (var chip in Chips)
            {
                Console.WriteLine("[" + chip + "]");
            }
            Console.WriteLine();
            try
            {
                PathFinder pathFinder = new PathFinder(Chips);

                Color startColor = Color.Blue;
                Color endColor = Color.Green;

                List<ColorChip> longestPath = pathFinder.FindLongestPath(startColor, endColor);
                Console.WriteLine("Longest Path:");
                foreach (var chip in longestPath)
                {
                    Console.WriteLine($"{chip.StartColor} -> {chip.EndColor}");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine(); // stop to see answer
        }

        private static void GenerateRandomChips(int n)
        {
            for (var i = 0; i < n; i++)
            {
                var startColor = (Color)Rand.Next(0, 6);
                var endColor = (Color)Rand.Next(0, 6);
                Chips.Add(new ColorChip(startColor, endColor));
            }
        }
    }
}