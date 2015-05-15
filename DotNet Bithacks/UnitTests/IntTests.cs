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
        public void LogBase2()
        {
            for (int i = 0; i < 31; i++)
            {
                this.TestContext.WriteLine("Math.Pow(2,{0}) = {1}", i, Math.Pow(2, i));
                Assert.AreEqual(i, ((int)Math.Pow(2, i)).LogBase2());
            }
        }

        [TestMethod]
        public void LogBase10()
        {
            for (int i = 0; i < 10; i++)
            {
                this.TestContext.WriteLine("Math.Pow(10,{0}) = {1}", i, Math.Pow(10, i));
                Assert.AreEqual(i, ((int)Math.Pow(10, i)).LogBase10());
            }
        }
    }
}
