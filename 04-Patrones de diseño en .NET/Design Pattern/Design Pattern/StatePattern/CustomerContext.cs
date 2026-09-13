using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.StatePattern
{
    public class CustomerContext
    {
        private IState _state;
        private decimal _saldo;

        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
        public CustomerContext()
        {
            _state = new NewState();
        }

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState() => _state;
        public void Request(decimal amount) => _state.Action(this, amount);
        public void Discount(decimal amount) => _saldo -= amount;
    }
}
