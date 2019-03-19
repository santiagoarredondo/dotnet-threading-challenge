using LogLibrary;
using System.IO;

namespace ReportLibrary
{
    public class Report
    {
        /// <summary>
        /// Generates a file with a content
        /// </summary>
        /// <param name="path"> the file path (file doesn't have to exist necessarily) </param>
        /// <param name="content"> the file content </param>
        public static void GenerateReport(string path, string content)
        {
            if (!File.Exists(path))
            {
                Log.showInformationMessage("File doesn't exist");
                using (StreamWriter sw = File.CreateText(path))
                {
                    Log.showInformationMessage("Creating file on: " + path);
                    sw.Write(content);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    Log.showInformationMessage("Writing on file: " + path);
                    sw.Write(content);
                }
            }
        }
    }
}
