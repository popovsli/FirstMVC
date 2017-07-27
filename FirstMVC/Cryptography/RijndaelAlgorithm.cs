using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Web;

namespace FirstMVC.Cryptography
{
    public class RijndaelAlgorithm
    {
        private MemoryStream stream = new MemoryStream();
        private byte[] result;

        public RijndaelAlgorithm(object objectData)
        {
            ObjectToStream(objectData);
        }

        public byte[] EncryptData()
        {
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                // assumes that the key and initialization vectors are already configured
                CryptoStream crypoStream = new CryptoStream(stream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write);
            }
            StreamToByteArray();
            return result;
        }

        public byte[] DecryptData()
        {
            //Sample of C# code that decodes from a stream
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                // assumes that the key and initialization vectors are already configured
                CryptoStream crypoStream = new CryptoStream(stream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Read);
            }
            StreamToByteArray();
            return result;
        }

        private void StreamToByteArray()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                result = ms.ToArray();
            }
        }

        public void ObjectToStream(object obj)
        {
            if (obj == null) return;
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, obj);
        }
               
    }
}