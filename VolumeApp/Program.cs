using System;
using VolumeApp.Components;

namespace VolumeApp
{
    class Program
    {
        private static TextWriter _writer = new TextWriter("/Data/", "OutputFile.txt");

        static void Main(string[] args)
        {
            var key = "";

            while(key != "Q")
            { 
                Console.WriteLine("R for read, W for write, C for clear, Q for quit");
                key = Console.ReadLine();

                if(key == "R")
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write(_writer.ReadAll());
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (key == "W")
                {
                    Console.WriteLine("Input line to write");
                    var line = Console.ReadLine();
                    _writer.WriteLine(line);
                }
                else if (key == "C")
                {
                    _writer.Clear();
                }
            }

            _writer.Dispose();
        }
    }
}
