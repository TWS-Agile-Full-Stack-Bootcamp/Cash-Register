using System;
using CashRegister;

namespace CashRegisterTest
{
    public class FakePurchase : Purchase
    {
        public FakePurchase()
        {
        }

        public new string AsString()
        {
            return "fake purchase: " + base.AsString();
        }
    }
}
