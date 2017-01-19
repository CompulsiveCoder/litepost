using System;
using System.IO;

namespace litepost
{
    public class FileAppender
    {
        public string ContentDirectory { get; set; }

        public FileAppender (string contentDirectory)
        {
            ContentDirectory = contentDirectory;
        }

        public void AppendLine(string fileName, string text)
        {
            Append (fileName, text + Environment.NewLine);
        }

        public void Append(string fileName, string text)
        {
            if (!Directory.Exists (ContentDirectory))
                Directory.CreateDirectory (ContentDirectory);
            
            var filePath = Path.Combine(ContentDirectory, fileName);

            Console.WriteLine (filePath);

            if (!File.Exists (filePath))
                File.WriteAllText (filePath, text);
            else
                File.AppendAllText (filePath, text);
        }
    }
}

