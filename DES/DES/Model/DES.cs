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

        private BitArray InitialPermutation(BitArray bits)
        {
            if (bits.Length != 64)
            {
                return null;
            }
            var toReturn = new BitArray(bits.Length);
            #region asignaciones de los valores
            toReturn.Bit(1, bits.Bit(58));
            toReturn.Bit(2, bits.Bit(50));
            toReturn.Bit(3, bits.Bit(42));
            toReturn.Bit(4, bits.Bit(34));
            toReturn.Bit(5, bits.Bit(26));
            toReturn.Bit(6, bits.Bit(18));
            toReturn.Bit(7, bits.Bit(10));
            toReturn.Bit(8, bits.Bit(2));
            toReturn.Bit(9, bits.Bit(60));
            toReturn.Bit(10, bits.Bit(52));
            toReturn.Bit(11, bits.Bit(44));
            toReturn.Bit(12, bits.Bit(36));
            toReturn.Bit(13, bits.Bit(28));
            toReturn.Bit(14, bits.Bit(20));
            toReturn.Bit(15, bits.Bit(12));
            toReturn.Bit(16, bits.Bit(4));
            toReturn.Bit(17, bits.Bit(62));
            toReturn.Bit(18, bits.Bit(54));
            toReturn.Bit(19, bits.Bit(46));
            toReturn.Bit(20, bits.Bit(38));
            toReturn.Bit(21, bits.Bit(30));
            toReturn.Bit(22, bits.Bit(22));
            toReturn.Bit(23, bits.Bit(14));
            toReturn.Bit(24, bits.Bit(6));
            toReturn.Bit(25, bits.Bit(64));
            toReturn.Bit(26, bits.Bit(56));
            toReturn.Bit(27, bits.Bit(48));
            toReturn.Bit(28, bits.Bit(40));
            toReturn.Bit(29, bits.Bit(32));
            toReturn.Bit(30, bits.Bit(24));
            toReturn.Bit(31, bits.Bit(16));
            toReturn.Bit(32, bits.Bit(8));
            toReturn.Bit(33, bits.Bit(57));
            toReturn.Bit(34, bits.Bit(49));
            toReturn.Bit(35, bits.Bit(41));
            toReturn.Bit(36, bits.Bit(33));
            toReturn.Bit(37, bits.Bit(25));
            toReturn.Bit(38, bits.Bit(17));
            toReturn.Bit(39, bits.Bit(9));
            toReturn.Bit(40, bits.Bit(1));
            toReturn.Bit(41, bits.Bit(59));
            toReturn.Bit(42, bits.Bit(51));
            toReturn.Bit(43, bits.Bit(43));
            toReturn.Bit(44, bits.Bit(35));
            toReturn.Bit(45, bits.Bit(27));
            toReturn.Bit(46, bits.Bit(19));
            toReturn.Bit(47, bits.Bit(11));
            toReturn.Bit(48, bits.Bit(3));
            toReturn.Bit(49, bits.Bit(61));
            toReturn.Bit(50, bits.Bit(53));
            toReturn.Bit(51, bits.Bit(45));
            toReturn.Bit(52, bits.Bit(37));
            toReturn.Bit(53, bits.Bit(29));
            toReturn.Bit(54, bits.Bit(21));
            toReturn.Bit(55, bits.Bit(13));
            toReturn.Bit(56, bits.Bit(5));
            toReturn.Bit(57, bits.Bit(63));
            toReturn.Bit(58, bits.Bit(55));
            toReturn.Bit(59, bits.Bit(47));
            toReturn.Bit(60, bits.Bit(39));
            toReturn.Bit(61, bits.Bit(31));
            toReturn.Bit(62, bits.Bit(23));
            toReturn.Bit(63, bits.Bit(15));
            toReturn.Bit(64, bits.Bit(7));
            #endregion

            return toReturn;
        }

        private BitArray InverseInitialPermutation(BitArray bits)
        {
            if (bits.Length != 64)
            {
                return null;
            }
            var toReturn = new BitArray(bits.Length);
            #region asignaciones de los valores
            toReturn.Bit(1, bits.Bit(40));
            toReturn.Bit(2, bits.Bit(8));
            toReturn.Bit(3, bits.Bit(48));
            toReturn.Bit(4, bits.Bit(16));
            toReturn.Bit(5, bits.Bit(56));
            toReturn.Bit(6, bits.Bit(24));
            toReturn.Bit(7, bits.Bit(64));
            toReturn.Bit(8, bits.Bit(32));
            toReturn.Bit(9, bits.Bit(39));
            toReturn.Bit(10, bits.Bit(7));
            toReturn.Bit(11, bits.Bit(47));
            toReturn.Bit(12, bits.Bit(15));
            toReturn.Bit(13, bits.Bit(55));
            toReturn.Bit(14, bits.Bit(23));
            toReturn.Bit(15, bits.Bit(63));
            toReturn.Bit(16, bits.Bit(31));
            toReturn.Bit(17, bits.Bit(38));
            toReturn.Bit(18, bits.Bit(6));
            toReturn.Bit(19, bits.Bit(46));
            toReturn.Bit(20, bits.Bit(14));
            toReturn.Bit(21, bits.Bit(54));
            toReturn.Bit(22, bits.Bit(22));
            toReturn.Bit(23, bits.Bit(62));
            toReturn.Bit(24, bits.Bit(30));
            toReturn.Bit(25, bits.Bit(37));
            toReturn.Bit(26, bits.Bit(5));
            toReturn.Bit(27, bits.Bit(45));
            toReturn.Bit(28, bits.Bit(13));
            toReturn.Bit(29, bits.Bit(53));
            toReturn.Bit(30, bits.Bit(21));
            toReturn.Bit(31, bits.Bit(61));
            toReturn.Bit(32, bits.Bit(29));
            toReturn.Bit(33, bits.Bit(36));
            toReturn.Bit(34, bits.Bit(4));
            toReturn.Bit(35, bits.Bit(44));
            toReturn.Bit(36, bits.Bit(12));
            toReturn.Bit(37, bits.Bit(52));
            toReturn.Bit(38, bits.Bit(20));
            toReturn.Bit(39, bits.Bit(60));
            toReturn.Bit(40, bits.Bit(28));
            toReturn.Bit(41, bits.Bit(35));
            toReturn.Bit(42, bits.Bit(3));
            toReturn.Bit(43, bits.Bit(43));
            toReturn.Bit(44, bits.Bit(11));
            toReturn.Bit(45, bits.Bit(51));
            toReturn.Bit(46, bits.Bit(19));
            toReturn.Bit(47, bits.Bit(59));
            toReturn.Bit(48, bits.Bit(27));
            toReturn.Bit(49, bits.Bit(34));
            toReturn.Bit(50, bits.Bit(2));
            toReturn.Bit(51, bits.Bit(42));
            toReturn.Bit(52, bits.Bit(10));
            toReturn.Bit(53, bits.Bit(50));
            toReturn.Bit(54, bits.Bit(18));
            toReturn.Bit(55, bits.Bit(58));
            toReturn.Bit(56, bits.Bit(26));
            toReturn.Bit(57, bits.Bit(33));
            toReturn.Bit(58, bits.Bit(1));
            toReturn.Bit(59, bits.Bit(41));
            toReturn.Bit(60, bits.Bit(9));
            toReturn.Bit(61, bits.Bit(49));
            toReturn.Bit(62, bits.Bit(17));
            toReturn.Bit(63, bits.Bit(57));
            toReturn.Bit(64, bits.Bit(25));
            #endregion

            return toReturn;
        }

        private List<BitArray> ExpansionPermutation(BitArray bits)
        {
            if (bits.Length != 32)
            {
                return null;
            }
            var toReturn = new List<BitArray>();
            for (var i = 0; i < 8; i++)
            {
                var temp = new BitArray(6);
                temp.Bit(2, bits.Bit((i * 4) + 1));
                temp.Bit(3, bits.Bit((i * 4) + 2));
                temp.Bit(4, bits.Bit((i * 4) + 3));
                temp.Bit(5, bits.Bit((i * 4) + 4));

                int assign = i == 0 ? 32 : ((i + 1) * 4) + 1;
                temp.Bit(1, bits.Bit(assign));
                assign = i == 7 ? 1 : ((i + 1) * 4) + 1;
                temp.Bit(6, bits.Bit(assign));
                toReturn.Add(temp);
            }

            return toReturn;
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
            else if (!bits.Bit(1) && bits.Bit(6))
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

            else if (bits.Bit(1) && !bits.Bit(6))
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

            else if (bits.Bit(1) && bits.Bit(6))
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

        private BitArray Sbox2(BitArray bits)
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
                    case 0: toReturn = new BitArray(BitConverter.GetBytes(15));
                        break;
                    case 1: toReturn = new BitArray(BitConverter.GetBytes(1));
                        break;
                    case 2: toReturn = new BitArray(BitConverter.GetBytes(8));
                        break;
                    case 3: toReturn = new BitArray(BitConverter.GetBytes(14));
                        break;
                    case 4: toReturn = new BitArray(BitConverter.GetBytes(6));
                        break;
                    case 5: toReturn = new BitArray(BitConverter.GetBytes(11));
                        break;
                    case 6: toReturn = new BitArray(BitConverter.GetBytes(3));
                        break;
                    case 7: toReturn = new BitArray(BitConverter.GetBytes(4));
                        break;
                    case 8: toReturn = new BitArray(BitConverter.GetBytes(9));
                        break;
                    case 9: toReturn = new BitArray(BitConverter.GetBytes(7));
                        break;
                    case 10: toReturn = new BitArray(BitConverter.GetBytes(2));
                        break;
                    case 11: toReturn = new BitArray(BitConverter.GetBytes(13));
                        break;
                    case 12: toReturn = new BitArray(BitConverter.GetBytes(12));
                        break;
                    case 13: toReturn = new BitArray(BitConverter.GetBytes(0));
                        break;
                    case 14: toReturn = new BitArray(BitConverter.GetBytes(5));
                        break;
                    case 15: toReturn = new BitArray(BitConverter.GetBytes(10));
                        break;
                    default: return null;
                }
            }
            else if (!bits.Bit(1) && bits.Bit(6))
            {
                switch (inner)
                {
                    case 0: toReturn = new BitArray(BitConverter.GetBytes(3));
                        break;
                    case 1: toReturn = new BitArray(BitConverter.GetBytes(13));
                        break;
                    case 2: toReturn = new BitArray(BitConverter.GetBytes(4));
                        break;
                    case 3: toReturn = new BitArray(BitConverter.GetBytes(7));
                        break;
                    case 4: toReturn = new BitArray(BitConverter.GetBytes(15));
                        break;
                    case 5: toReturn = new BitArray(BitConverter.GetBytes(2));
                        break;
                    case 6: toReturn = new BitArray(BitConverter.GetBytes(8));
                        break;
                    case 7: toReturn = new BitArray(BitConverter.GetBytes(14));
                        break;
                    case 8: toReturn = new BitArray(BitConverter.GetBytes(12));
                        break;
                    case 9: toReturn = new BitArray(BitConverter.GetBytes(0));
                        break;
                    case 10: toReturn = new BitArray(BitConverter.GetBytes(1));
                        break;
                    case 11: toReturn = new BitArray(BitConverter.GetBytes(10));
                        break;
                    case 12: toReturn = new BitArray(BitConverter.GetBytes(6));
                        break;
                    case 13: toReturn = new BitArray(BitConverter.GetBytes(9));
                        break;
                    case 14: toReturn = new BitArray(BitConverter.GetBytes(11));
                        break;
                    case 15: toReturn = new BitArray(BitConverter.GetBytes(5));
                        break;
                    default: return null;
                }
            }

            else if (bits.Bit(1) && !bits.Bit(6))
            {
                switch (inner)
                {
                    case 0: toReturn = new BitArray(BitConverter.GetBytes(0));
                        break;
                    case 1: toReturn = new BitArray(BitConverter.GetBytes(14));
                        break;
                    case 2: toReturn = new BitArray(BitConverter.GetBytes(7));
                        break;
                    case 3: toReturn = new BitArray(BitConverter.GetBytes(11));
                        break;
                    case 4: toReturn = new BitArray(BitConverter.GetBytes(10));
                        break;
                    case 5: toReturn = new BitArray(BitConverter.GetBytes(4));
                        break;
                    case 6: toReturn = new BitArray(BitConverter.GetBytes(13));
                        break;
                    case 7: toReturn = new BitArray(BitConverter.GetBytes(1));
                        break;
                    case 8: toReturn = new BitArray(BitConverter.GetBytes(5));
                        break;
                    case 9: toReturn = new BitArray(BitConverter.GetBytes(8));
                        break;
                    case 10: toReturn = new BitArray(BitConverter.GetBytes(12));
                        break;
                    case 11: toReturn = new BitArray(BitConverter.GetBytes(6));
                        break;
                    case 12: toReturn = new BitArray(BitConverter.GetBytes(9));
                        break;
                    case 13: toReturn = new BitArray(BitConverter.GetBytes(3));
                        break;
                    case 14: toReturn = new BitArray(BitConverter.GetBytes(2));
                        break;
                    case 15: toReturn = new BitArray(BitConverter.GetBytes(15));
                        break;
                    default: return null;
                }
            }

            else if (bits.Bit(1) && bits.Bit(6))
            {
                switch (inner)
                {
                    case 0: toReturn = new BitArray(BitConverter.GetBytes(13));
                        break;
                    case 1: toReturn = new BitArray(BitConverter.GetBytes(8));
                        break;
                    case 2: toReturn = new BitArray(BitConverter.GetBytes(10));
                        break;
                    case 3: toReturn = new BitArray(BitConverter.GetBytes(1));
                        break;
                    case 4: toReturn = new BitArray(BitConverter.GetBytes(3));
                        break;
                    case 5: toReturn = new BitArray(BitConverter.GetBytes(15));
                        break;
                    case 6: toReturn = new BitArray(BitConverter.GetBytes(4));
                        break;
                    case 7: toReturn = new BitArray(BitConverter.GetBytes(2));
                        break;
                    case 8: toReturn = new BitArray(BitConverter.GetBytes(11));
                        break;
                    case 9: toReturn = new BitArray(BitConverter.GetBytes(6));
                        break;
                    case 10: toReturn = new BitArray(BitConverter.GetBytes(7));
                        break;
                    case 11: toReturn = new BitArray(BitConverter.GetBytes(12));
                        break;
                    case 12: toReturn = new BitArray(BitConverter.GetBytes(0));
                        break;
                    case 13: toReturn = new BitArray(BitConverter.GetBytes(5));
                        break;
                    case 14: toReturn = new BitArray(BitConverter.GetBytes(14));
                        break;
                    case 15: toReturn = new BitArray(BitConverter.GetBytes(9));
                        break;
                    default: return null;
                }
            }

            toReturn.Length = 4;
            return toReturn;
        }

    }
}
