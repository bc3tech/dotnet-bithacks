
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
    }
}
