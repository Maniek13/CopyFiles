using CopyFromSubFolders.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFromSubFolders
{
    internal class Program
    {
        //app.exe "old dir" "new dir" "use extension list" "delete other files"  "copy from main" "directoryContend"
        public static void Main(string[] args)
        {
            try
            {
                Core cr = new Core();
                cr.MainClass(args);
                Console.WriteLine("Click enter to close");
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Click enter to close");
                Console.ReadLine();
            }
        }
        
    }
}
