namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {

            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string result = string.Empty;
            var output = new Dictionary<string, Dictionary<string, decimal>>();
            string[] files = Directory.GetFiles(inputFolderPath);
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (output.ContainsKey(fileInfo.Extension) == false)
                {
                    output.Add(fileInfo.Extension, new Dictionary<string, decimal>());
                }

                output[fileInfo.Extension].Add(fileInfo.Name, fileInfo.Length/1024M);

            }

            foreach (var item in output
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                result += item.Key + Environment.NewLine;
                foreach (var (name, size) in item.Value
                    .OrderBy(x => x.Value))
                {
                    result += $"--{name} - {size}kb" + Environment.NewLine;
                }
            }

            return result;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText(pathDesktop + "/" + reportFileName, textContent);    

        }
    }
}
