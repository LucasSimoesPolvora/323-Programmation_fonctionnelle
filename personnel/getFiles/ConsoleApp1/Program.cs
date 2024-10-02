using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static string path = "C:/temp/";
        static int numberOfFiles = 0;
        static void Main(string[] args)
        {
            ProcessDirectory(path);
            Console.WriteLine($"{path} contient {numberOfFiles} fichiers");
            Console.ReadLine();
        }
        public static int ProcessDirectory(string targetPath)
        {
            // searches the current directory
            numberOfFiles += Directory.GetFiles(targetPath, "*", SearchOption.TopDirectoryOnly).Length;
            string[] s = Directory.GetDirectories(targetPath);
            foreach(string s2 in s)
            {
                ProcessDirectory(s2);
            }
            return numberOfFiles;
        }
    }
}
