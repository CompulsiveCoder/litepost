using System;
using System.IO;

namespace litepost
{
    public class FileOverwriter
    {
        public string ContentDirectory { get; set; }

        public FileOverwriter (string contentDirectory)
        {
            ContentDirectory = contentDirectory;
        }

        public void Overwrite(string fileName, string text)
        {
            if (!Directory.Exists (ContentDirectory))
                Directory.CreateDirectory (ContentDirectory);

            var filePath = Path.Combine (ContentDirectory, fileName);

            Console.WriteLine (filePath);

            File.WriteAllText (filePath, text);
        }
    }
}

