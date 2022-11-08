using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CopyFromSubFolders.App;

namespace CopyFromSubFoldersTests
{
    // //app.exe "oldDir" "newDir" "useExtensionlist" "delete other files" directoryContend"
    [TestClass]
    public class ParametersTests
    {
        [TestMethod]
        public void NotEnoughtParameters()
        {
            try
            {
                string[] args = new string[0];
                Core cr = new Core();
                cr.MainClass(args);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "No path");
            }
        }

        [TestMethod]
        public void ToManyParameters()
        {
            try
            {
                string[] args = new string[7];
                Core cr = new Core();
                cr.MainClass(args);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Too many arguments");
            }
        }


     

    }
}
