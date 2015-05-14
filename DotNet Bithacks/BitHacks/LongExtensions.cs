
namespace BitHacks
{
    public static class LongExtensions
    {
        /// <summary>Number of bits per byte</summary>
        const byte CHAR_BIT = 8;

        public static bool IsPowerOf2(this ulong v)
        {
            return v > 0 && ((v & (v - 1)) == 0);
        }
    }
}
