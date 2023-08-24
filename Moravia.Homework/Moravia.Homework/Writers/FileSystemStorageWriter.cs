using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moravia.Homework.Serializers;

namespace Moravia.Homework.Writers
{
    public class FileSystemStorageWriter : IWriter
    {
        public void WriteToStorage(string storagePath, string data)
        {
            if (string.IsNullOrEmpty(storagePath))
            {
                throw new ArgumentNullException(nameof(storagePath));
            }

            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }          

            using (FileStream? targetStream = File.Open(storagePath, FileMode.Create, FileAccess.Write))
            {
                if (targetStream == null)
                {
                    throw new NullReferenceException(nameof(targetStream));
                }
                using (var sw = new StreamWriter(targetStream))
                {
                    sw.Write(data);
                }
            }

            return;
        }
    }
}
