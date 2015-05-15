using System;
using BitHacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class IntTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void IsPowerOf2()
        {
            Assert.IsTrue(4.IsPowerOf2());
            Assert.IsFalse(3.IsPowerOf2());
            Assert.IsFalse(0.IsPowerOf2());
        }

        [TestMethod]
        public void NumberOfBitsSet()
        {
            Assert.AreEqual(4, ((int)Math.Pow(2, 4) - 1).NumberOfBitsSet());
            Assert.AreEqual(1, 16.NumberOfBitsSet());
            Assert.AreEqual(27, ((int)Math.Pow(2, 27) - 1).NumberOfBitsSet());
        }

        [TestMethod]
        public void GetParity()
        {
            Assert.IsTrue(2.GetParity());
            Assert.IsFalse(3.GetParity());
        }

        [TestMethod]
        public void MergeWithMask()
        {
            // 10 = 1010
            // 5  = 0101
            // 9 =  1001
            // m =  0011 = 3
            Assert.AreEqual(3, 10.MergeWithMask(5, 9));
        }

        [TestMethod]
        public void ReverseBits()
        {
            // 38 = (0000 * 6) 0010 0110
            // r  = 0110 0100 (0000 * 6) = ‭‭1677721600‬
            Assert.AreEqual(1677721600, 38.ReverseBits());
        }

        [TestMethod]
        public void ConsecutiveTrailing0Bits()
        {
            // 67292000 = ‭0100000000101100101101100000‬
            Assert.AreEqual(5, 67292000.ConsecutiveTrailing0Bits());
        }

        [TestMethod]
        public void ToNextPowerOf2()
        {
            Assert.AreEqual(4u, 3.ToNextPowerOf2());
            Assert.AreEqual(32u, 26.ToNextPowerOf2());
        }
    }
}
