﻿using System.IO;
using System.Xml.Serialization;

namespace SerializerLib
{
    public class XMLSerializer : ISerializer
    {
        public T Deserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(xml);
            return (T)serializer.Deserialize(stringReader);
        }

        public T DeserializeFile<T>(string file)
        {
            return Deserialize<T>(File.ReadAllText(file));
        }

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