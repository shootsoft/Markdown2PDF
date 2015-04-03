using Markdown2PDF.Core.Converts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Markdown2PDF.Core
{
    public class Awesome
    {
        public static void Convert(string markdown, string pdf = null, string title = null, string theme = "cerulean")
        {
            if (!File.Exists(markdown))
            {
                return;
            }
            Console.WriteLine("Converting " + markdown);

            string tempFile = markdown + "_" + Guid.NewGuid().ToString().Trim('{', '}') + "_.html";
            HTMLConvert.ConvertFile(markdown, tempFile, title, theme);
            if (pdf == null)
            {
                pdf = markdown + ".pdf";
            }

            PDFConvert.Convert(tempFile, pdf);

            try
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static string GetTempFile(string ext)
        {
            string tempFile = Path.GetTempFileName();
            string tempExtFile = tempFile + ext;

            try
            {
                File.Delete(tempFile);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return tempExtFile;

        }

    }
}
