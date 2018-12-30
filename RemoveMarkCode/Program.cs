using System;
using System.Collections.Generic;
using System.IO;

namespace RemoveMarkCode
{
    class Program
    {
        static void Main(string[] args)
        {
            const string removeCode = @"//if (selObj == null) return retObj;";

            const string SourcePath = @"D:\Dropbox\MyProject\";

            var fileList = Directory.EnumerateFiles(SourcePath, "*BC.cs", SearchOption.AllDirectories);

            foreach (var file in fileList)
            {
                if (file.Contains("obj") || file.Contains("Properties")) continue;

                var lines = new List<string>(File.ReadAllLines(file));

                var index = lines.FindIndex(x => x.Contains(removeCode));
                if (index <= 0) continue;

                Console.WriteLine("file= " + file);
                Console.WriteLine("index=" + index);

                //lines.RemoveAt(index);
                //lines.RemoveRange(index, 4);
                //File.WriteAllLines(file, lines.ToArray());
            }

            Console.WriteLine("press any key!!");
            Console.ReadKey();
        }
    }
}
