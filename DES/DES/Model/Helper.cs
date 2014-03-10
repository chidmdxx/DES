using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES.Model
{
    static class Helper
    {
        public static bool Bit (this BitArray bits, int index) //hace que la little endian class de BitArray se lea como big endian
        {
            return bits[bits.Length - index];
        }

        public static void Bit(this BitArray bits, int index, bool value) //asigna valores como big endian
        {
            bits[bits.Length - index] = value;
        }

        public static byte[] ToByteArray(this BitArray bits)
        {
            int numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++; //evita que sea divisible entre 0

            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex)); //arma los bytes

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }

            return bytes;
        }

        public static int ToInt(this BitArray bits)
        {
            int toReturn = 0;
            for (var i = 0; i < bits.Length; i++)
            {
                toReturn += bits[i] ? (int)Math.Pow(2, i) : 0;
            }
            return toReturn;
        }

        public static void ShiftLeft(this BitArray bits)
        {
            bool first = bits.Bit(1); //guardar el primero
            for (var i=2;i<=bits.Length;i++)
            {
                bits[i - 1] = bits[i];
            }
            bits[bits.Length] = first;
        }

        public static BitArray GetInnerBits(this BitArray bits)
        {
            BitArray toReturn=new BitArray(bits);
            for (var i=1;i<bits.Length;i++)
            {
                toReturn[i - 1] = toReturn[i];
            }
            toReturn.Length = toReturn.Length - 2;
            return toReturn;
        }
    }
}
