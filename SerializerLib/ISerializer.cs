using System;

namespace SerializerLib
{
    public interface ISerializer
    {
        T Deserialize<T>(string xml);

        T DeserializeFile<T>(string file);

        string Serialize<T>(T obj);
    }
}
