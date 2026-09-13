# Patrones de Diseño en .NET

Los patrones de diseño son tecnicas que resuelven problemas comunes

## Tipos de patrones de diseño

* Los creacionales
* Los estructurales
* Los de comportamiento

# Patrones de diseño en .NET

## Singleton

Es un patron de diseño creacional, nos sirve para crear objetos que permitan solo una instancia

* Plantilla

```C#
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

```

* Uso ejemplo

```C#
namespace Design_Pattern.Singleton
{
    public class Log
    {
        private readonly static Log _instance = new Log();
        private string _path = "log.txt"
        public static Log Instance { get { return _instance; } }
        private Log()
        {
        }
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
```

### Implementacion en ASP

```C#
builder.Services.Configure<MyConfig>(builder.Configuration.GetSection("MyConfig")); // Inyeccion de dependencia de la variable en appsettings.json mediante el patron Options Pattern
```

```C#
namespace DesignPatternASP.Configuration // Patron Options Pattern
{
    public class MyConfig
    {
        public string PathLog { get; set; }
    }
}
```

```C#
namespace Tools
{
    public sealed class Log // declaracion que define reglas de acceso, sealed impide que otras clases puedan heredar de ella
    {
        private static Log _instance = null;
        private string _path;

        public static Log GetInstance(string path)
        {
            if (_instance == null) _instance = new Log(path);
            return _instance;
        }
        private Log(string path)
        {
            _path = path;
        }
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
```

```C#
namespace DesignPatternASP.Controllers
{
    public class HomeController : Controller
    {

        private readonly IOptions<MyConfig> _config;
        public HomeController(IOptions<MyConfig> config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entro a index"); // Inyectando el path mediante IOptions<MyConfig>
            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entro a privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
```


## Factory Method

Es una fabrica creadora de objetos

```C#
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.FactoryPattern
{
    public abstract class SaleFactory // Esta clase abstracta sera el Creator
    {
        public abstract ISale GetSale();
    }

    public class StoreSaleFactory : SaleFactory // Este es el concrete Creator
    {
        private decimal _extra;

        public StoreSaleFactory(decimal extra)
        {
            _extra = extra;
        }
        public override ISale GetSale()
        {
            return new StoreSale(_extra);
        }
        
    }

    public class InternetSaleFactory : SaleFactory // Este es el concrete Creator
    {
        private decimal _discount;

        public InternetSaleFactory(decimal discount)
        {
            _discount = discount;
        }
        public override ISale GetSale()
        {
            return new InternetSale(_discount);
        }

    }
    public class StoreSale : ISale // Este es el producto concreto que se esta creando (Concrete Product)
    {
        private decimal _extra;

        public StoreSale(decimal extra)
        {
            _extra = extra;
        }
        public void Sell(decimal total)
        {
            Console.WriteLine($"Venta en tienda {total}");
        }
    }

    public class InternetSale : ISale // En caso de que quiera que el producto se venda por el internet
    {
        private decimal _discount;
        public InternetSale(decimal discount)
        {
            _discount = discount;
        }
        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en internet tiene un total de {total - _discount}");
        }
    }
    public interface ISale // Esta interfaz es el producto
    {
        public void Sell(decimal total);
    }
}
```

## Dependency Injection

```C#
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
```

```C#
namespace Design_Pattern.DependencyInjectionPattern
{
    public class DrinkWithBeer
    {
        private Beer _beer;
        private decimal _water;
        private decimal _sugar;

        public DrinkWithBeer(decimal water, decimal sugar, Beer beer)
        {
            _water = water;
            _sugar = sugar;
            _beer = beer;
        }

        public void Build()
        {
            Console.WriteLine($"Preparamos bebida que tiene agua {_water} " + 
                $" azucar {_sugar} y cerveza {_beer.Name}");
        }
    }
}
```

```C#
var beer = new Beer("Pikantus", "Erdinger");
var drinkWithBeer = new DrinkWithBeer(10, 1, beer);
```

### Implementacion en ASP

* Antes sin usar Dependency Injection
```C#
namespace DesignPatternASP.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            // Factories
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.20m, 10);

             // Products
             var localEarn = localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            //total
            ViewBag.totalLocal = total + localEarn.Earn(400);
            ViewBag.totalForeign = total + foreignEarn.Earn(400);



            return View();

        }
    }
}
```

* Con DI
Hacemos la inyeccion de dependencia en el archivo central de ASP en program.cs


```C#
builder.Services.AddTransient((factory) => new LocalEarnFactory(0.20m));

builder.Services.AddTransient((factory) => new LocalEarnFactory(builder.Configuration.GetSection("MyConfig").GetValue<decimal>("LocalPercentage")));
```

```C#
namespace DesignPatternASP.Controllers
{
    public class ProductDetailController : Controller
    {
        private EarnFactory _localEarnFactory;

        public ProductDetailController(LocalEarnFactory localEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
        }
        public IActionResult Index(decimal total)
        {
            // Factories
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.20m, 10);
        

             // Products
            var localEarn = _localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            //total
            ViewBag.totalLocal = total + localEarn.Earn(400);
            ViewBag.totalForeign = total + foreignEarn.Earn(400);



            return View();

        }
    }
}
```

## Patron Repositorio

Es un intermediario entre el manejo de la data y el framework

### Entity Framework ORM

* Instalación 

EntityFramework.sqlServer y Tools

* Comando para la conexion a la base de datos y hacer el mapeo 

```Scaffold-DbContext "Server=Artemas; Database=DesignPatterns; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models```

* En caso de agregar mas tablas utilizar el ```-Force``` para actualizar y agregar las tablas nuevas en la base de datos 
 
### Forma Sencilla de Usar el Patron Repositorio

* Interfaz

```C#
namespace Design_Pattern.RepositoryPattern
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> Get();
        Beer Get(int id);
        void Add(Beer data);
        void Delete(int id);
        void Update(Beer data);
        void Save();
    }
}
```

* Repositorio

```C#
namespace Design_Pattern.RepositoryPattern
{
    public class BeerRepository : IBeerRepository
    {
        private DesignPatternsContext _context;
        public BeerRepository(DesignPatternsContext context)
        {
            _context = context;
        }
        public void Add(Beer data)
        {
            _context.Beers.Add(data);
        }

        public void Delete(int id)
        {
            var beer = _context.Beers.Find(id);
            _context.Beers.Remove(beer);
        }

        public IEnumerable<Beer> Get()
        {
           return _context.Beers.ToList();
        }

        public Beer Get(int id)
        {
            return _context.Beers.Find(id);
        }


        public void Update(Beer data)
        {
            _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
```

* Uso

```C#
using (var context = new DesignPatternsContext())
{
    var beerRepository = new BeerRepository(context);
    var beer = new Beer();

    beer.Name = "Corona";
    beer.Style = "Blonde";

    beerRepository.Add(beer);
    beerRepository.Save(); // Necesario despues de cada cambio
}
```

### Repository con Generics

* Interfaz Generica
```C#
namespace Design_Pattern.RepositoryPattern
{
    internal interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity data);
        void Save();
    }
}
```

* Patron repositorio para trabajar con cualquier tipo de tabla

```C#
namespace Design_Pattern.RepositoryPattern
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DesignPatternsContext _context;
        private DbSet<TEntity> _dbSet;
        public Repository(DesignPatternsContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }

        public TEntity Get(int id) => _dbSet.Find(id);

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
```

> El dbSet es importante, nos permite trabajar con los generics

* Uso

```C#
using (var context = new DesignPatternsContext())
{
    var beerRepository = new Repository<Beer>(context);

    var beer = new Beer() { Name = "Fuller", Style = "Strong Ale" };
    beerRepository.Add(beer);
    beerRepository.Save();
}
```

### Implementacion en ASP

* Inyectar contexto y repositorio
```C#
// Inyectar DBContext
builder.Services.AddDbContext<DesignPatternsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});
// Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(IRepository<>));
```


## Patron Unit Of Work
El patron unit of work nos sugiere que si tenemos un conjunto de peticiones a la base de datos podemos agruparlas y enviarlas juntas

Por cada elemento o interaccion que vaya a manejar el sistema, se agrega una propiedad del tipo IRepository
```C#
namespace Design_Pattern.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }
        public IRepository<Brand> Brands { get; }
    }
}
```

* Clase UnitOfWork

```C#
namespace Design_Pattern.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private DesignPatternsContext _context;
        public IRepository<Beer> _beers;
        public IRepository<Brand> _brands;
        public UnitOfWork(DesignPatternsContext context )
        {
            _context = context;
        }
        public IRepository<Beer> Beers
        {
            get
            {
                return _beers == null 
                    ? _beers = new Repository<Beer>(_context) 
                    : _beers;
            }
        }
        public IRepository<Brand> Brands
        {
            get
            {
                return _brands == null 
                    ? _brands = new Repository<Brand>(_context) 
                    : _brands;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
```

* Uso en program.cs
```C#
using (var context = new DesignPatternsContext())
{
    var unitOfWork = new UnitOfWork(context);

    var beers = unitOfWork.Beers;
    var beer = new Beer() { Name = "Fuller", Style="Porter" };
    beers.Add(beer);
    unitOfWork.Save();
}
```

> Ya no hace falta crear una nueva clase de cada uno, solo instanciamos unitofwork

### Implementacin en ASP

Inyectar en program.cs


```C#
// Inyectar UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
```

```C#
namespace DesignPatternASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from d in _unitOfWork.Beers.GetAll()
                                               select new BeerViewModel
                                               {
                                                   Id = d.BeerId,
                                                   Name = d.Name,
                                                   Style = d.Style
                                               };

            return View("Index", beers);
        }
    }
}
```

## Patron Strategy

Nos permite cambiar el comportamiento de un objeto en tiempo de ejecucion, es decir, podemos cambiar la estrategia de un objeto sin tener que modificarlo

Interfaz

```C# 
namespace Design_Pattern.StrategyPattern
{
    public interface IStrategy
    {
        public void Run();
    }
}
```

Clases concretas que implementan la interfaz

```C#
namespace Design_Pattern.StrategyPattern
{
    public class CarStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy un carro y me muevo con 4 llantas");
        }
    }
}

namespace Design_Pattern.StrategyPattern
{
    public class MotoStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una motocicleta y me muevo con 2 llantas");
        }
    }
}
```

Clase que utiliza la estrategia

```C#
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
```

utilizacion en program.cs

```C#
var context = new Context(new CarStrategy());
context.Run();
context.Strategy = new MotoStrategy();
context.Run();
```

### Implementacion ASP

```C#
using DesignPatterns.Repository;

namespace DesignPatternASP.Strategies
{
    public interface IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork);
    }
}
```

```C#
namespace DesignPatternASP.Strategies
{
    public class BeerStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer()
            {
                Name = beerVM.Name,
                Style = beerVM.Style,
                BrandId = (Guid)beerVM.BrandId
            };
            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
```

```C#
namespace DesignPatternASP.Strategies
{
    public class BeerWithBrandStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;

            var brand = new Brand();
            brand.Name = beerVM.OtherBrand;
            brand.BrandId = Guid.NewGuid();
            beer.BrandId = brand.BrandId;

            unitOfWork.Brands.Add(brand);
            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
```

```C#
namespace DesignPatternASP.Strategies
{
    public class BeerContext
    {
        private IBeerStrategy _strategy;
        public IBeerStrategy Strategy
        {
            set { _strategy = value; }
        }
        public BeerContext(IBeerStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            _strategy.Add(beerVM, unitOfWork);
        }


    }
}
```

* Uso
```C#
        public IActionResult Add(FormBeerViewModel beerVM)
        {
            var context = beerVM.BrandId == null ? new BeerContext(new BeerWithBrandStrategy()) : new BeerContext(new BeerStrategy());
            context.Add(beerVM, _unitOfWork);

            return RedirectToAction("Index");
        }
```

## Patron Builder

Este patron nos permite crear objetos complejos paso a paso, y nos permite crear diferentes tipos y representaciones de un objeto utilizando el mismo codigo de construccion


Se crea la interfaz que define los pasos para construir el objeto
```C#
namespace Design_Pattern.BuilderPattern
{
    public interface IBuilder
    {
        public void Reset();
        public void SetAlcohol(decimal alcohol);
        public void SetMilk(int milk);
        public void SetWater(int water);
        public void AddIngredient(string ingredient);
        public void Mix();
        public void Rest(int time);
    }
}
```
Producto 
```C#
namespace Design_Pattern.BuilderPattern
{
    public class PreparedDrink
    {
        public List<string> Ingredients = new List<string>();
        public int Milk;
        public int Water;
        public decimal Alcohol;


        public string Result;
    }
}
```

Creacion del producto en concreto
```C#
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
```

Director que nos permite construir el objeto paso a paso
```C#
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
```

Sin el director
```C#
//Builder
var builder = new PreparedAlcoholicDrinkConcreteBuilder();
builder.AddIngredient("Tequila");
builder.SetAlcohol(40);
builder.SetMilk(10);
builder.SetWater(20);
builder.Mix();
builder.Rest(1000);

var preparedDrink = builder.GetPreparedDrink();
```

Con el director
```C#
//Builder
var builder = new PreparedAlcoholicDrinkConcreteBuilder();
var barmanDirector = new BarmanDirector(builder);
barmanDirector.PreparedMargarita();
var preparedDrink = builder.GetPreparedDrink();
```

### Implementacion en ASP

```C#
namespace DesignPatternASP.Controllers
{
    public class GeneratorFileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _generatorConcreteBuilder;

        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFile(int optionFile)
        {
            try
            {
                var beers = _unitOfWork.Beers.GetAll();
                List<string> content = beers.Select(d => d.Name).ToList();
                string path = "file"+DateTime.Now.Ticks+new Random().Next(0, 1000)+".txt";

                var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);

                if (optionFile == 1)               
                    generatorDirector.CreateSimpleJsonGenerator(content, path);
                else 
                    generatorDirector.CreateSimplePipeGenerator(content, path);

                var generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();

                return Json("Archivo generado correctamente");
            } catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
```

## Patron State

Este patron nos permite cambiar el comportamiento de un objeto cuando su estado cambia, es decir, el objeto cambiara su comportamiento dependiendo del estado en el que se encuentre

Context
```C#
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
```

Interfaz
```C#
namespace Design_Pattern.StatePattern
{
    public interface IState
    {
        public void Action(CustomerContext context, decimal amount);
    }
}
```

Estados concretos
```C#
namespace Design_Pattern.StatePattern
{
    public class NewState : IState
    {
        public void Action(CustomerContext context, decimal amount)
        {
            Console.WriteLine($"Se le pone dinero a su saldo {amount}");
            context.Saldo = amount;
            context.SetState(new NotDebtorState());
        }
    }
}

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

namespace Design_Pattern.StatePattern
{
    public class DebtorState : IState
    {
        public void Action(CustomerContext context, decimal amount)
        {
            Console.WriteLine($"El cliente es deudor. Se le aplica una acción.");
        }
    }
}
```

Uso 

```C#
var customerContext = new CustomerContext();
customerContext.Request(100);
customerContext.Request(50);
```