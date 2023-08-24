using Moravia.Homework;
using Moravia.Homework.Writers;

namespace Moravia.HoomeworkTests
{
    [TestClass]
    public class WriterTests
    {
        private IWriter writer;

        [TestInitialize]
        public void Initialize()
        {
            writer = new FileSystemStorageWriter();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoragePathNull()
        {
            writer.WriteToStorage(null, "data");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoragePathEmpty()
        {
            writer.WriteToStorage(string.Empty, "data");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataEmpty()
        {
            string strExeFilePath = Directory.GetCurrentDirectory();
            string path = Path.Combine(strExeFilePath, "testEmpty.json");
            writer.WriteToStorage(path, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataNull()
        {
            string strExeFilePath = Directory.GetCurrentDirectory();
            string path = Path.Combine(strExeFilePath, "testEmpty.json");
            writer.WriteToStorage(path, null);
        }
    }
}
