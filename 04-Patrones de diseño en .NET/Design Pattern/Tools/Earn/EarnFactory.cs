using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Earn
{
    public abstract class EarnFactory
    {
        public abstract IEarn GetEarn();
    }
}
