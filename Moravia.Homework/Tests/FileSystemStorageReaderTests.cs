using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moravia.Homework;
using Moravia.Homework.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public class FileSystemStorageReaderTests
    {
        private FileSystemStorageReader? reader = null;

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
        public void StorageAddrEmpty()
        {
            reader.ReadDocument(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StorageAddrNull()
        {
            reader.ReadDocument(string.Empty);

        }
        
    }
}
