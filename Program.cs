using System;
using System.IO;

namespace DataParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //get all the files from the neg directory
            string basePath = @"C:\Users\amitmach\Downloads\imdb-movie-reviews-dataset\aclImdb\test";
            string pathToNegative = Path.Combine(basePath, "neg");
            string[] negativeFiles = Directory.GetFiles(pathToNegative);
            StringWriter csv = new StringWriter();
            csv.WriteLine(string.Format("{0},{1}", "Label", "Review"));
            foreach (var file in negativeFiles)
            {
                string content = File.ReadAllText(file);
                int label = 0;
                content = content.Replace("\"", " ");
                csv.WriteLine(string.Format("{0},{1}", label, "\"" + content + "\""));
            }

            string outputFilePath = "./output.csv";
            File.WriteAllText(outputFilePath, csv.ToString());


            string pathToPos = Path.Combine(basePath, "pos");
            string[] positiveFiles = Directory.GetFiles(pathToPos);
            // StringWriter posCsv = new StringWriter();

            foreach (var file in positiveFiles)
            {
                string content = File.ReadAllText(file);
                int label = 1;
                content = content.Replace("\"", " ");
                // posCsv.WriteLine(string.Format("{0},{1}", content, "\"" + label + "\""));
                csv.WriteLine(string.Format("{0},{1}", label, "\"" + content + "\""));
            }
            
            // File.AppendAllText(outputFilePath, posCsv.ToString());
            File.WriteAllBytes(string.Format("{0}{1}", "output", ".csv"), new System.Text.UTF8Encoding().GetBytes(csv.ToString()));
        }
    }
}
