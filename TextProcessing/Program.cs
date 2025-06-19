using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextProcessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full path of the text file: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file does not exist. Exiting...");
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

            // Output word counts
            Console.WriteLine("\n Word occurrences:");
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
