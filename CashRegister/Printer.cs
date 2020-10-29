namespace CashRegister
{
	public class Printer
	{
		public void Print(string content) => throw new PrinterOutOfPaperException();
	}
}
