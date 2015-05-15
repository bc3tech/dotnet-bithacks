
using System;
namespace BitHacks
{
    public static class IntExtensions
    {
        /// <summary>Number of bits per byte</summary>
        private const byte BITS_PER_BYTE = 8;

        /// <summary>
        /// Determines whether [is power of2].
        /// </summary>
        /// <param name="v">This instance.</param>
        /// <returns></returns>
        public static bool IsPowerOf2(this int v)
        {
            return v > 0 && ((v & (v - 1)) == 0);
        }

        /// <summary>
        /// Merges this value with another according to a mask.
        /// </summary>
        /// <param name="me">This instance.</param>
        /// <param name="other">value to merge in masked bits</param>
        /// <param name="mask">1 where bits from <paramref name="other"/> should be selected; 0 where from this instance.</param>
        /// <returns></returns>
        public static int MergeWithMask(this int me, int other, int mask)
        {
            return me ^ ((me ^ other) & mask);
        }

        /// <summary>
        /// Determines the number of bits set in the value
        /// </summary>
        /// <param name="v">This instance.</param>
        /// <returns></returns>
        public static byte NumberOfBitsSet(this int v)
        {
            byte c; // c accumulates the total bits set in v
            for (c = 0; v > 0; c++)
            {
                v &= v - 1; // clear the least significant bit set
            }
            return c;
        }

        /// <summary>
        /// Gets the parity of this instance (odd parity)
        /// </summary>
        /// <param name="v">This instance.</param>
        /// <returns></returns>
        public static bool GetParity(this int v)
        {
            bool parity = false;  // parity will be the parity of v

            while (v > 0)
            {
                parity = !parity;
                v = v & (v - 1);
            }

            return parity;
        }

        /// <summary>
        /// Reverses the bits of this instance
        /// </summary>
        /// <param name="v">This instance.</param>
        /// <returns></returns>
        public static int ReverseBits(this int v)
        {
            int r = v; // r will be reversed bits of v; first get LSB of v
            int s = sizeof(int) * BITS_PER_BYTE - 1; // extra shift needed at end

            for (v >>= 1; v > 0; v >>= 1)
            {
                r <<= 1;
                r |= v & 1;
                s--;
            }
            r <<= s; // shift when v's highest bits are zero
            return r;
        }

        /// <summary>
        /// Computes LogBase2 of this instance
        /// </summary>
        /// <param name="v">This instance.</param>
        /// <returns></returns>
        public static int LogBase2(this int v)
        {
            var b = new uint[] { 0x2, 0xC, 0xF0, 0xFF00, 0xFFFF0000 };
            var S = new int[] { 1, 2, 4, 8, 16 };
            int i;

            int r = 0; // result of log2(v) will go here
            for (i = 4; i >= 0; i--) // unroll for speed...
            {
                if ((v & b[i]) > 0)
                {
                    v >>= S[i];
                    r |= S[i];
                }
            }
            return r;
        }

        public static int LogBase10(this int v)
        {
            return (v >= 1000000000) ? 9 : (v >= 100000000) ? 8 : (v >= 10000000) ? 7 :
                (v >= 1000000) ? 6 : (v >= 100000) ? 5 : (v >= 10000) ? 4 :
                (v >= 1000) ? 3 : (v >= 100) ? 2 : (v >= 10) ? 1 : 0;

        }
    }
}
