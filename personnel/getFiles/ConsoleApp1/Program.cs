using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace ConsoleApp1
{
    internal class Program
    {
        static string path = "C:/temp/";
        static void Main(string[] args)
        {
            (int numberOfFiles, int numberOfDirectories) = ProcessDirectory(path, 0, 0);
            Console.WriteLine($"{path} contient {numberOfFiles} fichiers et {numberOfDirectories} dossiers");
            Console.ReadLine();
        }
        public static (int,int) ProcessDirectory(string targetPath, int numberOfFiles, int numberOfDirectories)
        {
            // searches the current directory
            numberOfFiles += Directory.GetFiles(targetPath, "*", SearchOption.TopDirectoryOnly).Length;
            string[] s = Directory.GetDirectories(targetPath);
            numberOfDirectories += s.Length;
            foreach(string s2 in s)
            {
                (int Files, int Directories) = ProcessDirectory(s2,numberOfFiles, numberOfDirectories);
                numberOfFiles += Files - numberOfFiles;
                numberOfDirectories += Directories - numberOfDirectories;
            }
            return (numberOfFiles, numberOfDirectories);
        }
    }
}
