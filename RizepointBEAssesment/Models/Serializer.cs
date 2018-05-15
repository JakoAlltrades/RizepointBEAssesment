using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace RizepointBEAssesment.Models
{
    public class Serializer: ISerializer
    {
        public byte[] SerializeInterests(List<string> interests)
        {
            byte[] interestsBytes = null;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                var ms = new MemoryStream();
                bf.Serialize(ms, interests);
                interestsBytes = ms.ToArray();
            }
            catch(Exception e)
            {
                throw e;
            }
            return interestsBytes;
        }

        public List<string> DeserializeIntrests(byte[] intrestsBytes)
        {
            List<string> intrests = null;
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                var ms = new MemoryStream(intrestsBytes);
                intrests = (List<string>)bf.Deserialize(ms);
            }
            catch(Exception e)
            {
                throw e;
            }
            return intrests;
        }
    }
}