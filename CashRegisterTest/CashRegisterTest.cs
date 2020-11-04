using System.Collections.Generic;
using Moq;

namespace CashRegisterTest
{
	using CashRegister;
	using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
			//given
			var printer = new Mock<Printer>();
			var cashRegister = new CashRegister(printer.Object);
			var purchase = new StubPurchase();
			//when
			cashRegister.Process(purchase);
			//then
			printer.Verify(_ => _.Print(purchase.AsString()));
		}

		[Fact]
		public void Should_throw_exception_when_printer_is_out_of_paper()
		{
			//given
			var printer = new StubPrinter();
			var cashRegister = new CashRegister(printer);
			var purchase = new Purchase();
			//when
			//then
			Assert.Throws<HardwareException>(() =>
			{
				cashRegister.Process(purchase);
			});
		}
	}

	internal class StubPrinter : Printer
	{
		public override void Print(string content)
		{
			throw new PrinterOutOfPaperException();
		}
	}

	internal class StubPurchase : Purchase
	{
		public override string AsString()
		{
			return "content";
		}
	}
}
