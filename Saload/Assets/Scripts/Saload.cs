using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
namespace Saload
{ 
    public class Save
    {
        private static void SaveObject<T>(string file_name, T data_object)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string abs_path = Path.Combine(Application.persistentDataPath, file_name);
            FileStream stream = new FileStream(abs_path, FileMode.Create);
            formatter.Serialize(stream, data_object);
            stream.Close();
        }
        public static void SetKey<T>(string key, T data)
        {
            Storage<T> storage = new Storage<T>
            {
                data = data,
                key = key
            };
            SaveObject(key + ".saload", storage);
        }
    }
    public class Load
    {
        private static T LoadObject<T>(string file_name)
        {
            string abs_path = Path.Combine(Application.persistentDataPath, file_name);
            if (File.Exists(abs_path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(abs_path, FileMode.Open);
                T data = (T)formatter.Deserialize(stream);
                stream.Close();
                return data;
            }
            else
            {
                Debug.Log("No Key Found");
                return default;
            }
        }
        public static T GetKey<T>(string key)
        {
            string file_name = key + ".saload";
            Storage<T> storage = LoadObject<Storage<T>>(file_name);
            if (storage != null)
                return storage.data;
            return default;
        }
    }
}
