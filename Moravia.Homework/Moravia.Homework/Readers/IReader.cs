using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moravia.Homework.Serializers;

namespace Moravia.Homework.Readers
{
    public interface IReader
    {
        public string ReadDocument(string storageSource);
    }
}
