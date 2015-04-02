using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Markdown2PDF.Converts
{
    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input markdown file to read.")]
        public string InputFile { get; set; }

        [Option('o', "output", Required=true, HelpText = "Output PDF file path")]
        public string OutputFile { get; set; }

        [Option('t', "title", DefaultValue=null,  HelpText = "The title of this markdown file")]
        public string Title { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            // this without using CommandLine.Text
            //  or using HelpText.AutoBuild
            var usage = new StringBuilder();
            usage.AppendLine("Markdown2PDF 1.0");
            usage.AppendLine("Read user manual for usage instructions...");
            usage.AppendLine("Markdown2PDF.exe -i <MarkdownFile> [-o PDFfile] [-t Title]");
            return usage.ToString();
        }
    }
}
