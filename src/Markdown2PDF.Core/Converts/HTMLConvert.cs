using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Markdown2PDF.Core.Tools;

namespace Markdown2PDF.Core.Converts
{
    public class HTMLConvert
    {
        public static bool ConvertFile(string markdownFile, string htmlFile, string title, string theme)
        {
            string templateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "html", "template.html");
            if (!File.Exists(templateFile))
            {
                return false;
            }

            

            string content = TextIO.ReadText(markdownFile);
            string template = TextIO.ReadText(templateFile);

            FileInfo markdownInfo = new FileInfo(markdownFile);
            if (title == null)
            {
                title = markdownInfo.Name.Substring(0, markdownInfo.Name.Length - markdownInfo.Extension.Length);
            }

            string html = template.Replace("{title}", title)
                .Replace("{markdown}", content)
                .Replace("{theme}", theme);

            File.WriteAllText(htmlFile, html, Encoding.UTF8);

            return true;

        }
    }
}
