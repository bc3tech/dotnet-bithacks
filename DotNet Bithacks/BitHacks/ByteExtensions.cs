using System;

namespace BitHacks
{
    public static class ByteExtensions
    {
        public static byte ReverseBits(this byte b)
        {
            return Convert.ToByte(((b * 0x0202020202UL) & 0x010884422010UL) % 1023);
        }
    }
}
