using System;
using System.Reflection;
using CLAP;
using Parser;
using Sprache;

namespace Candidate.Software.Craftsman.Charly
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new TwitterContext();

            Console.WriteLine("Starting Simple C# Twitter REPL, enter q to quit");
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                input = input.TrimStart('>', ' ');
                if (input.ToLower() == "q")
                {
                    return;
                }
                try
                {
                    var command = Grammar.CommandParser.Parse(input);
                    command.Run(context);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error in input");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
