using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moravia.Homework.Serializers
{
    public class JsonDocSerialization : ISerializer
    {
        public Document? DeserializeFormString(string strData)
        {
            if (string.IsNullOrEmpty(strData))
            {
                throw new ArgumentException("Parameter empty or null", nameof(strData));
            }

            return JsonConvert.DeserializeObject<Document>(strData);
        }

        public string SerializeToString(Document documet)
        {
            if (documet == null)
            {
                throw new ArgumentException("Parameter null", nameof(documet));
            }

            return JsonConvert.SerializeObject(documet);
        }
    }
}
