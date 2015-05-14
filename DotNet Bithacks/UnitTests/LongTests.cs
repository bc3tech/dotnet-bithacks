using BitHacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LongTests
    {
        [TestMethod]
        public void IsPowerOf2()
        {
            Assert.IsTrue(4UL.IsPowerOf2());
            Assert.IsFalse(3UL.IsPowerOf2());
            Assert.IsFalse(0UL.IsPowerOf2());
        }
    }
}
