using System;

namespace SerializerLib
{
    /// <summary>
    /// Interface to serialize and deserialize
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Deserialize a string
        /// </summary>
        /// <typeparam name="T">Type of the deserialized returned object</typeparam>
        /// <param name="stringToDeserialize">String to be deserialized</param>
        /// <returns>Type T deserialized object</returns>
        T Deserialize<T>(string stringToDeserialize);

        /// <summary>
        /// Deserialize a file
        /// </summary>
        /// <typeparam name="T">Type of the deserialized returned object</typeparam>
        /// <param name="file">File's path to be deserialized</param>
        /// <returns>Type T deserialized object</returns>
        T DeserializeFile<T>(string file);

        /// <summary>
        /// Serialize an object
        /// </summary>
        /// <typeparam name="T">Type of the object to be serilized</typeparam>
        /// <param name="obj">Object to be serialized</param>
        /// <returns>String serialized object</returns>
        string Serialize<T>(T obj);
    }
}
