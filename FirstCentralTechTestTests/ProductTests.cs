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

        [TestMethod]
        public void TestGetTotalPrice()
        {
            // Arrange
            var productRepo = new MockProductRepository();
            var checkout = new Checkout(productRepo);

            // Act
            checkout.ScanItem("A99");
            checkout.ScanItem("A99");
            checkout.ScanItem("A99");
            checkout.ScanItem("B15");
            checkout.ScanItem("C40");
            checkout.ScanItem("B15");

            // Assert
            Assert.IsTrue(checkout.GetTotal() == 2.7);
        }
    }
}