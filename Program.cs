using System;
using System.Collections.Generic;
using System.IO;

namespace task2var3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string pathIn = @"C:\Users\germo\RiderProjects\task2var3\input.txt";
            string pathOut = @"C:\Users\germo\RiderProjects\task2var3\out.txt";
            
            Console.WriteLine("Введите номер обзаца");
            int n = Int32.Parse(Console.ReadLine());
            solution(pathIn, pathOut,n);
        }

        public static void solution(string pathIn, string pathOut, int number)
        {
            List<string> res = readParagraphs(pathIn);

            if((number > 0)&& (number <= res.Count)) res.RemoveAt(number-1);
           
            
            writeToFile(pathOut, res);
            
        }

        public static void writeToFile(string pathOut, List<string> text)
        {
            FileStream file1 = new FileStream(pathOut, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file1);

            foreach (string s in text)
            {
                writer.Write(s);
            }
            writer.Close();
        }

        public static List<string> readParagraphs(string pathIn)
        {
            List<string> res = new List<string>();
            
            FileStream file1 = new FileStream(pathIn, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file1);

            string paragraph = "";

            bool paragraphStart = false;
            bool prevIsNewLine = false;
            
            foreach(char c in reader.ReadToEnd())
            {
                paragraph += c;

                if (paragraphStart)
                {
                    if (c == '\n')
                    {
                        if (prevIsNewLine)
                        {
                            res.Add(paragraph);
                            paragraph = "";
                            paragraphStart = false;
                            prevIsNewLine = false;
                        }
                        else
                        {
                            prevIsNewLine = true;
                        }
                    }
                }
                else
                {
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= 'а' && c <= 'я') ||
                        (c >= 'А' && c <= 'Я'))
                        paragraphStart = true;
                    if (prevIsNewLine) prevIsNewLine = false;
                }
                
            }
            
            if(paragraphStart)res.Add(paragraph);
            
            reader.Close();
            
            
            return res;
        }
    }
}