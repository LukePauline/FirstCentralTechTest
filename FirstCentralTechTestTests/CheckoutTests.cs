using FirstCentralTechTest;
using FirstCentralTechTestTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstCentralTechTestTests
{
    [TestClass]
    public class CheckoutTests
    {
        // In the future would probably want to cover this functionality with a few more tests. e.g. scanning multiple items
        [TestMethod]
        public void TestScanItem()
        {
            // Arrange
            var productRepo = new MockProductRepository();
            var specialOfferRepo = new MockSpecialOfferRepository();
            var checkout = new Checkout(productRepo, specialOfferRepo);

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
            var specialOfferRepo = new MockSpecialOfferRepository();
            var checkout = new Checkout(productRepo, specialOfferRepo);

            // Act
            checkout.ScanItem("A99");
            checkout.ScanItem("A99");
            checkout.ScanItem("A99");
            checkout.ScanItem("B15");
            checkout.ScanItem("B15");
            checkout.ScanItem("C40");
            checkout.ScanItem("B15");

            // Assert
            Assert.IsTrue(checkout.GetTotal() == 2.65);
        }
    }
}