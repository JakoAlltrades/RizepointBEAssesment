using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizepointBEAssesment.Models
{
    public class SerializeHandler
    {
        private readonly ISerializer serializer;

        public SerializeHandler(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        public byte[] HandleSerialize(List<string> interests)
        {
            return serializer.SerializeInterests(interests);
        }

        public List<string> HandleDeserializer(byte[] serializedInterests)
        {
            return serializer.DeserializeIntrests(serializedInterests);
        }
    }
}