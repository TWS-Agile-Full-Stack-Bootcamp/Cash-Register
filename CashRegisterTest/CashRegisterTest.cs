using System.Collections.Generic;

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
			var printer = new SpyPrinter();
			var cashRegister = new CashRegister(printer);
			var purchase = new StubPurchase();
			//when
			cashRegister.Process(purchase);
			//then
			Assert.True(printer.HasPrinted);
			Assert.Equal(purchase.AsString(), printer.ContentPrinted);
		}
	}

	internal class StubPurchase : Purchase
	{
		public override string AsString()
		{
			return "content";
		}
	}

	internal class SpyPrinter : Printer
	{
		public bool HasPrinted { get; private set; }
		public string ContentPrinted { get; private set; }

		public override void Print(string content)
		{
			base.Print(content);
			HasPrinted = true;
			ContentPrinted = content;
		}
	}
}
