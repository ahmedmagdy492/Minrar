using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minrar_Archiver.Services
{
    public static class Util
    {
        public static double ConvertByteToMB(long byteNumber)
        {
            return byteNumber / 1000_000.0;
        }

        public static int GetFilenameLengthInBytes(string filename)
        {
            int length = 0;

            foreach(char c in filename)
            {
                length += Encoding.UTF8.GetBytes(c.ToString()).Length;
            }

            return length;
        }
    }
}
