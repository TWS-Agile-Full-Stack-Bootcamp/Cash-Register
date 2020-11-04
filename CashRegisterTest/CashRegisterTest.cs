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
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			Assert.True(printer.HasPrinted);
		}
	}

	internal class SpyPrinter : Printer
	{
		public bool HasPrinted { get; private set; }
		public override void Print(string content)
		{
			base.Print(content);
			HasPrinted = true;
		}
	}
}
