using Markdown2PDF.Core.Tools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Markdown2PDF.Tests
{
    [TestFixture]
    public class ComponentUrlTests
    {
        [Test]
        public void ParseVersionTest()
        {
            //Need to be updated to the newest 
            string expected = "0.12.2.1";
            WKHtmltoPDFDownloader c = new WKHtmltoPDFDownloader();
            string actual = c.ParseVersion();
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void DownloadTest()
        {
            WKHtmltoPDFDownloader c = new WKHtmltoPDFDownloader();
            c.Download();
        }

        public void UnzipTest()
        { 
            string path = @"Y:\work\github\Markdown2PDF\src\Markdown2PDF.Tests\bin\Debug\Data\wkhtmltopdf\wkhtmltox-0.12.2.1_msvc2013-win64.exe";
            string folder = @"Y:\work\github\Markdown2PDF\src\Markdown2PDF.Tests\bin\Debug\Data\wkhtmltopdf\";
            string zip7 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "7zip", "bin", "7zr.exe");

            Process.Start(zip7, " x \""+path+"\"");
            //ZipUtil.Unzip(path,  folder);
        
        }
    }
}
