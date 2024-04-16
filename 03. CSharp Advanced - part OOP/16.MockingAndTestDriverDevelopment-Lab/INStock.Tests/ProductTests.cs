using INStock.Contracts;
using INStock.Models;
using NUnit.Framework;

namespace INStock.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Test_Product_Constructor_Works_Properly()
        {
            IProduct product = new Product("BMW", 350m, 3);
            Assert.IsNotNull(product);
            Assert.AreEqual("BMW",product.Label);
            Assert.AreEqual(350m, product.Price);
            Assert.AreEqual(3, product.Quantity);

        }

        [Test]
        public void CompareTo_Works_Correctly()
        {
            IProduct product = new Product("BMW", 850m, 6);
            IProduct product1 = new Product("Mercedes", 450m, 4);
            int result = product.CompareTo(product1);
            Assert.IsTrue(result == 1);
        }


    }
}
