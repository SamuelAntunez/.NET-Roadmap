# .NET

.NET es un marco de trabajo que nace como .NET Framework en 2002, privado, mas adelante en el 2014 se decide crear .NET Core que es de codigo abierto y multiplataforma

## Introduccion a C#

### Tipos de propiedades

* public: se puede acceder en cualquier parte del proyecto
* private: solo se accede de manera local en el scope
> Se usa "_" en el nombre de las variables para determinar que es privada, ejemplo : _variable
* protected: similar al priavdo pero tambien se puede acceder desde los hijos

### Creacion de Objetos

```C#
class Sale {  // Crear un objeto

    public decimal Total {get; set;} // set permite que la propiedad sea modificada, get permite que la propiedad sea obtenida 

    public Sale(decimal total) { // Forma de crear un constructor
        this.Total = total; // this hace referencia a la variable dentro de la clase, permite agergarle el valor pasado por los parametros 
    }
}

Sale sale = new Sale(); // para instanciar un Objeto necesitas especificar que objeto es "Sale" y luego instanciarlo
Sale sale = new(); // Otra forma de crear un objeto
var sale = new Sale(15); // var sirve para determinar automaticamente el tipo de dato 

public string GetInfo() { // Comportamiento de un objeto
    return "El total es " + Total;
}
```

### Herencia

Te permite reutilizar el codigo existente en otra clase

```C#
var sale = new SaleWithTax(); // ahora podemos utilizar el metodo get info en SalwWithTax
var message = Sale.GetInfo();

class SaleWithTax : Sale { // Utilizas : Sale para heredar de Sale, si la clase heredada pide parametros tienes que indicarlo
    
    public decimal Tax {get; set;}
    
    public SaleWithTax(
        decimal total
    ) : base(total) { // utilizas el base(total) 

    }

    public string GetInfoWithTax(){
        return "El total es " Total + " Impuesto es: " + Tax
    }
}
```

#### Sobreescritura / Overriding

Te permite sobreescribir metodos en la clase hija

```C#

class Sale {

    public virtual string GetInfo(); // colocas virtual en el metodo padre
}

class SaleWithTax {
    public override string Getinfo(); // sobreescribir el metodo
}
```

#### Sobrecarga / Overcharge

```C#

class SaleWithTax{
    public string GetInfo(string message); // permite sobrecargar un metodo de una clase hija con parametros
}

```


### Interfaces

La interfaz es un contrato el cual te permite tipar o categorizar clases, te permite dar reglas a implementar

```C#
interface ISave {
    public void Save();
}

interface ISale {
    decimal Total // todo lo que implemente la interfaz tendra que tener la propiedad decimal Total
};

public class Sale : ISale, ISave { // para implementar la interfaz es similar a las clases
    public decimal total {get; set;}
    public void Save();
}

public class Beer : ISave {
    public void Save(); // Implementacion del metodo Save(); de la interfaz ISave();
}

void Some(ISave save) { // Enviar la interface como parametro
    save.Save();
}
```

> A diferencia de la herencia, tu puedes implementar varias interfaces en una clase, en cambio una clase solo puede heredar de otro padre

### Generics

Te ayuda a definir tipos de datos Genericos

```C#
var numbers = new List<int>();

public class MyList<T> {

    private List<T> _list;
    private int _limit;

    public MyList(int limit) {
        _limit = limit;
    }

    public void Add(T element) {
        if (_list.Count < Limit) {
            _list.Add(element)
        }
    }
}

```

### Serializacion y Deserializacion de Objetos

```C#
var samuel = new People() { // Te permite asignar los datos 
    Name = "Samuel",
    Age = 25,
};

string json = JsonSerializer.Serialize(samuel) // Convertir el objeto en JSON

string json = @"{
    ""Name"":""Samuel"",
    ""Age"":36,
}";

People samuel = JsonSerialize.Deserialize(json); // Convertir el formato JSON en objeto

public class People {
    public string Name {get; set;}
    public int Age {get; set;}
}

```


### Programacion Funcional

* Funcion pura: No altera cosas exteriores a ellas y siempre retorna lo mismo al recibir los mismos valores

```C#


```

### Expresiones lambda

Nos permite expresar una funcion anonima, la cual no necesita crearse

```C#
Func<int, int, int> sub = (int a, int b) => { // el primer int significa el valor de retorno y el resto, significa el tipo de dato de los parametros
    return a -b;
}
```

### LINQ

LINQ es una manera de trabajar con colecciones de manera declarativa, similar a SQL

```C#
var names = new List<string>();

var namesResult = from alias in origen // name=alias names=origen
                  where alias.Length > 3
                  orderby alias descending
                  select alias;
```

## Backend

### Controladores

Es una clase que recibe peticiones web (como GET o POST), procesa lo que el usuario pide, habla con los datos o servicios y decide qué respuesta enviar de regreso 

#### Para agregar un nuevo controlador (solo si utilizas controladores) 

Controladores > Agregar Controlador

```C#
namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }
    }
}
```

#### Metodos de Solicitud HTTP

* HttpGet: Metodo http GET

```C#
[HttpGet]
public decimal Get(decimal a, decimal b)
{
    return a + b;
}
```

* HttpPost: Metodo htpp POST

```C#
[HttpPost]
public decimal Add(decimal a, decimal b)
{
    return a + b;
}
```

* HttpPut: Metodo http PUT

```C#
[HttpPut]
public decimal Edit(decimal a, decimal b)
{
    return a - b;
}
```

* HttpDelete: Metodo http Delete
```C#
[HttpDelete]
public decimal Delete(decimal a, decimal b)
{
    return a - b;
}
```

#### Cuerpo de Solicitud HTTP (Body)

El body (o cuerpo) en un mensaje HTTP sirve para transportar la carga útil de datos (payload) principal de la petición o respuesta. Generalmente de manera JSON, al mandar una clase en el metodo, .NET lo detecta automaticamente

```C#
[HttpPost]
public decimal Add(Numbers number)
{
    return number.A - number.B;
}
```

#### Encabezado de Solicitud HTTP (Headers)

Los headers (o encabezados) en HTTP son metadatos en formato clave-valor que acompañan tanto a la petición (request) como a la respuesta (response).

```C#
public decimal Add(Numbers number, [FromHeader] string Host)
// [FromHeader(Name="Content-Length)"] otra manera de conseguirlo
{
    return number.A - number.B;
}
```

> La mayoria de los parmetros se obtienen de manera implicita (Colocando el nombre de la variable en el parametro), los que tienen caracteres especiales no se pueden obtener de manera implicita

#### Respuestas HTTP

* Obtener todos los elementos 
```C#
[HttpGet("all")]
public List<People> GetPeople() => Repository.People;
```

* Obtener un elemento por filtrado
```C#
[HttpGet("{id}")]
public People Get(int id) => Repository.People.First(p => p.Id == id);
```

* Obtener por search 
```C#
[HttpGet("search/{search}")]
public List<People> Get(string search) =>
    Repository.People.Where(p => p.Name.Contains(search)).ToList();
```

#### Tipo de Respuesta ActionResult
Sirve como el tipo de retorno de una acción en un controlador y permite devolver tanto un resultado HTTP (como un estado 200 OK, 404 Not Found o 400 Bad Request) como un tipo de dato o modelo específico.

```C#
public ActionResult<People> Get(int id)
{
    var people = Repository.People.FirstOrDefault(p => p.Id == id);
    if (people == null) 
    {
        return NotFound();
    }
    return Ok(people);
}
```

#### Tipo de Respuesta de IActionResult

Te permite mas flexibilidad ya que no necesitas colocar un Tipado y te permite regresar un `NoContent()`

```C#
public IActionResult Add(People people)
{
    if (string.IsNullOrEmpty(people.Name))
    {
        return BadRequest();
    }
    Repository.People.Add(people);
    return NoContent();
}
```

### Inyeccion de Dependencias 

#### Creacion de Capa de Servicio

Services > IPeopleService (Interfaz)

En program.cs agregas los servicios 

```C#
// Add services to the container.
builder.Services.AddSingleton<IPeopleService, PeopleService>(); // el primero es la interfaz y el segundo el servicio implementado
```

#### Inyeccion de Dependencia

```C#
 public class PeopleController : ControllerBase
 {
     private IPeopleService _peopleService;

     public PeopleController(IPeopleService peopleService)
     {
         _peopleService = peopleService;
     }
 }
```

#### Inyeccion de Dependencia por clave (key)

```C#
// Add services to the container.
//builder.Services.AddSingleton<IPeopleService, PeopleService>();
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");
```

En el controlador

```C#
public PeopleController([FromKeyedServices("peopleService")] IPeopleService peopleService)
```

#### Tipos de Inyeccion de Dependencia

* Singleton: El objeto siempre tendra la misma instancia
* Scoped: El objeto sera distinto en cada solicitud
* Transient: Haces usos de un objeto inyectado varias veces en la misma solicitud, cada inyeccion sera distinta asi este en la misma solicitud

### Programacion Asincrona
```C#
public async Task<IActionResult> GetAsync() {
    var task1 = new Task(() => {
        Thread.Sleep(1000);
        Console.WriteLine("Conexion terminada");
    });

    task1.Start();
    Console.WriteLine("Hago otra cosa");

    await task1;

    Console.WriteLine("Todo ha terminado");
    return Ok();
}
```


### Programacion Sincrona

```C#
public IActionResult GetSync() {
    Stopwatch stopwatch = Stopwatch.StartNew();
    stopwatch.Start();

    Thread.Sleep(1000);
    Console.WriteLine("Conexion terminada");
    
    Thread.Sleep(1000);
    Console.WriteLine("Envio de mail terminado");
    stopwatch.Stop();
    return Ok();
}
```

### Flujos y Configuraciones

#### Model vs DTO

* Un modelo es la representacion de una entidad en la base de datos
* Un DTO (Data Transfer Object) Nos permite transformar la data para solo mostrar los datos necesarios y validarlos

```C#
    public class PostDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
```

```C#
    public class PostService : IPostService
    {
        private HttpClient _httpClient;

        public PostsService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<PostDto>> Get()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            var result = await _httpClient.GetAsync(url);
            var body = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // Ignora mayusculas y minusculas 
            };

            var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);

            return post;
        }
    }
```

```C#
    public class PostsController : ControllerBase
    {
        IPostService _titlesService;

        public PostsController(IPostService titlesService)
        {
            _titlesService = titlesService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() => await _titlesService.Get();
    }
```

#### AddHttpClient

```C#
builder.Services.AddHttpClient<IPostService, PostService>(c =>
{
    c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts");
});
```
En el servicio
```C#
var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
```

#### Obtener datos de appsettingsjson

```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "BaseUrlPost": "https://jsonplaceholder.typicode.com/posts"
}
```

para acceder a esa variable

```C#
builder.Services.AddHttpClient<IPostService, PostService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});
```

## Entity Framework ORM

Permite mapear una Base de Datos, representando por medio de objetos

### Instalacion de Entity Framework ORM

Dependencias > Instalar Paquetes Nuggets > EntityFrameWork

### Crear Modelos

```C#
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Bear
    {
        [Key]  // Para que sea la PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // El primary key sera autoincrementable
        public int BeerId { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("BrandId")] // Crea la relacion con brandId, necesitas crear el metodo virtual para poder 
        public virtual Brand Brand { get; set; }
    }
}
```

### Creacion de Contexto


* DbSet<Beer> Beers: Mapea la tabla de cervezas (Beers). Cada registro de esa tabla será un objeto del tipo Beer.
```C#
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class StoreContext : DbContext // Clase necesaria para crear el contexto
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {}

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
```
A través de una instancia de esta clase realizas todas las operaciones sobre tu base de datos mediante código C#, sin necesidad de escribir SQL directamente

#### Inyeccion de Contexto

```C#
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});
```

```C#
  "ConnectionStrings": {
    "StoreConnection": "Server=Artemas;Database=Store; Trusted_Connection=True; Trust Server Certificate=True"
  },
```

#### Migracion Inicial 

```terminal
Add-Migration InitDB
```

#### Creacion de Base de Datos

```Terminal
Update-Database
```

#### Modificacion en Modelos de Entity Framework

Creas una nueva migracion con `Add-Migration` y luego `Update-Database`

### CRUD Con Entity Framework

#### Creacion de DTOs

* Creacion de controller y inyectar dependencias

```C#
    public class BeerController : ControllerBase
    {
        private StoreContext _context;
        public BeerController(StoreContext context)
        {
            _context = context;
        }
    }
```

* Obtener datos

```C#

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() =>
            await _context.Beers.Select(b => new BeerDto
            {
                Id = b.BeerId,
                Name = b.Name,
                Alcohol = b.Alcohol,
                BrandId = b.BrandId,
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer == null) { 
                return NotFound();
            }

            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId,
            };

            return Ok(beerDto);
        }
```

* Insertar Datos

```C#
        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                BrandId = beerInsertDto.BrandId,
                Alcohol = beerInsertDto.Alcohol,
            };

            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto()
            {
                Id =  beer.BrandId,
                Name= beer.Name,
                Alcohol = beer.Alcohol,
                BrandId= beer.BrandId,
            };

            return CreatedAtAction(nameof(GetById), new { id = beer.BeerId }, beerDto);
        }
```

* Modificar Informacion

```C#
        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer == null) return NotFound();

            beer.Name = beerUpdateDto.Name;
            beer.Alcohol = beerUpdateDto.Alcohol;
            beer.BrandId = beerUpdateDto.BrandId;

            await _context.SaveChangesAsync();

            var beerDto = new BeerDto()
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId,
            };

            return Ok(beerDto);
        }
```

### Validaciones - FluenValidation 

Inyeccion de Dependencia en Program.cs

```C#
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();
```

Clase validator

```C#
namespace Backend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
```

Inyeccion de Dependencia 

```C#
public BeerController(StoreContext context, IValidator<BeerInsertValidator> beerInsertValidator)
{
    _context = context;
    _beerInsertValidator = beerInsertValidator;
}
```

Utilizacion en Controller

```C#

        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);

            if (!validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                BrandId = beerInsertDto.BrandId,
                Alcohol = beerInsertDto.Alcohol,
            };

            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto()
            {
                Id =  beer.BrandId,
                Name= beer.Name,
                Alcohol = beer.Alcohol,
                BrandId= beer.BrandId,
            };

            return CreatedAtAction(nameof(GetById), new { id = beer.BeerId }, beerDto);
        }
```

#### Mensajes Personalizados

```C#
namespace Backend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe medir entre 2 y 20 caracteres");
            RuleFor(x => x.BrandId).NotNull().WithMessage("La marca es obligatoria");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage("El {PropertyName} debe ser mayor a 0");
        }
    }
}
```

### Refactorizacion del Codigo

Refactorizar es reestructura el codigo sin modificar el comportamiento externo, se suele refactorizar para tener mayor legibilidad, optimizacion, etc.

* Utilizacion de Servicios en el controller
```C#
        public async Task<IEnumerable<BeerDto>> Get() => await _beerService.Get();
          

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beerDto = await _beerService.GetById(id);
            return beerDto == null ? NotFound() : Ok(beerDto);
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);
            if (!validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }
            var beerDto = await _beerService.Add(beerInsertDto);
            return CreatedAtAction(nameof(GetById), new { id = beerDto.Id }, beerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto);
            if (!validationResult.IsValid) { return BadRequest(validationResult.Errors); }


            var beerDto = await _beerService.Update(id, beerUpdateDto);
            
            return Ok(beerDto) == null ? NotFound() : Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDto>> Delete(int id)
        {
            var beerDto = await _beerService.Delete(id);
            return beerDto == null ? NotFound() : Ok(beerDto);
        }
```

### Interfaz Generica

* En la interfaz

```C#
namespace Backend.Services
{
    public interface ICommonService<T, TI, TU>
    {
        Task<IEnumerable<BeerDto>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI beerInsertDto);
        Task<T> Update(int id, TU beerUpdateDto);
        Task<T> Delete(int id);
    }
}
```

* En la inyeccion de la dependencia

```C#
       private ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto> _beerService;

       public BeerController(IValidator<BeerInsertDto> beerInsertValidator, IValidator<BeerUpdateDto> beerUpdateValidator, [FromKeyedServices("beerService")] ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto> beerService)
       {
           _beerInsertValidator = beerInsertValidator;
           _beerUpdateValidator = beerUpdateValidator;
           _beerService = beerService;
       }
```

* En program.cs

```C#
builder.Services.AddKeyedScoped<ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>, BeerService>("beerService");
```

### Repository

Es una capa que te ayuda a separar los servicios de la capa de datos, para que servicios solo se encargue de llamar al repositorio y no a la base de datos  

```C#
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private StoreContext _context;
        public BeerRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Beer>> Get() => await _context.Beers.ToListAsync();
        public async Task<Beer> GetById(int id) => await _context.Beers.FindAsync(id);
        public async Task Add(Beer entity) => await _context.Beers.AddAsync(entity);

        public void Update(Beer entity)
        {
            _context.Beers.Attach(entity);
            _context.Beers.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(Beer entity) => _context.Beers.Remove(entity);
        public async Task Save() => await _context.SaveChangesAsync();
    }
}
```

* Implementacion en Service

```C#
using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        private IRepository<Beer> _beerRepository;

        public BeerService(IRepository<Beer> beerRepository)
        {
            _beerRepository = beerRepository;
        }
        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                BrandId = beerInsertDto.BrandId,
                Alcohol = beerInsertDto.Alcohol,
            };

            await _beerRepository.Add(beer);
            await _beerRepository.Save();

            var beerDto = new BeerDto()
            {
                Id = beer.BrandId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId,
            };

            return beerDto;
        }

        public async Task<BeerDto> Delete(int id)
        {
            var beer = await _beerRepository.GetById(id);
            if (beer == null) return null;

            var beerDto = new BeerDto()
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId,
            };

            _beerRepository.Delete(beer);
            await _beerRepository.Save();

            return beerDto;

        }

        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beerRepository.Get();
            return beers.Select(beer => new BeerDto()
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId,
            });
        }

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);
            if (beer == null) return null;
            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId,
            };
            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var beer = await _beerRepository.GetById(id);
            if (beer == null) return null;


            beer.Name = beerUpdateDto.Name;
            beer.Alcohol = beerUpdateDto.Alcohol;
            beer.BrandId = beerUpdateDto.BrandId;

            _beerRepository.Update(beer);
            await _beerRepository.Save();

            var beerDto = new BeerDto()
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId,
            };

            return beerDto;
        }
    }
}

```

### Automappers

Administrador de Paquetes Nuggets > AutoMapper.Extensions.Microsoft.DependencyInjection

En program.cs

```C#
// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
```

En la carpeta Automappers

* En caso de 
```C#
using AutoMapper;

namespace Backend.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>(); // Cuando se tienen los mismos nombres de campo con esto ya basta
            CreateMap<Beer, BeerDto>()
                .ForMember(dto => dto.Id, m => m.MapFrom(b => b.BeerId)); // Para datos distintos
        }
    }
}
```

En servicios 
```C#
var beer = new Beer()
{
    Name = beerInsertDto.Name,
    BrandId = beerInsertDto.BrandId,
    Alcohol = beerInsertDto.Alcohol,
}; // Antes

var beer = _mapper.Map<Beer>(beerInsertDto); // Despues
var beerDto = _mapper.Map<BeerDto>(beer); // BeerDto es a lo que quieres convertir y beer, es lo que se convertira

```

#### Automaper con objetos ya existente

```C#
CreateMap<BeerUpdateDto, Beer>();
```

```C#
beer = _mapper.Map<BeerUpdateDto, Beer>(beerUpdateDto, beer);
//beer.Name = beerUpdateDto.Name;
//beer.Alcohol = beerUpdateDto.Alcohol;
//beer.BrandId = beerUpdateDto.BrandId;
```