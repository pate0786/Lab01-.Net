using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            String choice = "y";
            IList<string> words = new List<string>();
            Program program = new Program();
            while (true)
            {
                Console.WriteLine("1 - Import Words from File\n" +
                                  "2 - Bubble Sort words\n" +
                                  "3 - LINQ / Lambda sort words\n" +
                                  "4 - Count the Distinct Words\n" +
                                  "5 - Take the first 10 words\n" +
                                  "6 - Get the number of words that start with 'j' and display the count\n" +
                                  "7 - Get and display of words that end with 'd' and display the count\n" +
                                  "8 - Get and display of words that are greater than 4 characters long, and display the count\n" +
                                  "9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count\n" +
                                  "x – Exit");
                choice = Console.ReadLine();
                choice = choice.Trim().ToLower();
                var stopWatch = new Stopwatch();

                switch (choice)
                {
                    case "1":
                        words = program.Import();
                        Console.WriteLine("Words count = " + words.Count);
                        break;
                    case "2":
                        stopWatch.Start();
                        words = program.BubbleSort(words);
                        stopWatch.Stop();
                        Console.WriteLine("Time taken in milli seconds = " + stopWatch.ElapsedMilliseconds);
                        break;
                    case "3":
                        stopWatch.Start();
                        var orderedList = from word in words
                                          orderby word
                                          select word;
                        words = orderedList.ToList();
                        stopWatch.Stop();
                        Console.WriteLine("Time taken in milli seconds = " + stopWatch.ElapsedMilliseconds);
                        break;
                    case "4":
                        int uniqueWordsCount = words.Distinct().Count();
                        Console.WriteLine("Count of distinct words = " + uniqueWordsCount);
                        break;
                    case "5":
                        List<string> tenWords = words.Take(10).ToList();
                        Console.WriteLine("First 10 words: ");
                        foreach (string w in tenWords)
                        {
                            Console.WriteLine(w);
                        }
                        break;
                    case "6":
                        var unnamedList = from word in words where word.StartsWith("j") select word;
                        Console.WriteLine("Count of words starts with j =  " + unnamedList.Count());
                        break;
                    case "7":
                        var unnamedList2 = from word in words where word.EndsWith("d") select word;
                        foreach (string w in unnamedList2)
                        {
                            Console.WriteLine(w);
                        }
                        Console.WriteLine("Count of words ends with d = " + unnamedList2.Count());
                        break;
                    case "8":
                        var unnamedList3 = from word in words where word.Length > 4 select word;
                        foreach (string w in unnamedList3)
                        {
                            Console.WriteLine(w);
                        }
                        int greaterThanFourCount = unnamedList3.Count();
                        Console.WriteLine("Count of words with length greater than 4 = " + greaterThanFourCount);
                        break;
                    case "9":
                        var unnamedList4 = from word in words where word.Length < 3 && word.StartsWith("a") select word;
                        foreach (string w in unnamedList4)
                        {
                            Console.WriteLine(w);
                        }
                        int ltThreeCount = unnamedList4.Count();
                        Console.WriteLine("Count of words with less than 3 length and starts with a = " + ltThreeCount);
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("You have chosen an invalid option!");
                        break;
                }
            }
        }
        //Bubble sort
        IList<string> BubbleSort(IList<string> words)
        {
            int n = words.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (words[j].CompareTo(words[j + 1]) > 0)
                    {
                        string temp = words[j];
                        words[j + 1] = temp;
                    }
            return words;
        }
        //Methods to import Words.txt
        IList<string> Import()
        {
            IList<string> words = new List<string>();
            using (StreamReader file = new StreamReader("Words.txt"))
            {
                string line;
                line = file.ReadLine();
                while (line != null)
                {
                    words.Add(line);
                    line = file.ReadLine();
                }
                file.Close();
            }
            return words;
        }
    }
}
    



