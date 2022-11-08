using System.Collections.Generic;
using System.Xml.Serialization;

namespace CopyFromSubFolders.XMLObjects
{
    public class SettingsXML
    {
		[XmlRoot(ElementName = "Extension")]
		public class Extension
		{
			[XmlElement(ElementName = "Type")]
			public string Type { get; set; }
			
		}

		[XmlRoot(ElementName = "Extensions")]
		public class Extensions
		{

			[XmlElement(ElementName = "Extension")]
			public HashSet<Extension> Extension { get; set; }
		}

	}
}
