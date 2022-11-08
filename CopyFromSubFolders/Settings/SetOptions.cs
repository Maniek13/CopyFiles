using CopyFromSubFolders.XMLObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CopyFromSubFolders.Settings
{
    public class SetOptions
    {
        public static HashSet<string> extensions { 
            get {
                return GetExtensions();
            } 
        }
        private static HashSet<string> GetExtensions()
        {
            HashSet<string> extensions = new HashSet<string>();

            XmlSerializer serializer = new XmlSerializer(typeof(SettingsXML.Extensions));

            string pathToXml = AppDomain.CurrentDomain.BaseDirectory;
            pathToXml = Path.Combine(pathToXml, "Settings.xml");

            StringReader reader = new StringReader(File.ReadAllText(pathToXml));

            try
            {
                SettingsXML.Extensions extensionTypes = (SettingsXML.Extensions)serializer.Deserialize(reader);

                foreach (SettingsXML.Extension type in extensionTypes.Extension)
                {
                    extensions.Add(type.Type);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Set extension error " + e.Message);
            }

            return extensions;
        }
    }
}
