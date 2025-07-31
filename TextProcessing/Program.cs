using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextProcessing
{
    internal class Program
    {
        // Main program: asks for a file, reads its contents, and counts unique word occurrences.
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to the text file you want to process:");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Sorry, the file \"{filePath}\" does not exist. Exiting program.");
                return;
            }

            // Read all lines
            string[] lines = File.ReadAllLines(filePath);

            // Dictionary to hold word counts
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                // Remove punctuation and convert to lowercase
                string cleanedLine = Regex.Replace(line, @"[^\w\s]", "").ToLower();

                // Split by whitespace into words
                string[] words = cleanedLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                        wordCounts[word] = 1;
                }
            }

            Console.WriteLine("\nProcessing complete!\n");

            // Output word counts
            Console.WriteLine("Word occurrences:");
            foreach (var pair in wordCounts.OrderBy(p=>p.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            // Output number of unique words
            Console.WriteLine($"\nTotal number of unique words: {wordCounts.Count}");
            Console.ReadKey();
        }
    }
}
