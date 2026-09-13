
//using Design_Pattern.DependencyInjectionPattern;
using Design_Pattern.BuilderPattern;
using Design_Pattern.FactoryPattern;
using Design_Pattern.Models;
using Design_Pattern.RepositoryPattern;
using Design_Pattern.Singleton;
using Design_Pattern.StatePattern;
using Design_Pattern.StrategyPattern;
using Design_Pattern.UnitOfWorkPattern;

var log = Log.Instance;

SaleFactory storeSaleFactory = new StoreSaleFactory(10);
SaleFactory internetSaleFactory = new InternetSaleFactory(2);

ISale sale1 = storeSaleFactory.GetSale();
sale1.Sell(15);

ISale sale2 = internetSaleFactory.GetSale();
sale2.Sell(15);

//var beer = new Beer("Pikantus", "Erdinger");
//var drinkWithBeer = new DrinkWithBeer(10, 1, beer);


Console.WriteLine("base de datos");

using (var context = new DesignPatternsContext())
{
    var unitOfWork = new UnitOfWork(context);

    var beers = unitOfWork.Beers;
    var beer = new Beer() { Name = "Fuller", Style="Porter" };
    beers.Add(beer);
    unitOfWork.Save();
}

var context = new Context(new CarStrategy());
context.Run();
context.Strategy = new MotoStrategy();
context.Run();

//Builder
var builder = new PreparedAlcoholicDrinkConcreteBuilder();
var barmanDirector = new BarmanDirector(builder);
barmanDirector.PreparedMargarita();
var preparedDrink = builder.GetPreparedDrink();

// State

var customerContext = new CustomerContext();
customerContext.Request(100);
customerContext.Request(50);
