using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moravia.Homework;
using Moravia.Homework.Serializers;

namespace Moravia.HoomeworkTests
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void JsonNullSerialization()
        {
            ISerializer ser = new JsonDocSerialization();
            ser.SerializeToString(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void JsonEmptyStrDeserialization()
        {
            ISerializer ser = new JsonDocSerialization();
            ser.DeserializeFormString(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void JsonNullStrDeserialization()
        {
            ISerializer ser = new JsonDocSerialization();
            ser.DeserializeFormString(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void XmlNullSerialization()
        {
            ISerializer ser = new XmlDocSerialization();
            ser.SerializeToString(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void XmlEmptyStrDeserialization()
        {
            ISerializer ser = new XmlDocSerialization();
            ser.DeserializeFormString(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void XmlNullStrDeserialization()
        {
            ISerializer ser = new XmlDocSerialization();
            ser.DeserializeFormString(null);
        }

        [TestMethod]        
        public void XmlStrDeserialization()
        {
            ISerializer ser = new XmlDocSerialization();
            Document doc = new Document()
            {
                Text = "1",
                Title = "2"
            };
        }
    }
}
