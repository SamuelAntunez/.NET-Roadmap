using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.StatePattern
{
    public class NotDebtorState : IState
    {
        public void Action(CustomerContext context, decimal amount)
        {
            if(amount <= context.Saldo)
            {
                context.Discount(amount);
                Console.WriteLine($"Solicitud permitida, gasta {amount} y le queda {context.Saldo}");
                if (context.Saldo <= 0) context.SetState(new DebtorState());
            } else
            {
                Console.WriteLine($"Solicitud denegada, no tiene suficiente saldo.");
            }
        }
    }
}
