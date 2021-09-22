/*COURSE : CST8359 .Net Enterprise Application Developement
 * Lab 1: Hello World! An introduction to C#
 * Author: Vandankumar Patel
 * Student Number: 040976978
 * References: Github.com
 *             www.linkedin.com/learning/linq-with-c-sharp-essential-training
 *             https://www.javatpoint.com/c-sharp-tutorial
 */


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        /*Main Method*/
        static void Main(string[] args)
        {
            String choice = "y";
            IList<string> words = new List<string>();
            //Creating a object of program class
            Program program = new Program();
            while (true)
            {
                //List of choices
                Console.WriteLine("\n--------------------------------\n"+
                                  "1 - Import Words from File\n" +
                                  "2 - Bubble Sort words\n" +
                                  "3 - LINQ / Lambda sort words\n" +
                                  "4 - Count the Distinct Words\n" +
                                  "5 - Take the first 10 words\n" +
                                  "6 - Get the number of words that start with 'j' and display the count\n" +
                                  "7 - Get and display of words that end with 'd' and display the count\n" +
                                  "8 - Get and display of words that are greater than 4 characters long, and display the count\n" +
                                  "9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count\n" +
                                  "x – Exit\n");
                choice = Console.ReadLine();
                //ToLower() coverts all words in lowercase
                choice = choice.Trim().ToLower();
                //using var as guided by professor lecture
                var stopWatch = new Stopwatch();
                //clear the console
                Console.Clear();

                switch (choice)
                {
                    //Case 1: imports total words count from Words.txt
                    case "1":
                        words = program.Import();
                        Console.WriteLine("\nWords count = " + words.Count);
                        break;

                    //Case 2 :runs Bubblesort Query- shows how much time takes
                    //this is custom algorithom which takes more time compare to LINQ sorting
                    case "2":
                        stopWatch.Start();
                        words = program.BubbleSort(words);
                        stopWatch.Stop();
                        Console.WriteLine("\nTime taken in milli seconds = " + stopWatch.ElapsedMilliseconds);
                        break;

                    //Case 3 : this case is used for LINQ sorting words
                    //LINQ is built-in function in C# and this function takes much lesser time uppon run-time
                    case "3":
                        stopWatch.Start();
                        var orderedList = from word in words
                                          orderby word
                                          select word;
                        words = orderedList.ToList();
                        stopWatch.Stop();
                        Console.WriteLine("\nTime taken in milli seconds = " + stopWatch.ElapsedMilliseconds);
                        break;

                    //Case 4: this case is to Count the Distinct Words 
                    case "4":
                        int uniqueWordsCount = words.Distinct().Count();
                        Console.WriteLine("\nCount of distinct words = " + uniqueWordsCount);
                        break;

                    //Case 5: this case Take the first 10 words
                    case "5":
                        List<string> tenWords = words.Take(10).ToList();
                        Console.WriteLine("\nFirst 10 words: ");
                        foreach (string w in tenWords)
                        {
                            Console.WriteLine(w);
                        }
                        break;

                     //Case 6: Get the number of words that start with 'j' and display the count
                    case "6":
                        var unnamedList = from word in words where word.StartsWith("j") select word;
                        Console.WriteLine("\nCount of words starts with j =  " + unnamedList.Count());
                        break;
                    //Case 7 - Get and display of words that end with 'd' and display the count
                    case "7":
                        var unnamedList2 = from word in words where word.EndsWith("d") select word;
                        foreach (string w in unnamedList2)
                        {
                            Console.WriteLine(w);
                        }
                        Console.WriteLine("\nCount of words ends with d = " + unnamedList2.Count());
                        break;

                      //Case 8: - Get and display of words that are greater than 4 characters long, and display the count
                    case "8":
                        var unnamedList3 = from word in words where word.Length > 4 select word;
                        foreach (string w in unnamedList3)
                        {
                            Console.WriteLine(w);
                        }
                        int greaterThanFourCount = unnamedList3.Count();
                        Console.WriteLine("\nCount of words with length greater than 4 = " + greaterThanFourCount);
                        break;

                    //Case 9: Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count
                    case "9":
                        var unnamedList4 = from word in words where word.Length < 3 && word.StartsWith("a") select word;
                        foreach (string w in unnamedList4)
                        {
                            Console.WriteLine(w);
                        }
                        int ltThreeCount = unnamedList4.Count();
                        Console.WriteLine("\nCount of words with less than 3 length and starts with a = " + ltThreeCount);
                        break;

                    //case X = To shutdown the console
                    case "x":
                        return;
                   
                    //default case for invalid selection
                    default:
                        Console.WriteLine("\nYou have chosen an invalid option!");
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
                        words[j] = words[j + 1];
                        words[j + 1] = temp;

                    }
            return words;
        }

        //this Method to import Words.txt using StreamReader
        IList<string> Import()
        {
            IList<string> words = new List<string>();
            using (StreamReader file = new StreamReader("..\\Words.txt"))
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
    



