
using System;
namespace BitHacks
{
    public static class LongExtensions
    {
        /// <summary>Number of bits per byte</summary>
        const byte CHAR_BIT = 8;

        /// <summary>
        /// Determines whether [is power of2].
        /// </summary>
        /// <param name="v">This instance.</param>
        /// <returns></returns>
        public static bool IsPowerOf2(this ulong v)
        {
            return v > 0 && ((v & (v - 1)) == 0);
        }

        /// <summary>
        /// Sign extends this value.
        /// </summary>
        /// <param name="x">This instance.</param>
        /// <param name="sourceBitCount"># of bits used by this instance's value</param>
        /// <returns></returns>
        public static ulong SignExtend(this ulong x, int sourceBitCount)
        {
            var m = 1U << (sourceBitCount - 1); // mask can be pre-computed if b is fixed

            x &= ((1U << sourceBitCount) - 1);  // (Skip this if bits in x above position b are already zero.)
            return (x ^ m) - m;
        }

        public static ulong SetBits(this ulong x, ulong mask)
        {
            return SetOrClearBits(true, mask, x);
        }

        public static ulong ClearBits(this ulong x, ulong mask)
        {
            return SetOrClearBits(false, mask, x);
        }

        private static ulong SetOrClearBits(bool f, ulong m, ulong w)
        {
            return (w & ~m) | (Convert.ToUInt64(!f) & m);
        }

        /// <summary>
        /// Merges this value with another according to a mask.
        /// </summary>
        /// <param name="me">This instance.</param>
        /// <param name="other">value to merge in masked bits</param>
        /// <param name="mask">1 where bits from <paramref name="other"/> should be selected; 0 where from this instance.</param>
        /// <returns></returns>
        public static ulong MergeWithMask(this ulong me, ulong other, ulong mask)
        {
            return me ^ ((me ^ other) & mask);
        }

        /// <summary>
        /// Determines the number of bits set in the value
        /// </summary>
        /// <param name="v">This instance.</param>
        /// <returns></returns>
        public static byte NumberOfBitsSet(this ulong v)
        {
            byte c; // c accumulates the total bits set in v
            for (c = 0; v > 0; c++)
            {
                v &= v - 1; // clear the least significant bit set
            }
            return c;
        }

        /// <summary>
        /// Gets the parity of this instance
        /// </summary>
        /// <param name="v">This instance.</param>
        /// <returns></returns>
        public static bool GetParity(this ulong v)
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
        public static ulong ReverseBits(this ulong v)
        {
            ulong r = v; // r will be reversed bits of v; first get LSB of v
            int s = sizeof(ulong) * CHAR_BIT - 1; // extra shift needed at end

            for (v >>= 1; v > 0; v >>= 1)
            {
                r <<= 1;
                r |= v & 1;
                s--;
            }
            r <<= s; // shift when v's highest bits are zero
            return r;
        }
    }
}
