
/*
Homework
Instructions
Attached, please find a console application which main purpose is to convert the formats.
Prepare:
	1, Please find at least 5 potential code issues an be able to explain the reason behind it.
	2, Refactor the app to allow:
		a, Work with documents of various storages eg. filesystem, cloud storage or HTTP (HTML read-only) etc. Implement just one of them but
		   be sure that implementation is versatile for adding other storages.
		b, Be capable of reading/writing different formats. Implement XML and JSON format, but be sure that implementation is versatile for adding
		   more formats (YAML, BSON, etc.).
		c, Build the app in the way to be able to test classes in isolation
		d, Be able to add new formats and storages in the future so it will have none or minimal impact on the existing code
		e, Be able to use any combination of input/output storages and formats (eg. read JSON from filesystem, convert to XML and upload to
		   cloud storage)
*/

/*
--------------------------------------------------------------------------------------------------------------
AD 1,
---------------
*sourceFileName and  targetFileName 
*- mutliline string code without @ or + symbols -> syntax error
*- weird Path creating, combination of relative path and system enviroment path...
*
*FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
* - sourceFileName file should be tested if exist
* - FileStream sourceStream should be in using statement or at least .Close() should be called
* 
* var reader = new StreamReader(sourceStream);
* - should be in using statement or at least .Close() should be called
* 
* var xdoc = XDocument.Parse(input);
* - xdoc could be null
* - parsing could trow exception, should be in try/catch statement
* 
* Title = xdoc.Root.Element("title").Value,
* -xdoc, xcod.Root, Root.Element("title") could be null -> possible null reference excpetion
* 
* Text = xdoc.Root.Element("text").Value
* -xdoc, xcod.Root, Root.Element("text") could be null -> possible null reference excpetion
* 
* var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
* - targetFileName should be tested if is not null or empty
* - targetStream  shoudl be in using statement, or at least .Close() should be called
* - should be in try/catch statement
* 
* var sw = new StreamWriter(targetStream);
* - targetStream could be null
* - should be in using statement or at least .Close() should be called
* 
* sw.Write(serializedDoc);
* -should be in try/catch statement


*/

using Moravia.Homework.Serializers;
using Moravia.Homework.Readers;
using Moravia.Homework.Writers;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Moravia.Homework
{
    public class Document
    {
        [XmlAttribute(nameof(Title))]
        [JsonProperty(nameof(Title))]
        public string Title { get; set; } = string.Empty;

        [XmlAttribute(nameof(Text))]
        [JsonProperty(nameof(Text))]
        public string Text { get; set; } = string.Empty;
    }
    class Program
    {
        static void Main(string[] args)
        {

            Document doc = new Document()
            {
                Text = $"Text123",
                Title = $"Title456"
            };



            string s = Environment.CurrentDirectory;

            string strExeFilePath = Directory.GetCurrentDirectory();

            string fileNameJson = Path.Combine(strExeFilePath, $"{DateTime.Now.ToShortDateString()}.json");
            string fileNameXml = Path.Combine(strExeFilePath, $"{DateTime.Now.ToShortDateString()}.xml");

            ISerializer serializerJson = new JsonDocSerialization();
            ISerializer serializerXml = new XmlDocSerialization();
            IReader reader = new FileSystemStorageReader();
            IWriter writer = new FileSystemStorageWriter();

            string dataJson = serializerJson.SerializeToString(doc);
            string dataXml = serializerXml.SerializeToString(doc);

            writer.WriteToStorage(fileNameJson, dataJson);
            writer.WriteToStorage(fileNameXml, dataXml);

            string dataJsonLoaded = reader.ReadDocument(fileNameJson);
            string dataXmlLoeaded = reader.ReadDocument(fileNameXml);

            Document docJson = serializerJson.DeserializeFormString(dataJsonLoaded);
            Document docXml = serializerXml.DeserializeFormString(dataXmlLoeaded);
            

        }
    }


}