using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Markdown2PDF.Core.Tools
{
    public class WKHtmltoPDFDownloader
    {
        public bool IsDownloading { get; protected set; }

        private WebClient client;

        public WKHtmltoPDFDownloader()
        {
            client = new WebClient();
            client.DownloadProgressChanged += client_DownloadProgressChanged;
            client.DownloadFileCompleted += client_DownloadFileCompleted;
        }

        void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            FileInfo file = e.UserState as FileInfo;
            if (file != null)
            { 
            
            }
            

            IsDownloading = false;
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Updating wkthmltopdf..." + e.ProgressPercentage);
        }

        public string ParseVersion()
        {
            string url = "http://wkhtmltopdf.org/downloads.html";
            string regex = @"version is \<strong\>(?<version>(\d+|\.)+)\<\/strong\>";
            
            string webpage = client.DownloadString(url);
            Regex reg = new Regex(regex);
            Match m = reg.Match(webpage);
            if (m.Groups["version"].Success)
            {
                return m.Groups["version"].Value;
            }
            else
            {
                return string.Empty;
            }
        }


        public void Download()
        {
            string url = GetUrl();
            string version = ParseVersion();
            url = url.Replace("{version}", version);
            if (url != string.Empty)
            {
                string file = url.Substring(url.LastIndexOf("/")).Trim('/');
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "wkhtmltopdf", file);
                //Debug.WriteLine(file);
                FileInfo fi = new FileInfo(file);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                if (!IsDownloading)
                {
                    client.DownloadFileAsync(new Uri(url), file, fi);
                    IsDownloading = true;
                }
            }
            
        }

        public string GetUrl()
        {
            string url = string.Empty;

            switch (Environment.OSVersion.Platform)
            { 
                case PlatformID.Win32NT:
                    if (Environment.OSVersion.Version.Major == 5)
                    {
                        if (Environment.Is64BitOperatingSystem)
                        {
                            url = "http://downloads.sourceforge.net/project/wkhtmltopdf/{version}/wkhtmltox-{version}_mingw-w64-cross-win64.exe";
                        }
                        else
                        {
                            url = "http://downloads.sourceforge.net/project/wkhtmltopdf/{version}/wkhtmltox-{version}_mingw-w64-cross-win32.exe";
                        
                        }
                    }
                    else if (Environment.OSVersion.Version.Major >= 6)
                    {
                        // Vista on up
                        if (Environment.Is64BitOperatingSystem)
                        {
                            url = "http://downloads.sourceforge.net/project/wkhtmltopdf/{version}/wkhtmltox-{version}_msvc2013-win64.exe"; 
                        }
                        else
                        {
                            url = "http://downloads.sourceforge.net/project/wkhtmltopdf/{version}/wkhtmltox-{version}_msvc2013-win32.exe"; 
                        }
                    }
                    break;

                case PlatformID.MacOSX:
                    if (Environment.Is64BitOperatingSystem)
                    {
                        url = "http://downloads.sourceforge.net/project/wkhtmltopdf/{version}/wkhtmltox-{version}_osx-cocoa-x86-64.pkg";
                    }
                    else
                    {
                        url = "http://downloads.sourceforge.net/project/wkhtmltopdf/{version}/wkhtmltox-{version}_osx-carbon-i386.pkg";
                    }

                    break;
            }

            return url;

          
        
        }
    }
}
