using Moravia.Homework;
using Moravia.Homework.Readers;
using Moravia.Homework.Serializers;
using Moravia.Homework.Writers;

namespace Moravia.HoomeworkTests
{
    [TestClass]
    public class ReaderTests
    {
        private IReader reader = null;


        [TestInitialize]
        public void Initialize()
        {
            reader = new FileSystemStorageReader();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }
        

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilePathhNull()
        {
            reader.ReadDocument(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilePathEmpty()
        {
            reader.ReadDocument(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileDoesNotExist()
        {
            reader.ReadDocument("c_file/orc");
        }

        [TestMethod]        
        public void ReadJson()
        {
            string strExeFilePath = Directory.GetCurrentDirectory();
            string path = Path.Combine(strExeFilePath, "test.json");
            string dataStr = reader.ReadDocument(path);

            Document doc = new Document()
            {
                Title = "Title456",
                Text = "Text123"
            };


            ISerializer ser = new JsonDocSerialization();
            Assert.AreEqual(ser.SerializeToString(doc), dataStr);

        }
    }
}