using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moravia.Homework.Serializers;

namespace Moravia.Homework.Writers
{
    public interface IWriter
    {
        public void WriteToStorage(string storagePath, string data);

    }
}
