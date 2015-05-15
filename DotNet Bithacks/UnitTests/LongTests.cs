using System;
using BitHacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LongTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void IsPowerOf2()
        {
            Assert.IsTrue(4UL.IsPowerOf2());
            Assert.IsFalse(3UL.IsPowerOf2());
            Assert.IsFalse(0UL.IsPowerOf2());
        }

        [TestMethod]
        public void NumberOfBitsSet()
        {
            Assert.AreEqual(4, ((ulong)Math.Pow(2, 4) - 1).NumberOfBitsSet());
            Assert.AreEqual(1, 16UL.NumberOfBitsSet());
            Assert.AreEqual(27, ((ulong)Math.Pow(2, 27) - 1).NumberOfBitsSet());
        }

        [TestMethod]
        public void GetParity()
        {
            Assert.IsTrue(2UL.GetParity());
            Assert.IsFalse(3UL.GetParity());
        }

        [TestMethod]
        public void MergeWithMask()
        {
            // 10 = 1010
            // 5  = 0101
            // 9 =  1001
            // m =  0011 = 3
            Assert.AreEqual(3UL, 10UL.MergeWithMask(5, 9));
        }

        [TestMethod]
        public void ReverseBits()
        {
            // 38 = (0000 * 14) 0010 0110
            // r  = 0110 0100 (0000 * 14) = ‭7205759403792793664‬
            Assert.AreEqual(7205759403792793600UL, 38UL.ReverseBits());
        }
    }
}
