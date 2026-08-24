using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.Singleton
{
    public class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        
        public static Singleton Instance { get { return _instance; } }
        private Singleton()
        {

        }
    }
}
