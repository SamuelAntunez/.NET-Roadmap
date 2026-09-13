using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.DependencyInjectionPattern
{
    public class Beer
    {
        private string _name;
        private string _brand;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public Beer (string name, string brand )
        {
            _name = name;
            _brand = brand;
        }
    }
}
