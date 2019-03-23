using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Document Merger 2");
            Console.WriteLine("Provide 2 or more documents to merge:");
            int docCount = 0;
            bool anotherDoc = false;
            ArrayList docs = new ArrayList();
            while (docCount < 2)
            {
                try
                {
                    Console.WriteLine("Enter a document name: ");
                    string doc = Console.ReadLine();
                    string docTxt = doc + ".txt";
                    string path = Directory.GetCurrentDirectory();
                    StreamReader sr = new StreamReader(docTxt);
                    string firstLine = sr.ReadLine();
                    docs.Add(firstLine);
                    sr.Close();
                    Console.WriteLine("{0} was found!", docTxt);
                    docCount++;
                    if (docCount == 2)
                    {
                        Console.WriteLine("Would you like to do another file? (y/n): ");
                        string yN = Console.ReadLine();
                        if (yN == "y")
                        {
                            anotherDoc = true;
                        }
                        else
                        {
                            Console.WriteLine("What would you like the merged file to be named?: ");
                            string mergedFile = Console.ReadLine();
                            using (TextWriter writer = File.CreateText(mergedFile))
                            {
                                foreach (string line in docs)
                                {
                                    Console.WriteLine(line);
                                    writer.WriteLine(line);
                                }
                                writer.Close();
                            }
                        }
                    }
                    while (anotherDoc)
                    {
                        try
                        {
                            Console.WriteLine("Enter a document name: ");
                            doc = Console.ReadLine();
                            docTxt = doc + ".txt";
                            path = Directory.GetCurrentDirectory();
                            StreamReader srr = new StreamReader(docTxt);
                            string line = srr.ReadLine();
                            docs.Add(line);
                            srr.Close();
                            Console.WriteLine("{0} was found!", docTxt);
                            docCount++;
                            Console.WriteLine("Would you like to do another file? (y/n): ");
                            string yN = Console.ReadLine();
                            if (yN == "y")
                            {
                                anotherDoc = true;
                            }
                            else
                            {
                                anotherDoc = false;
                                Console.WriteLine("What would you like the merged file to be named?: ");
                                string mergedFile = Console.ReadLine();
                                using (TextWriter writer = File.CreateText(mergedFile))
                                {
                                    foreach (string line2 in docs)
                                    {
                                        Console.WriteLine(line2);
                                        writer.WriteLine(line2);
                                    }
                                    writer.Close();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                            anotherDoc = true;
                            continue;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    Console.WriteLine("File not found. Try again!");
                    continue;
                }
            }
            




            Console.ReadLine();
        }
    }
}
