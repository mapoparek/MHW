using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Moravia.Homework.Serializers
{
    public class XmlDocSerialization : ISerializer
    {
        public Document? DeserializeFormString(string strData)
        {
            if (string.IsNullOrEmpty(strData))
            {
                throw new ArgumentException("Parameter empty or null", nameof(strData));
            }

            Document result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (TextReader reader = new StringReader(strData))
            {
                result = (Document)serializer.Deserialize(reader);
            }

            return result;
        }

        public string SerializeToString(Document documet)
        {
            if (documet == null)
            {
                throw new ArgumentException("Parameter null", nameof(documet));
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Document));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, documet);
                return textWriter.ToString();
            }
        }
    }
}
