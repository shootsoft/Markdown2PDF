using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Markdown2PDF.Converts
{
    public class PDFConvert
    {
        public static bool Convert(string html, string pdf)
        { 
            string exe = @"C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe";
            Process p = Process.Start(exe, " -s A4 --zoom 3 \"" + html + "\" \"" + pdf + "\"");
            p.WaitForExit();
            return true;
        }

        public static bool Check()
        {
            return true;
        }

        public static bool Download()
        {
            return true;
        }
    }
}
