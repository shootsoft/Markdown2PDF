using Markdown2PDF.Converts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Markdown2PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Awesome.Convert(options.InputFile, options.OutputFile, options.Title);
            }
            else if (args.Length > 0 && File.Exists(args[0]))
            {
                options.InputFile = args[0];
                Awesome.Convert(options.InputFile);
            }
            else
            {   
                Console.WriteLine("Press any key to exit.");
                Console.Read();
            }

            
        }
    }
}
