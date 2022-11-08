using CopyFromSubFolders.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CopyFromSubFolders.App
{
    public class Core
    {
        public void MainClass(string[] args)
        {
            string mainDir;
            string newDir;
            string subFoldersNameContend;
            int deleteOther = 0;
            int copyFromMain = 1;
            HashSet<string> extensionList = new HashSet<string>();

            extensionList = SetOptions.extensions;

            #region management parameters
            if (args.Length < 2)
            {
                throw new Exception("No path");
            }
           
            if (args.Length > 6)
            {
                throw new Exception("Too many arguments");
            }

            if (args.Length >= 3 && args[2] == "1")
            {
                extensionList = SetOptions.extensions;
            }
           
            if (args.Length >= 4)
            {
                Int32.TryParse(args[3], out deleteOther);
            }

            if (args.Length >= 5)
            {
                Int32.TryParse(args[4], out copyFromMain);
            }
            #endregion

            mainDir = Path.Combine(args[0]);
            newDir = Path.Combine(args[1]);

            if (!Directory.Exists(newDir))
            {
                Directory.CreateDirectory(newDir);
            }

            if (args.Length == 6)
            {
                subFoldersNameContend = args[5];
                CopyFromSub(mainDir, newDir, extensionList, deleteOther, subFoldersNameContend);
            }
            else
            {
                CopyFromSub(mainDir, newDir, extensionList, deleteOther);
            }

            if (copyFromMain == 1)
            {
                CopyFromMain(mainDir, newDir, extensionList, deleteOther);
            }

            DeleteEmptyFolders(mainDir);
        }
        private static void CopyFromSub(string oldDir, string newDir, HashSet<string> extension, int deleteOthers = 0, string subFoldersNameContend = "")
        {
            var dirs = Directory.GetDirectories(oldDir, "*", SearchOption.TopDirectoryOnly);

            if (dirs.Length == 0 )
            {
                Console.WriteLine($"No subdirectorys detected");
                return;
            }
           

            foreach (string dir in dirs)
            {
                if (dir.Contains(subFoldersNameContend))
                {
                    var allFiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                    
                    CopyFiles(allFiles, newDir, extension, deleteOthers);
                }
            }
        }

        private static void CopyFromMain(string oldDir, string newDir, HashSet<string> extension, int deleteOthers)
        {
            var allFiles = Directory.GetFiles(oldDir, "*.*", SearchOption.AllDirectories);
            CopyFiles(allFiles, newDir, extension, deleteOthers);
        }

        private static void CopyFiles(string[] allFiles, string newDir, HashSet<string> extension, int deleteOthers)
        {
            foreach (string filePath in allFiles)
            {
                string newFile = Path.GetFileName(filePath);
                newFile = Path.Combine(newDir, newFile);

                var ext = Path.GetExtension(filePath).Replace(".", "");
         
                if (extension.Count() != 0 && !extension.Contains(ext) && deleteOthers == 1)
                {
                    File.Delete(filePath);
                    Console.WriteLine($"File has been removed from {filePath}");
                }
                else if ((extension.Count() == 0 || extension.Contains(ext)) && !File.Exists(newFile))
                {
                    File.Move(filePath, newFile);
                    Console.WriteLine($"File has been moved from {filePath} to {newFile}");
                }
            }
        }

        private static void DeleteEmptyFolders(string mainDir)
        {
            foreach (var directory in Directory.GetDirectories(mainDir))
            {
                DeleteEmptyFolders(directory);
                if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                    Console.WriteLine($"Empty directory: {directory} has been removed");
                }
            }
        }
    }
}
