using System.IO;
using System.Xml.Serialization;

namespace SerializerLib
{
    /// <summary>
    /// Class to seriliaze to xml and deserialize from xml 
    /// </summary>
    public class XMLSerializer : ISerializer
    {
        /// <summary>
        /// Deserialize a xml string
        /// </summary>
        /// <typeparam name="T">Type of the deserialized returned object</typeparam>
        /// <param name="stringToDeserialize">String to be deserialized</param>
        /// <returns>Type T deserialized object</returns>
        public T Deserialize<T>(string stringToDeserialize)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(stringToDeserialize);
            return (T)serializer.Deserialize(stringReader);
        }

        /// <summary>
        /// Deserialize a file
        /// </summary>
        /// <typeparam name="T">Type of the deserialized returned object</typeparam>
        /// <param name="file">File's path to be deserialized</param>
        /// <returns>Type T deserialized object</returns>
        public T DeserializeFile<T>(string file)
        {
            return Deserialize<T>(File.ReadAllText(file));
        }

        /// <summary>
        /// Serialize an object
        /// </summary>
        /// <typeparam name="T">Type of the object to be serilized</typeparam>
        /// <param name="obj">Object to be serialized</param>
        /// <returns>String serialized object</returns>
        public string Serialize<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            string xml = "";
            using (Stream stream = new MemoryStream())
            {
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                var sr = new StreamReader(stream);
                xml = sr.ReadToEnd();
            }
            return xml;
        }
    }
}