
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
        /// Gets the number of consecutive trailing bits in this instance
        /// </summary>
        /// <param name="v">This instance.</param>
        /// <returns></returns>
        public static byte ConsecutiveTrailing0Bits(this int v)
        {
            byte c;     // c will be the number of zero bits on the right,
                        // so if v is 1101000 (base 2), then c will be 3
                        // NOTE: if 0 == v, then c = 31.
            if ((v & 1) > 0)
            {
                // special case for odd v (assumed to happen half of the time)
                c = 0;
            }
            else
            {
                c = 1;
                if ((v & 0xffff) == 0)
                {
                    v >>= 16;
                    c += 16;
                }
                if ((v & 0xff) == 0)
                {
                    v >>= 8;
                    c += 8;
                }
                if ((v & 0xf) == 0)
                {
                    v >>= 4;
                    c += 4;
                }
                if ((v & 0x3) == 0)
                {
                    v >>= 2;
                    c += 2;
                }
                c -= (byte)(v & 1);
            }
            return c;
        }
    }
}
