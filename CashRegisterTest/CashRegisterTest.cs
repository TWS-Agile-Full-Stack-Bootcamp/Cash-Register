using System;
using Moq;

namespace CashRegisterTest
{
    using CashRegister;
    using Xunit;

    public class CashRegisterTest
    {
        [Fact]
        public void Should_Process_Execute_Printing()
        {
            //given
            var mockPrinter = new Mock<Printer>();
            mockPrinter.Setup(p => p.Print(It.IsAny<string>()));
            var cashRegister = new CashRegister(mockPrinter.Object);
            var purchase = new Purchase();
            //when
            cashRegister.Process(purchase);
            //then
            //verify that cashRegister.process will trigger print
            mockPrinter.Verify(printer => printer.Print(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Should_throw_exception_when_purchase_AsString_return_emtpy()
        {
            //given
            var mockPrinter = new Mock<Printer>();
            mockPrinter.Setup(printer => printer.Print(string.Empty)).Throws<PrinterOutOfPaperException>();
            var mockPurchase = new Mock<Purchase>();
            mockPurchase.Setup(purchase => purchase.AsString()).Returns(string.Empty);
            var cashRegister = new CashRegister(mockPrinter.Object);
            //when
            var hardwareException = Assert.Throws<HardwareException>(() =>
            {
                cashRegister.Process(mockPurchase.Object);
            });

            //then
            Assert.Equal("Printer is out of paper.", hardwareException.Message);
        }
    }
}