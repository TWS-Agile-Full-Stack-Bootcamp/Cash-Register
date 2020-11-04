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
			var printer = new Printer();
			var cashRegister = new CashRegister(printer);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
		}
	}
}
