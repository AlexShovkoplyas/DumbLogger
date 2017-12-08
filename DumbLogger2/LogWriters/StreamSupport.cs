using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DumbLogger.LogWriters
{
    static class StreamSupport
    {
        public static void WriteString(string text, FileStream fileStream)
        {
            byte[] textToByteArray = Encoding.Default.GetBytes(text);
            fileStream.Write(textToByteArray, 0, textToByteArray.Length);
        }
    }
}
