namespace CashRegister
{
	public class Printer
	{
		public virtual void Print(string content)
		{
			if (content == string.Empty)
            {
				throw new PrinterOutOfPaperException();
            }

			// send message to a real printer
		}
	}
}
