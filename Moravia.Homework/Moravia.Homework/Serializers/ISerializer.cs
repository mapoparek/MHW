using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moravia.Homework.Serializers
{
    public interface ISerializer
    {
        public string SerializeToString(Document documet);

        public Document DeserializeFormString(string strData);
    }
}
