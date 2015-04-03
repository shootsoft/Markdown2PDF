using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Markdown2PDF.Core.Converts
{
    public class PDFConvert
    {
        public static string EXE = string.Empty;

        static PDFConvert()
        {
            EXE = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "wkthmltopdf");

            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    EXE += Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + "wkhtmltopdf.exe";
                    break;
                case PlatformID.MacOSX:

                    break;

            }
        }


        public static bool Convert(string html, string pdf)
        {
                //@"C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe";
            if (File.Exists(EXE))
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = EXE,
                        Arguments = " -s A4 --zoom 3 \"" + html + "\" \"" + pdf + "\"",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };



                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
                return true;
            }
            else 
            {
                Console.WriteLine("Cannot find " + EXE);
                return false;

            }

            

        }

        public static bool Check()
        {
            return File.Exists(EXE);
        }

        public static bool Download()
        {
            
            //Environment.OSVersion.Platform == PlatformID.Win32NT

            return true;
        }

        public static string GetUrl()
        {
            //s//tring url = http://wkhtmltopdf.org/downloads.html
            switch (Environment.OSVersion.Platform)
            { 
                case  PlatformID.Win32NT:

                    break;
            }
            return string.Empty;
        }
    }
}
