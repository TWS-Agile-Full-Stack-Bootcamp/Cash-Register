using System;
using CashRegister;

namespace CashRegisterTest
{
    public class FakePurchase : Purchase
    {
        public FakePurchase()
        {
        }

        public override string AsString()
        {
            return string.Empty;
        }
    }
}
