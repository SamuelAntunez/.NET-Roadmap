## Programacion Estructurada

### Variables y Tipos de Datos

- `int` : Entero
- `float` : Número decimal
- `double` : Número decimal de doble precisión
- `decimal` : Número decimal de alta precisión
- `char` : Carácter
- `string` : Cadena de texto
- `bool` : Booleano (true/false)
- `var` : Tipo implícito (el compilador infiere el tipo de dato)

### Arrays

Son colecciones de valores del mismo tipo los cuales pueden ser almacenados en una variable

```C#
int[] numbers = new int[5]; // Array de enteros con 5 elementos
numbers[0] = 10; // Asignar valor al primer elemento
```

### Sentencias condicionales

Una sentencia condicional permite ejecutar un bloque de código dependiendo de si una condición es verdadera o falsa.

```C#
var age = 12;
if (age >= 18)
{
    Console.WriteLine("Eres mayor de edad");
}
else
{
    Console.WriteLine("Eres menor de edad");
}
```

## Programacion Orientada a Objetos

Paradigma que se enfoca en la creacion de objetos que contienen tanto datos como métodos para manipular esos datos.

### Clases abstractas

Una clase abstracta es una clase que no puede ser instanciada directamente y puede contener métodos abstractos (sin implementación) que deben ser implementados por las clases derivadas.

```C#
abstract class Animal
{
    public abstract void MakeSound(); // Método abstracto
}
```

## Programacion FullStack

## Base de Datos - SQL Managment Studio

### Creacion de Base de Datos

**Crear base de datos:** Base de datos -> Nueva base de datos -> Nombre de la base de datos -> Aceptar

### Creacion de Tablas

**Crear tabla:** Base de datos -> Tablas -> Nueva tabla -> Agregar columnas -> Guardar tabla con nombre

### Tipo de datos

* int : Entero
* varchar(n) : Cadena de texto de longitud variable (n es el número máximo de caracteres)
* datetime : Fecha y hora
* nvarchar(n) : Cadena de texto Unicode de longitud variable (n es el número máximo de caracteres)

### Comandos

```SQL
INSERT INTO Brand(Name)
VALUES('Vino Fino'),('Cerveza Local'),('Agua')

SELECT * FROM Brand
ORDER BY Name 

UPDATE Brand SET Name='Cerveza Fina'
WHERE Id = 1

DELETE FROM Brand
WHERE Id = 1
```

Explicacion: 
- `INSERT INTO`: Agrega nuevos registros a la tabla
- `SELECT * FROM`: Recupera todos los registros de la tabla
- `UPDATE`: Modifica registros existentes en la tabla
- `DELETE`: Elimina registros de la tabla

### Llaves foraneas

Para crear una relación entre dos tablas, se utiliza una llave foránea (foreign key) que hace referencia a la llave primaria (primary key) de otra tabla.

```SQL
CREATE TABLE Product
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    BrandId INT,
    FOREIGN KEY (BrandId) REFERENCES Brand(Id)
)
```

En SQL Server , la llave primaria se define con `PRIMARY KEY` y la llave foránea con `FOREIGN KEY`. Esto asegura la integridad referencial entre las tablas.

### INNER JOIN 

El INNER JOIN se utiliza para combinar filas de dos o más tablas basadas en una condición relacionada entre ellas. Solo devuelve las filas que cumplen con la condición especificada.

Nos devuelve al intercepcion

```SQL
SELECT Product.Name as ProductName, Brand.Name as BrandName
FROM Product 
INNER JOIN Brand ON Brand.Id = Product.BrandId
```

### LEFT JOIN
El LEFT JOIN devuelve todas las filas de la tabla de la izquierda y las filas coincidentes de la tabla de la derecha. Si no hay coincidencia, los resultados de la tabla de la derecha serán NULL.

```SQL
SELECT Product.Name as ProductName, Brand.Name as BrandName
FROM Product
LEFT JOIN Brand ON Brand.Id = Product.BrandId
```

### RIGHT JOIN
El RIGHT JOIN devuelve todas las filas de la tabla de la derecha y las filas coincidentes de la tabla de la izquierda. Si no hay coincidencia, los resultados de la tabla de la izquierda serán NULL.

```SQL
SELECT Product.Name as ProductName, Brand.Name as BrandName
FROM Product
RIGHT JOIN Brand ON Brand.Id = Product.BrandId
```

### FULL OUTER JOIN
El FULL OUTER JOIN devuelve todas las filas cuando hay una coincidencia en una de las tablas. Si no hay coincidencia, los resultados de la tabla sin coincidencia serán NULL.

```SQL
SELECT Product.Name as ProductName, Brand.Name as BrandName
FROM Product
FULL OUTER JOIN Brand ON Brand.Id = Product.BrandId
```

## Arquitectura de Software

### Creacion de Componentes

Un componente es un Conjunto de Funcionalidades en Comun, que puede ser reutilizado en diferentes partes de la aplicacion. En C# .NET, los componentes se pueden crear como clases, interfaces o librerías.

* Que es el dominio?

El dominio es el conjunto de conceptos y reglas que definen el problema que se está resolviendo con el software. Representa la lógica de negocio y las entidades que interactúan en el sistema.

* Entidades de un dominio

Las entidades de un dominio son los objetos principales que representan conceptos del mundo real dentro del sistema. Cada entidad tiene atributos y comportamientos que reflejan sus características y acciones.

### Entity Framework

* Scaffolding: Es generar automaticamente todas las clases que representan la base de datos

* instalar dotnet-ef:

```dotnet tool install --global dotnet-ef```

dotnet ef dbcontext scaffold "Server=TUSERVIDOR;Database=Store;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer



## Creacion del Backend con Minimal API

### Ajustar Conexion y Contexto de la Base de datos

```C#
// Conexion
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Agregar Contexto
builder.Services.AddDbContext<StoreFsContext>(options =>
{
    options.UseSqlServer(connection);
});
```

### Inyeccion de Dependencia

```C#
// Inyeccion de Dependencia
builder.Services.AddTransient<IRepository<BrandEntity>, BrandRepository>();
builder.Services.AddTransient<IUseCase<BrandEntity>, BrandUseCase>();
```

### Creacion de Endpoints 
```C#

// Brands
app.MapGet("brand", async (IUseCase<BrandEntity> useCase) =>
{
    return await useCase.GetAllAsync();
}).WithName("getBrand");
app.MapPost("brand", async(IUseCase<BrandEntity> useCase, BrandEntity brand) =>
{
    await useCase.AddAsync(brand);
    return Results.Created();
}).WithName("addBrand");
app.MapPut("brand/{id}", async (int id, JsonDocument body, IUseCase<BrandEntity> useCase) =>
{
    try
    {
        var name = body.RootElement.GetProperty("name").GetString();
        var brandEntity = new BrandEntity(id, name);

        await useCase.UpdateAsync(brandEntity);

    }catch(Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }

    return Results.NoContent();
});

app.MapDelete("brand/{id}", async (int id, IUseCase<BrandEntity> useCase) =>
{
    try
    {
        await useCase.DeleteAsync(id);
    }
    catch (Exception ex) 
    {
        return Results.BadRequest(ex.Message);
    }
    return Results.NoContent();
}).WithName("deleteBrand");
```

Cuando utilizamos el `IUseCase<BrandEntity>` en el constructor, este busca automaticamente la referencia en la inyeccion de dependencias centralizada y hace la inyeccion

### Documentacion de API con Swagger

Instalar paquete: Swashbuckle.AspNetCore

```C#
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Generacion de las herramientas de swagger necesarias

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

Link local: https://localhost:7280/swagger/index.html

## Introduccion a Blazor

### Que es Blazor

Es un framework que nos permite crear frontend con codigo de C#

### Modelos de hospedaje de blazor
* Blazor Server: Permite trabajar la logica de la interfaz en conjunto con el backend
* Blazor WebAssembly: Una aplicacion desacoplada del backend
* Blazor Hybrid: Forma de trabajar blazor junto con MAUI

### Ventajas de Blazor

* Reutilizacion de Codigo Backend
* Tipado fuerte con C#
* Poder usar un solo Stack
* Puede trabajar offline (PWA)

### Componentes Razor

Cualquier elementos visual que se encuentren en la pagina, son los componentes `.razor`

```C#
@page "/mycomponent"
<h3>Mi Componente</h3>

<p>Hola @name</p>
@code {
    private string name = "Samuel";

}
```

### Eventos

### Data Binding
Tecnica para crear un vinculo entre dos componentes

```C#
<input type="text" @bind="some" @bind:event="oninput"/>
<p>El valor de some es: @some</p>

@code {
    private string name = "Samuel";

    private int count = 0;

    private string some = "algo";

    private void Increase()
    {
        count++;
    }
}
```

### Inyeccion de Dependencia
Para inyectar el metodo http y poder hacer peticiones

```c#
@inject HttpClient Http
```

```C#
    protected override async Task OnInitializedAsync()
    {
        data = await Http.GetStringAsync("sample-data/people.json");
    }
```

### Parametros en componentes

Recibir datos

```C#
<p>Hola @Name soy un componente</p>
<p>Estoy viene desde otro componente: @Info</p>

@code {
    [Parameter] public string Name { get; set; } = string.Empty;
    [Parameter] public string Info { get; set; } = string.Empty;
}
```

En donde llamas el componente
```C#
<HiComponent Name="Juanito"/>
<HiComponent Name="@name" Info="@some"/>
```

### Ciclos de vida: Inicializacion de Componentes OnInitialized/OnInitializedAsync

Se crea al inicio

```C#
    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(2000);
        data = await Http.GetStringAsync("sample-data/people.json");
    }
```

### Ciclos de vida: Cambio de parametros con OnParametersSet / OnParametersSetAsync
Se ejecuta cada vez que se cambia un parametro

```C#
@code {
    [Parameter] public string Name { get; set; } = string.Empty;
    [Parameter] public string Info { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
        Console.WriteLine($"El valor del parametro ahora es {Info}");
    }
}
```

### Ciclo de vida: Cambio de estado en componente con OnAfterRenderAsync / OnAfterRender

Se ejecuta cada que cambie el estado, un componente cambia de estado cuando una variable cambia 

```C#
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) await Js.InvokeVoidAsync("console.log", "Primera vez que se carga el sitio");

        await Js.InvokeVoidAsync("console.log", "Se ha modificado el estado del componente");
    }
```

### Ciclo de vida: Componente destruido con Dispose / DisposeAsync

Se ejecuta cuando el componente deja de existir, util cuando tienes elementos pesados 

Necesita implementar IDisposable
```C#
@implements IDisposable

    public void Dispose()
    {
        Console.WriteLine("Dispose: Componente destruido");
    }
```
En este caso se ejecutara cada vez que se salga de la pagina

## Frontend con Blazor

### Generacion de cliente HTTP desde Contrato Swagger

* Comando instalar libreria nswag global:

```dotnet tool install --global Nswag.ConsoleCore```

* Comando para swagger generar api:

```nswag run nswag.json```

Codigo en nswag

```JSON
{
  "runtime": "Net90",
  "documentGenerator": {
    "fromDocument": {
      "url": null,
      "json": "OpenAPI/swagger.json"
    }
  },
  "codeGenerators": {
    "openApiToCSharpClient": {
      "className": "ApiClient",
      "namespace": "Frontend.Client",
      "generateClientInterfaces": true,
      "useBaseUrl": false,
      "generateBaseUrlProperty": false,
      "injectHttpClient": true,
      "disposeHttpClient": false,
      "generateOptionalParameters": true,
      "output": "ApiClient.cs",


    }
  }
}
```

Instalar Newtonsoft.Json para la solucion del error de metodos en el api    

Tambien es necesario instalar Microsoft.Extensions.Http

### Inyeccion del Cliente

```C#
builder.Services.AddHttpClient("Backend", http => 
{
    http.BaseAddress = new Uri(backendUrl);
});

builder.Services.AddScoped(sp =>
{
    var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient("Backend");
    return new ApiClient(http);
});
```

### Ejecutar backend en cmd

```dotnet watch run```  

### Configuracion de CORS
```C#

// Cors
const string FrontendPolicy = "FrontendPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: FrontendPolicy, policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// IMMPORTANTE COLOCARLO ANTES DE LOS ENDPOINTS
app.UseCors(FrontendPolicy);

```

## Mappers y DTO

### Que es un DTO

Es un objeto que te permite transportar objetos entre capas

### Que es un mapper

### ProductUseCase con mapper y dto

```C#
namespace Application.Product.UseCases
{
    public class ProductUseCase : IReadUseCase<ProductUseCase, ProductEntity>
    {
        private readonly IReadRepository<ProductEntity> _repository;
        private readonly IMapper<ProductEntity, ProductUseCase> _mapper;

        public ProductUseCase(IReadRepository<ProductEntity> repository, IMapper<ProductEntity, ProductUseCase> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductUseCase> GetByIdAsync(int id)
        {
            var productEntity = await _repository.GetByIdAsnyc(id);
            if (productEntity == null) return null;
            return _mapper.Map(productEntity);
        }

        public async Task<IEnumerable<ProductUseCase>> GetllAsync()
        {
            var productEntities = await _repository.GetAllAsync();
            return productEntities.Select(_mapper.Map);
        }
    }
}
```

### Product Repository 

```C#
namespace Repository
{
    public class ProductRepository : IReadRepository<ProductEntity>
    {
        private StoreFsContext _context;
        public ProductRepository(StoreFsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products.Select(MapToEntity);
        }

        public async Task<ProductEntity> GetByIdAsnyc(int id)
        {
            
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new KeyNotFoundException($"Producto no existe {id}");
            return MapToEntity(product);
        }

        #region Mapper
        private static ProductEntity MapToEntity(Product model)
        {
            return new ProductEntity(model.Id, model.Name, model.Cost, model.Price, model.Active);

        }
        #endregion
    }
}
```

### Inyeccion de dependencia

```C#
builder.Services.AddTransient<IReadRepository<ProductEntity>, ProductRepository>();
builder.Services.AddTransient<IReadUseCase<ProductDto, ProductEntity>, ProductUseCase>();
builder.Services.AddTransient<IMapper<ProductEntity, ProductDto>, ProductEntityToDtoMapper>();
```

## Segregacion de Interfaces

```C#
namespace Application.Abstractions
{
    public interface IReadRepository<TEntity>
    {
        public Task<TEntity> GetByIdAsnyc(int id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}

namespace Application.Abstractions
{
    public interface IReadUseCase<TDTO, TEntity>
    {
        public Task<TDTO> GetByIdAsync(int id);
        public Task<IEnumerable<TDTO>> GetllAsync();
    }
}

```

## Validaciones en Frontend (FluentValidation)
* Paquetes necesarios:
GreatIdeas.Blazored.FluentValidation
FluentValidation
FluentValidation.DependencyInjectionExtensions

```C#
using FluentValidation;
using Frontend.Client;

namespace FrontEnd.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).("Maximo 100 caracteres");
            RuleFor(x => x.Cost)
                .GreaterThan(0).WithMessage("El costo debe ser mayor a 0");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0")
                .Must((product, price) => price > product.Cost).WithMessage("el precio debe ser mayor al costo");
        }
    }
}
```

Inyeccion de dependencia
```C#
builder.Services.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();
```
validaciones en formulario
```C#
<EditForm Model="productDto" OnValidSubmit="SaveAsync">
    <FluentValidationValidator/> 
    <ValidationSummary/>

    <div>
        <InputNumber @bind-Value="productDto.Id" disabled hidden"></InputNumber>
    </div>
    <div class="mb-3">
        <label class="form-label">Nombre</label>
        <InputText class="form-control" @bind-Value="productDto.Name"></InputText>
    </div>
    <div class="mb-3">
        <label class="form-label">Costo</label>
        <InputNumber class="form-control" @bind-Value="productDto.Cost"></InputNumber>
    </div>
    <div class="mb-3">
        <label class="form-label">Precio</label>
        <InputNumber class="form-control" @bind-Value="productDto.Price"></InputNumber>
    </div>
    <div class="mb-3">
        <label class="form-label">Activo</label>
        <InputCheckbox class="form-check-input" @bind-Value="productDto.Active"></InputCheckbox>
    </div>
    <div class="mb-3">
        <label class="form-label">Marcas</label>
        <InputSelect class="form-select" @bind-Value="productDto.BrandId">
            <option value="">Sin marca</option>
            @foreach(var brand in brands)
            {
                <option value="@brand.Id">@brand.Name</option>
            }
        </InputSelect>
    </div>
    <button class="btn btn-primary" disabled="@isBusy">Guardar</button>
    <button class="btn btn-secondary ms-2" type="button" disabled>Volver</button>
</EditForm>
```

Para colocar el mensaje en el campo del formulario
```C#
    <div class="mb-3">
        <label class="form-label">Nombre</label>
        <InputText class="form-control" @bind-Value="productDto.Name"></InputText>
        <ValidationMessage For="@(()=> productDto.Name)"/>
    </div>
```

# Modulo Maestro-Detalle

Un modulo maestro detalle, es cuando tienes una entidad principal que posee otras entidades relacionadas
por ejemplo una venta, puede tener relacionado un conjunto relacionado llamado detalleVenta