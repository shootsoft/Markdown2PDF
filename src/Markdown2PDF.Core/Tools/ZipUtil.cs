using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using SharpCompress.Common;
using SharpCompress.Reader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Markdown2PDF.Core.Tools
{
    public class ZipUtil
    {
        public static bool Unzip(string zipfile, string outFolder)
        {
            bool result = true;
            try
            {
                using (Stream stream = File.OpenRead(zipfile))
                {
                    var reader = ReaderFactory.Open(stream);
                    while (reader.MoveToNextEntry())
                    {
                        if (!reader.Entry.IsDirectory)
                        {
                            //Console.WriteLine(reader.Entry.na);
                            reader.WriteEntryToDirectory(outFolder, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                Debug.WriteLine(ex);
            }

            return result;
        }
    }
}
