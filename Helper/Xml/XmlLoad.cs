using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BotTemplate.Helper.Xml
{
    internal class XmlLoad<T>
    {
        public static Type type;

        public XmlLoad()
        {
            type = typeof(T);
        }

        public T LoadData(string filename)
        {
            T result;
            XmlSerializer xmlserializer = new XmlSerializer(type);
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            result = (T)xmlserializer.Deserialize(fs);
            fs.Close();

            return result;
        }
    }
}
