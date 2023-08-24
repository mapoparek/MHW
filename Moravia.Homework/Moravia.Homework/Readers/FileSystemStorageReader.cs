namespace Moravia.Homework.Readers
{
    /// <summary>
    /// Reading from file storage
    /// </summary>
    public class FileSystemStorageReader : IReader
    {

        public string ReadDocument(string storageSource)
        {
            if (string.IsNullOrEmpty(storageSource))
            {
                throw new ArgumentException(nameof(storageSource));
            }

            if (!ExistSourcePath(storageSource))
            {
                throw new FileNotFoundException($"File {nameof(storageSource)} not found");
            }

            string input = string.Empty;


            using (FileStream sourceStream = File.Open(storageSource, FileMode.Open))
            {
                if (sourceStream == null)
                {
                    throw new NullReferenceException($"{nameof(sourceStream)}");
                }

                using (var reader = new StreamReader(sourceStream))
                {
                    input = reader.ReadToEnd();
                }
            }


            if (string.IsNullOrEmpty(input))
            {
                throw new FileLoadException();
            }


            return input;
        }

        private bool ExistSourcePath(string path)
        {
            return File.Exists(path);
        }
    }
}
