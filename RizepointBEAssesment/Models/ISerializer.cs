using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace RizepointBEAssesment.Models
{
    public interface ISerializer
    {
        byte[] SerializeInterests(List<string> interests);

        List<string> DeserializeIntrests(byte[] intrestsBytes);
    }
}