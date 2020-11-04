namespace CashRegisterTest
{
	using CashRegister;
	using Moq;
	using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_Process_Execute_Printing()
		{
            //given
            var mock = new Mock<Printer>();
            mock.Setup(printer => printer.Print(It.IsAny<string>()));

            var cashRegister = new CashRegister(mock.Object);
            Purchase purchase = new Purchase();
            //when
            cashRegister.Process(purchase);

            //then
            //verify that cashRegister.process will trigger print
            mock.Verify(mock => mock.Print(It.IsAny<string>()), Times.Once());
		}

		[Fact]
		public void Should_Process_Execute_Printing_Using_Fake_Printer()
		{
            //given
            var mock = new Mock<FakePrinter>();
            mock.Setup(printer => printer.Print(It.IsAny<string>()));

            var cashRegister = new CashRegister(mock.Object);
            Purchase purchase = new Purchase();
            //when
            cashRegister.Process(purchase);

            //then
            //verify that cashRegister.process will trigger print
            mock.Verify(mock => mock.Print(It.IsAny<string>()), Times.Once());
		}

		[Fact]
		public void Should_Process_Execute_Printing_Using_Fake_Printer_And_Fake_Purchase()
        {
            //given
            var mock = new Mock<FakePrinter>();
            mock.Setup(printer => printer.Print(It.IsAny<string>()));

            var cashRegister = new CashRegister(mock.Object);
            FakePurchase purchase = new FakePurchase();
            //when
            cashRegister.Process(purchase);

            //then
            //verify that cashRegister.process will trigger print
            mock.Verify(fakePrinter => fakePrinter.Print(It.IsAny<string>()), Times.Once());
        }
    }
}
