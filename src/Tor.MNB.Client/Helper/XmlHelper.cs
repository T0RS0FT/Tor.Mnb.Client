using System.Runtime.Serialization;
using System.Text;

namespace Tor.MNB.Client.Helper
{
    public static class XmlHelper
    {
        public static T DeserializeXml<T>(string xml)
        {
            using (var stream = new MemoryStream())
            {
                byte[] data = Encoding.UTF8.GetBytes(xml);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                var deserializer = new DataContractSerializer(typeof(T));

                return (T)deserializer.ReadObject(stream);
            }
        }
    }
}
