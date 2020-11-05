using System;
using CashRegister;

namespace CashRegisterTest
{
    public class FakePrinter : Printer
    {
        public override void Print(string content)
        {
            // send message to a fake printer
        }
    }
}
