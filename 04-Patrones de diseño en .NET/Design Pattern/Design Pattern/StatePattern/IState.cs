using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.StatePattern
{
    public interface IState
    {
        public void Action(CustomerContext context, decimal amount);
    }
}
