namespace CashRegister
{
	public class Printer
	{
		public bool HasPrinted { get; private set; }
		public void Print(string content)
		{
			// send message to a real printer
			HasPrinted = true;
		}
	}
}
