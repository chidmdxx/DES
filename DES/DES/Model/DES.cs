using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES.Model
{
    class DES
    {
        private string plaintext;
        private string ciphertext;
        private BitArray plainbits;
        private BitArray cipherbits;

        public string Plaintext
        {
            get { return plaintext; }
            set { plaintext = value; }
        }
        public string Ciphertext
        {
            get { return ciphertext; }
            set { ciphertext = value; }
        }

        private List<BitArray> plainbitslist;

        public List<BitArray> Plainbitslist
        {
            get { return plainbitslist; }
            set { plainbitslist = value; }
        }
        private List<BitArray> cipherbitslist;

        public List<BitArray> Cipherbitslist
        {
            get { return cipherbitslist; }
            set { cipherbitslist = value; }
        }

        public DES()
        {

        }

        private BitArray Sbox1(BitArray bits)
        {
            if (bits.Length != 6)
            {
                return null;
            }
            BitArray toReturn = null;
            int inner = bits.GetInnerBits().ToInt();

            if (!bits.Bit(1) && !bits.Bit(6))
            {
                switch (inner)
                {
                    case 0: toReturn = new BitArray(BitConverter.GetBytes(14));
                        break;
                    case 1: toReturn = new BitArray(BitConverter.GetBytes(4));
                        break;
                    case 2: toReturn = new BitArray(BitConverter.GetBytes(13));
                        break;
                    case 3: toReturn = new BitArray(BitConverter.GetBytes(1));
                        break;
                    case 4: toReturn = new BitArray(BitConverter.GetBytes(2));
                        break;
                    case 5: toReturn = new BitArray(BitConverter.GetBytes(15));
                        break;
                    case 6: toReturn = new BitArray(BitConverter.GetBytes(11));
                        break;
                    case 7: toReturn = new BitArray(BitConverter.GetBytes(8));
                        break;
                    case 8: toReturn = new BitArray(BitConverter.GetBytes(3));
                        break;
                    case 9: toReturn = new BitArray(BitConverter.GetBytes(10));
                        break;
                    case 10: toReturn = new BitArray(BitConverter.GetBytes(6));
                        break;
                    case 11: toReturn = new BitArray(BitConverter.GetBytes(12));
                        break;
                    case 12: toReturn = new BitArray(BitConverter.GetBytes(5));
                        break;
                    case 13: toReturn = new BitArray(BitConverter.GetBytes(9));
                        break;
                    case 14: toReturn = new BitArray(BitConverter.GetBytes(0));
                        break;
                    case 15: toReturn = new BitArray(BitConverter.GetBytes(7));
                        break;
                    default: return null;
                }
            }
            if (!bits.Bit(1) && bits.Bit(6))
            {
                switch (inner)
                {
                    case 0: toReturn = new BitArray(BitConverter.GetBytes(0));
                        break;
                    case 1: toReturn = new BitArray(BitConverter.GetBytes(15));
                        break;
                    case 2: toReturn = new BitArray(BitConverter.GetBytes(7));
                        break;
                    case 3: toReturn = new BitArray(BitConverter.GetBytes(4));
                        break;
                    case 4: toReturn = new BitArray(BitConverter.GetBytes(14));
                        break;
                    case 5: toReturn = new BitArray(BitConverter.GetBytes(2));
                        break;
                    case 6: toReturn = new BitArray(BitConverter.GetBytes(13));
                        break;
                    case 7: toReturn = new BitArray(BitConverter.GetBytes(1));
                        break;
                    case 8: toReturn = new BitArray(BitConverter.GetBytes(10));
                        break;
                    case 9: toReturn = new BitArray(BitConverter.GetBytes(6));
                        break;
                    case 10: toReturn = new BitArray(BitConverter.GetBytes(12));
                        break;
                    case 11: toReturn = new BitArray(BitConverter.GetBytes(11));
                        break;
                    case 12: toReturn = new BitArray(BitConverter.GetBytes(9));
                        break;
                    case 13: toReturn = new BitArray(BitConverter.GetBytes(5));
                        break;
                    case 14: toReturn = new BitArray(BitConverter.GetBytes(3));
                        break;
                    case 15: toReturn = new BitArray(BitConverter.GetBytes(8));
                        break;
                    default: return null;
                }
            }

            if (bits.Bit(1) && !bits.Bit(6))
            {
                switch (inner)
                {
                    case 0: toReturn = new BitArray(BitConverter.GetBytes(4));
                        break;
                    case 1: toReturn = new BitArray(BitConverter.GetBytes(1));
                        break;
                    case 2: toReturn = new BitArray(BitConverter.GetBytes(14));
                        break;
                    case 3: toReturn = new BitArray(BitConverter.GetBytes(8));
                        break;
                    case 4: toReturn = new BitArray(BitConverter.GetBytes(13));
                        break;
                    case 5: toReturn = new BitArray(BitConverter.GetBytes(6));
                        break;
                    case 6: toReturn = new BitArray(BitConverter.GetBytes(2));
                        break;
                    case 7: toReturn = new BitArray(BitConverter.GetBytes(11));
                        break;
                    case 8: toReturn = new BitArray(BitConverter.GetBytes(15));
                        break;
                    case 9: toReturn = new BitArray(BitConverter.GetBytes(12));
                        break;
                    case 10: toReturn = new BitArray(BitConverter.GetBytes(9));
                        break;
                    case 11: toReturn = new BitArray(BitConverter.GetBytes(7));
                        break;
                    case 12: toReturn = new BitArray(BitConverter.GetBytes(3));
                        break;
                    case 13: toReturn = new BitArray(BitConverter.GetBytes(10));
                        break;
                    case 14: toReturn = new BitArray(BitConverter.GetBytes(5));
                        break;
                    case 15: toReturn = new BitArray(BitConverter.GetBytes(0));
                        break;
                    default: return null;
                }
            }

            if (bits.Bit(1) && bits.Bit(6))
            {
                switch (inner)
                {
                    case 0: toReturn = new BitArray(BitConverter.GetBytes(15));
                        break;
                    case 1: toReturn = new BitArray(BitConverter.GetBytes(12));
                        break;
                    case 2: toReturn = new BitArray(BitConverter.GetBytes(8));
                        break;
                    case 3: toReturn = new BitArray(BitConverter.GetBytes(2));
                        break;
                    case 4: toReturn = new BitArray(BitConverter.GetBytes(4));
                        break;
                    case 5: toReturn = new BitArray(BitConverter.GetBytes(9));
                        break;
                    case 6: toReturn = new BitArray(BitConverter.GetBytes(1));
                        break;
                    case 7: toReturn = new BitArray(BitConverter.GetBytes(7));
                        break;
                    case 8: toReturn = new BitArray(BitConverter.GetBytes(5));
                        break;
                    case 9: toReturn = new BitArray(BitConverter.GetBytes(11));
                        break;
                    case 10: toReturn = new BitArray(BitConverter.GetBytes(3));
                        break;
                    case 11: toReturn = new BitArray(BitConverter.GetBytes(14));
                        break;
                    case 12: toReturn = new BitArray(BitConverter.GetBytes(10));
                        break;
                    case 13: toReturn = new BitArray(BitConverter.GetBytes(0));
                        break;
                    case 14: toReturn = new BitArray(BitConverter.GetBytes(6));
                        break;
                    case 15: toReturn = new BitArray(BitConverter.GetBytes(13));
                        break;
                    default: return null;
                }
            }

            toReturn.Length = 4;
            return toReturn;
        }



    }
}
