using FirstCentralTechTest;
using FirstCentralTechTestTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstCentralTechTestTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestScanItem()
        {
            // Arrange
            var productRepo = new MockProductRepository();
            var checkout = new Checkout(productRepo);

            // Act
            checkout.ScanItem("A99");

            // Assert
            Assert.IsTrue(checkout.Cart["A99"] == 1);
        }
    }
}