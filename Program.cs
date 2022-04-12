using System;
using System.IO;
using System.Collections.Generic;

namespace lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string routeInput = "";
    
            while(routeInput != "4")
            {
                DisplayMenu();  //update read
                routeInput = Console.ReadLine();
                Route(routeInput); 
            }
        }
        static void Route(string routeInput)
        {
            Console.Clear();
            switch(routeInput)
            {
                case "1":
                    GoBackward();
                    break;
                case "2":
                    GoForward();
                    break;
                case "3":
                    WordCount();
                    break;
                case "4":
                    System.Console.WriteLine("Bye");
                    break;

                default:
                System.Console.WriteLine("Invalid Choice");
                break;
                
            }
            System.Console.WriteLine("Goodbye");
        }
        static void DisplayMenu()
        {
            System.Console.WriteLine("Select from the available options");
            System.Console.WriteLine("1.Encode\n2.Decode\n3.Word Count\n4.Exit");
        }
        static void EncodeFile()
        {   
            System.Console.WriteLine("please enter the file to be encoded");
            string inputFile = Console.ReadLine();

            System.Console.WriteLine("Please enter file to save to");
            string outputFile = Console.ReadLine();

            EncodeIt(inputFile, outputFile);

        }
        static void GoForward()
        {
            System.Console.WriteLine("Welcome to out encode method");
            EncodeFile();
        }
        static void GoBackward()
        {
            System.Console.WriteLine("Welcome to out encode method");
            EncodeFile();
        }

        static void EncodeIt(string inputFIle, string outputFile)
        {   
            AnyKey();

            StreamReader inFile = new StreamReader(inputFIle);
            StreamWriter outFIle = new StreamWriter(outputFile);

            string line = inFile.ReadLine(); //prime

            while(line != null)
            {
                
                outFIle.WriteLine(TransformIt(line));
                
                line = inFile.ReadLine(); //update
            }
            inFile.Close();
            outFIle.Close();
        }
        static string TransformIt(string line)
        {
            string letters = "ABCDEFJHIJKLMNOPQRSTUVWXYZ";

            String newLine = "";
            line = line.ToUpper();
            for(int u = 0; u < line.Length; u++)
            {
                int found = -1;
                for(int j = 0; j < letters.Length; j++)
                {
                    if(line[u] == letters[j])
                    {
                        found = j;
                    }
                }
                if(found == -1)
                    {
                        newLine += line[u];
                    }
                else
                {
                    newLine += letters[((found + 13)%26)];
                }
            }

            return newLine;
        }
        static void WordCount()
        {
            Console.Clear();
            System.Console.WriteLine("What is the name of the input file");
            string fileName = Console.ReadLine();

            StreamReader inFile = new StreamReader(fileName);
            string line = inFile.ReadLine();
            int count = 0;

            while(line != null)
            {
                string[] temp = line.Split(" ");
                count += temp.Length;

                line = inFile.ReadLine();
            }
            inFile.Close();
            System.Console.WriteLine($"The file has {count} words.");
        
        }
        static void AnyKey()
        {
            Console.Clear();
            System.Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
    }
}