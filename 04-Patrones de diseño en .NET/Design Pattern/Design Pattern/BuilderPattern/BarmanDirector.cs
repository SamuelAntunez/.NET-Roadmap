using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.BuilderPattern
{
    public class BarmanDirector
    {
        private IBuilder _builder;

        public BarmanDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public void SetBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        public void PreparedMargarita()
        {
            _builder.AddIngredient("Tequila");
            _builder.AddIngredient("Triple sec");
            _builder.AddIngredient("Lime juice");
            _builder.SetAlcohol(40);
            _builder.SetMilk(0);
            _builder.SetWater(0);
            _builder.Mix();
            _builder.Rest(1000);
        }
    }
}
