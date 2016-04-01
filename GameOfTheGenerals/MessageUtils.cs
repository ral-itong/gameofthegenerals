using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace GameOfTheGenerals
{
    public class MessageUtils
    {
        public static byte[] Serialize<T>(T data)
            where T : struct
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, data);
            return stream.ToArray();
        }
    }
}
