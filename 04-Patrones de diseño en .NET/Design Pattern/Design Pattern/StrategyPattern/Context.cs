using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.StrategyPattern
{
    public class Context
    {
        private IStrategy _strategy;
        public IStrategy Strategy
        {
            set { _strategy = value; }
        }

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Run()
        {
            _strategy.Run();
        }
    }
}
