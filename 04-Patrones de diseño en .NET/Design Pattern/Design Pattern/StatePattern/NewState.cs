using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.StatePattern
{
    public class NewState : IState
    {
        public void Action(CustomerContext context, decimal amount)
        {
            Console.WriteLine($"Se le pone dinero a su saldo {amount}");
            context.Saldo = amount;
            context.SetState(new NotDebtorState());
        }
    }
}
