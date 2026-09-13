using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.BuilderPattern
{
    public class PreparedAlcoholicDrinkConcreteBuilder : IBuilder
    {
        private PreparedDrink _preparedDrink;

        public PreparedAlcoholicDrinkConcreteBuilder()
        {
            _preparedDrink = new PreparedDrink();
        }
        public void AddIngredient(string ingredient)
        {
            if (_preparedDrink.Ingredients == null) _preparedDrink.Ingredients = new List<string>();
            _preparedDrink.Ingredients.Add(ingredient);
        }
        public void Mix()
        {
            string ingredients = _preparedDrink.Ingredients.Aggregate((i, j) => i + ", " + j);
            _preparedDrink.Result = $"Bebida alcohólica preparada con: {ingredients}, Alcohol: {_preparedDrink.Alcohol}, Leche: {_preparedDrink.Milk}, Agua: {_preparedDrink.Water}";
        }

        public void Reset()
        {
            _preparedDrink = new PreparedDrink();
        }

        public void Rest(int time)
        {
            Thread.Sleep(time);
            Console.WriteLine("Listo para beberse");
        }

        public void SetAlcohol(decimal alcohol)
        {
            _preparedDrink.Alcohol = alcohol;
        }

        public void SetMilk(int milk)
        {
            _preparedDrink.Milk = milk;
        }

        public void SetWater(int water)
        {
            _preparedDrink.Water = water;
        }

        public PreparedDrink GetPreparedDrink() => _preparedDrink;
    }
}
