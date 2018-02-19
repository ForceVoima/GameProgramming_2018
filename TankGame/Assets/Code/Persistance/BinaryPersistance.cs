using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TankGame.Persistance
{
    public class BinaryPersistance : IPersistance
    {
        public string Extension
        {
            get
            {
                return ".bin";
            }
        }

        public string FilePath
        {
            get; private set;
        }

        public BinaryPersistance(string path)
        {
            FilePath = path + Extension;
        }

        public void Save<T>(T data)
        {
            using (FileStream stream = File.OpenWrite(FilePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, data);
                stream.Close();
            }
        }

        public T Load<T>()
        {
            T data = default(T);
            FileStream stream = File.OpenRead(FilePath);

            if (File.Exists(FilePath))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    data = (T)bf.Deserialize(stream);
                    stream.Close();

                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    stream.Close();
                }
            }

            return data;
        }
    }
}
