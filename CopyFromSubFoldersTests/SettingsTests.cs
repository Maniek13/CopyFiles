using CopyFromSubFolders.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopyFromSubFoldersTests
{
    [TestClass]
    public class SettingsTests
    {
        [TestMethod]
        public void SetExtension()
        {
            HashSet<string> extension = SetOptions.extensions;

            Assert.AreEqual(3, extension.Count());
        }
        
    }
}
