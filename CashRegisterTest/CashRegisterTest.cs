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
	}
}
