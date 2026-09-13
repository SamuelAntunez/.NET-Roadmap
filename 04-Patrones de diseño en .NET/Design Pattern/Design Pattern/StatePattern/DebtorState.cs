using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.StatePattern
{
    public class DebtorState : IState
    {
        public void Action(CustomerContext context, decimal amount)
        {
            Console.WriteLine($"El cliente es deudor. Se le aplica una acción.");
        }
    }
}
