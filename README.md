# Roadmap .NET - Cursos y Guía de Estudio

## Índice

1. [Fundamentos Compartidos](#fundamentos-compartidos)
2. [01-Curso de C#](#01-curso-de-c)
3. [02-Curso de Fundamentos de .NET](#02-curso-de-fundamentos-de-net)
4. [03-Curso de Programación Backend en .NET](#03-curso-de-programación-backend-en-net)
5. [04-Patrones de diseño en .NET](#04-patrones-de-diseño-en-net)
6. [05-Curso de Full Stack C# .NET](#05-curso-de-full-stack-c--net)
7. [Ejercicios Prueba](#ejercicios-prueba)

---

## Fundamentos Compartidos

*Sección consolidada con temas que aparecen en múltiples cursos, cada uno solo una vez.*

### Introducción a C# y .NET
C# es un lenguaje de programación moderno y orientado a objetos, parte del ecosistema .NET. Se utiliza para desarrollar aplicaciones de todo tipo, desde escritorio hasta web y móvil.

### Tipos de Datos Primitivos
En C# y .NET, los tipos de datos definen qué tipo de información puede almacenar una variable. Aquí tienes ejemplos de cada uno:

```csharp
// Entero sin decimales - Ideal para contadores e índices
int edad = 25;
int numeroId = 1001;

// Decimal de doble precisión - Para cálculos que requieren decimales
double precio = 19.99;
double pi = 3.14159;

 // Carácter único entre comillas simples - Para letras y símbolos
 char inicial = 'A';
 char signoMas = '+';

 // Cadena de texto entre comillas dobles - Para nombres, mensajes, descripciones
 string nombre = "Ana María";
 string mensaje = "Hola, mundo";

 // Booleano (true/false) - Para condiciones y toma de decisiones
 bool esMayorDeEdad = true;
 bool tieneDescuento = false;
```

### Interpolación de Strings
Permite insertar variables directamente dentro de un texto usando el símbolo `$` y llaves `{}`. Es más legible y eficiente que la concatenación con `+`. Ejemplo:

```csharp
int veces = 5;
string mensaje = $"La clase se ha utilizado {veces} veces";
// Resultado: "La clase se ha utilizado 5 veces"

string nombre = "Juan";
string saludo = $"Hola, {nombre}!";
```

### Funciones (Métodos)
Bloques de código reutilizables que realizan una tarea específica. Pueden recibir parámetros y devolver resultados. Ejemplos:

```csharp
// Sin parámetros, sin retorno - realiza una acción
static void Saludar() {
    Console.WriteLine("¡Hola!");
}

// Con parámetros, sin retorno - realiza una operación pero no devuelve el resultado
static int Sumar(int a, int b) {
    return a + b;
}

// Con parámetros, con retorno - calcula y devuelve el resultado
static int Multiplicar(int a, int b) {
    return a * b;
}

// Uso de las funciones
Saludar(); // Imprime "¡Hola!"
int resultado = Sumar(5, 3); // resultado es 8
int producto = Multiplicar(4, 7); // producto es 28
```

### Lógica Booleana y Operadores
Evaluaciones que retornan verdadero o falso. Ejemplos con código:

```csharp
int edad = 25;
bool esMayor = edad >= 18; // true

// Operadores lógicos
bool tieneLicencia = true;
bool esMexicano = false;

// AND (&&): verdadero solo si ambas condiciones se cumplen
bool puedeConducir = tieneLicencia && esMexicano;

// OR (||): verdadero si al menos una condición se cumple
bool traeSombrilla = true || false;

// IGUAL (==): verdadero si ambos valores son exactamente iguales
bool esDieciocho = edad == 18; // false
bool esVeinticinco = edad == 25; // true
```

### Sentencias Condicionales
Estructuras que ejecutan bloques de código según condiciones. Ejemplos:

```csharp
// if - Ejecuta un bloque si la condición es verdadera; con else para el caso contrario
int temperatura = 30;
if (temperatura > 30) {
    Console.WriteLine("Hace mucho calor");
} else {
    Console.WriteLine("El clima es agradable");
}

// switch - Evalúa una variable y ejecuta un bloque según su valor
string dia = "Lunes";
switch (dia) {
    case "Lunes": Console.WriteLine("Empieza la semana"); break;
    case "Viernes": Console.WriteLine("Almost weekend"); break;
    default: Console.WriteLine("Otro día"); break;
}

// while - Ejecuta un bloque mientras la condición sea verdadera
int contador = 0;
while (contador < 5) {
    Console.WriteLine($"Contador: {contador}");
    contador++;
}

// for - Bucle con tres fases: inicialización, condición y incremento
for (int i = 0; i < 3; i++) {
    Console.WriteLine($"Iteración {i}");
}

// foreach - Recorre cada elemento de una colección una vez
string[] nombres = {"Pedro", "María", "Luis"};
foreach (string nombre in nombres) {
    Console.WriteLine($"Hola, {nombre}");
}
```

### Programación Orientada a Objetos (POO)
Paradigma que organiza el código alrededor de "objetos" que contienen datos y comportamientos. Ejemplos de código:

```csharp
// Clase - Molde oplantilla para crear objetos
class Persona {
    // Propiedad pública - accesible desde fuera de la clase
    public string Nombre { get; set; }
    
    // Propiedad privada - solo dentro de la clase
    private int Edad { get; set; }
    
    // Constructor - se ejecuta al crear una nueva instancia
    public Persona(string nombre, int edad) {
        Nombre = nombre;
        Edad = edad;
    }
    
    // Método - comportamiento del objeto
    public void Saludar() {
        Console.WriteLine($"Hola, soy {Nombre} y tengo {Edad} años");
    }
}

// Objeto - Instancia de la clase
Persona persona1 = new Persona("Ana", 25);
persona1.Saludar(); // Imprime: "Hola, soy Ana y tiene 25 años"

// Herencia - Una clase hereda de otra
class Empleado : Persona {
    public string Puesto { get; set; }
    
    public Empleado(string nombre, int edad, string puesto) : base(nombre, edad) {
        Puesto = puesto;
    }
    
    // Sobrescritura de método - la clase hija proporciona una implementación específica
    public override void Saludar() {
        Console.WriteLine($"Empleado: {Nombre} trabaja como {Puesto}");
    }
}
```

### Formato JSON y Serialización
JSON (JavaScript Object Notation) es un formato ligero para intercambio de datos. En C# con System.Text.Json:

```csharp
using System.Text.Json;

// Clase ejemplo
class Persona {
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

// Serializar: Convertir objeto a texto JSON
Persona p = new Persona { Nombre = "Juan", Edad = 30 };
string json = JsonSerializer.Serialize(p);
// json ahora es: {"Nombre":"Juan","Edad":30}

// Deserializar: Convertir texto JSON a objeto
Persona p2 = JsonSerializer.Deserialize<Persona>(json);
// p2.Nombre es "Juan", p2.Edad es 30
```

### Arreglos
Estructura de datos que guarda una colección de elementos del **mismo tipo** bajo un mismo nombre. Tiene tamaño fijo una vez creado.

```csharp
string[] friends = new string[7] { "Juan", "Pedro", "Ana", "Luis", "Karla", "Ramón", "Sofía" };
friends[0] = "Juan"; // Acceso al primer elemento
friends[6] = "Sofía"; // Modificación del último elemento
```

### Listas (`List<T>`)
Estructura de datos similar a los arreglos, pero con tamaño **dinámico**. Puede crecer o reducirse mientras la aplicación se ejecuta.

```csharp
List<int> numbers = new List<int>();
numbers.Add(5);      // Agrega 5 a la lista
numbers.Add(10);     // Agrega 10 a la lista
numbers.Count;       // Retorna 2 (cantidad de elementos)
numbers.Sort();      // Ordena la lista de forma ascendente
numbers.Clear();     // Remueve todos los elementos
```

Diferencia clave: Los arreglos tienen tamaño fijo; las listas pueden cambiar de tamaño dinámicamente y tienen métodos útiles integrados (`Add`, `Remove`, `Sort`, `Count`, etc.).

### Programación Funcional
Paradigma que trata las funciones como valores que pueden asignarse a variables, pasarse como parámetros o devolverse como resultado. Ejemplos:

```csharp
using System;

// Delegate - Referencia a un método con una firma específica
delegate int Operacion(int a, int b);

// Uso del delegate
Operacion suma = Sumar;
Console.WriteLine(suma(3, 4)); // Imprime 7

// Lambda - Sintaxis abreviada para funciones anonimas
// Suma dos números
int resultado = (int a, int b) => a + b;
Console.WriteLine(resultado(5, 3)); // Imprime 8

// Func - Delegado que siempre tiene un valor de retorno
// Devuelve el mayor de dos números
Func<int, int, int> Mayor = (a, b) => a > b ? a : b;
Console.WriteLine(Mayor(10, 7)); // Imprime 10

// Predicate - Delegado que siempre retorna un booleano
// Verifica si un número es par
Predicate<int> esPar = (num) => num % 2 == 0;
Console.WriteLine(esPar(4)); // Imprime True
Console.WriteLine(esPar(5)); // Imprime False
```

### LINQ (Language Integrated Query)
Conjunto de métodos y sintaxis para consultar colecciones de datos de forma declarativa, muy parecido a SQL pero en C#. Ejemplos:

```csharp
List<int> numeros = new List<int> { 5, 10, 15, 20, 25 };

// Where - Filtra los elementos que cumplen una condición
var numerosPares = numeros.Where(n => n % 2 == 0);
// Resultado: { 10, 20 }

// Select - Proyecta o selecciona propiedades específicas
var numerosDobles = numeros.Select(n => n * 2);
// Resultado: { 10, 20, 30, 40, 50 }

// Orderby - Ordena los resultados de forma ascendente o descendente
var numerosOrdenados = numeros.OrderBy(n => n).ToList();
// Resultado: { 5, 10, 15, 20, 25 }

// JOIN - Une dos colecciones basándose en una relación entre ellas
List<Persona> personas = new List<Persona> { ... };
List<Direccion> direcciones = new List<Direccion> { ... };

var resultado = from p in personas
                join d in direcciones on p.Id equals d.PersonId
                select new { Nombre = p.Nombre, Calle = d.Calle };
```

### Tipos Anónimos y Tuplas

- **Tipos Anónimos:** Objetos creados "al vuelo" sin necesidad de declarar una clase formal. Usando la palabra `var`. Solo son `readonly` (de solo lectura).

```csharp
var samuel = new { Name = "Samuel", Country = "Venezuela" };
// samuel.Name y samuel.Country están disponibles, pero la clase no tiene nombre explícito
```

- **Tuplas:** Estructura que agrupa un número fijo de valores, posiblemente de tipos diferentes, en una sola entidad.

```csharp
(int id, string name) product = (1, "Cerveza stout");
// Acceso: product.id -> 1, product.name -> "Cerveza stout"
```

Ideal para retornar varios valores de una función sin crear una clase o struct completo.

### Manejo de Excepciones (Errores)
Mecanismo para capturar y manejar errores inesperados durante la ejecución del programa.

```csharp
try {
    // Intenta ejecutar este bloque de código
    string contenido = File.ReadAllText("archivo.txt");
    Console.WriteLine(contenido);
} catch (FileNotFoundException ex) {
    // Maneja específicamente el caso de que el archivo no exista
    Console.WriteLine("El archivo no existe");
} catch (Exception ex) {
    // Maneja cualquier otro error inesperado
    Console.WriteLine("Ocurrió un error general");
    Console.WriteLine(ex.Message); // Muestra el mensaje de error
} finally {
    // Opcional: Se ejecuta siempre, tanto si hubo error como si no
    Console.WriteLine("Bloque finalizado");
}
```

### Excepciones Personalizadas
Permite crear tipos de error específicos para el dominio del negocio, heredando de la clase base `Exception`.

```csharp
public class InvalidBeerException : Exception {
    public InvalidBeerException() : base("La cerveza no tiene nombre o marca, por lo cual es invalida") {
        // Constructor personalizado con mensaje específico
    }
}
```

Útil para validaciones de negocio y mensajes de error significativos para el usuario.

---

## 01-Curso de C#

### Índice de Conceptos
1. Estructura de Soluciones y Proyectos
2. Tipos de Datos y Variables
3. Interpolación de Strings y Operaciones Básicas
4. Funciones y Lógica Booleana
5. Sentencias Condicionales y Bucles
6. Programación Orientada a Objetos (POO)
7. Arreglos y Listas
8. Programación Funcional y LINQ
9. Tipos Anónimos y Tuplas
10. Excepciones

### Descripción
Curso completo de C# desde niveles principiante hasta avanzado. Cubre todos los fundamentos del lenguaje, programación orientada a objetos, manejo de datos y consultas.

### Objetivo
Dominar los fundamentos de C# y el .NET Framework para poder desarrollar aplicaciones console y comprender la base para desarrollo posterior en .NET Core/.NET 5+.

### Contenido del curso

#### Estructura de Soluciones y Proyectos
- **Solución:** Contenedor que agrupa uno o más proyectos relacionados.
- **Proyecto:** Unidad de código y recursos (exe, librería, API, tests, etc.).
- **Para qué:** Organizar proyectos relacionados (ej. una API y su capa de datos) en un mismo entorno de trabajo.

```csharp
// Ejemplo de estructura de solución en la consola
dotnet new sln -n MiAplicacion

# Agregar proyectos a la solución
dotnet sln MiAplicacion.sln add MiApi/MiApi.csproj
dotnet sln MiAplicacion.sln add MiAplicacion/MiAplicacion.csproj

// Ver estructura de la solución
# En la carpeta del proyecto de la API
dotnet new webapi -n MiApi
dotnet new console -n MiAplicacion
```

## 02-Curso de Fundamentos de .NET

### Índice de Conceptos
1. Solución vs Proyecto
2. Arquitectura de Capas (Domain, Application, Data)
3. Entity Framework ORM
4. Inyección de Dependencias (DI)
5. Controladores API y Métodos HTTP
6. Tipos de Respuesta (ActionResult, IActionResult)
7. Programación Asíncrona y Sincrónica
8. Modelos vs DTOs
9. AutoMapper
10. Inyección de Dependencia por Clave (Keyed Services)
11. Cadena de Conexión
12. Migraciones de Base de Datos

### Descripción
Fundamentos del ecosistema .NET, arquitectura de capas y desarrollo de aplicaciones empresariales con separación de responsabilidades.

### Objetivo
Comprender la arquitectura de aplicaciones .NET empresariales y poder desarrollar soluciones mantenibles, testables y escalables con separación clara entre dominio, aplicación e infraestructura.

### Contenido del curso

#### Solución vs Proyecto
Diferencia conceptual y práctica entre la entidad "Solución" (contenedor) y "Proyecto" (contenedor de código) en el entorno Visual Studio/.NET. Ejemplo de estructura de directorios:

```text
MiSolucion/
├── MiApi/              # Proyecto tipo API
├── MiAplicacion/       # Proyecto de aplicación
├── MiTests/            # Proyecto de pruebas unitarias
└── MiSolucion.sln      # Archivo de solución
```

```csharp
# Comando para crear una nueva solución
dotnet new sln -n MiAplicacion

# Agregar proyectos a la solución
dotnet sln MiAplicacion.sln add MiApi/MiApi.csproj
dotnet sln MiAplicacion.sln add MiAplicacion/MiAplicacion.csproj

# Ver estructura de la solución
# En la carpeta del proyecto de la API
dotnet new webapi -n MiApi
dotnet new console -n MiAplicacion
```

#### Arquitectura de Capas (Capas de una aplicación .NET)
Separación del código en capas lógicas con responsabilidades definidas. Ejemplo de capas en un proyecto .NET:

```csharp
# Estructura de carpetas en un proyecto .NET típico
# MiAplicacion/
# ├─ MiAplicacion.Domain/     # Capa Domain (entidades y reglas de negocio)
# ├─ MiAplicacion.Application/ # Capa Application (casos de uso)
# ├─ MiAplicacion.Data/       # Capa Data (repositorio y BD)
# └─ MiAplicacion.WebApi/     # Proyecto API

# Ejemplo de entidad en la capa Domain
public class Persona {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
}
```

```csharp
# Ejemplo de DbContext en la capa Data
public class MiDbContext : DbContext {
    public MiDbContext(DbContextOptions<MiDbContext> options) : base(options) { }
    
    public DbSet<Persona> Personas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Persona>(entity => {
            entity.ToTable("Personas");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });
    }
}
```

#### Programación Asíncrona y Sincrónica
- **Sincrónica:** El hilo de ejecución espera a que la operación termine antes de continuar. `Thread.Sleep(1000)` bloquea por 1 segundo. Ejemplo:

```csharp
# Sincrónica - Bloquea el hilo durante la operación
Thread.Sleep(1000); // Espera 1 segundo, no se ejecuta nada más hasta terminar
Console.WriteLine("Después de 1 segundo");
```

- **Asíncrona (`async/await`):** El hilo no espera bloqueado; continúa ejecutando otras tareas mientras la operación (BD, llamada HTTP) se procesa en segundo plano. Al finalizar, se retoma la ejecución con `await`. Ejemplo:

```csharp
# Asíncrona - No bloquea el hilo
public async Task<int> ObtenerDatosAsync() {
    // Simula una operación larga de 2 segundos
    await Task.Delay(2000); 
    return 42; // Retorna el resultado después de la espera
}

# Uso en un controlador
public async Task<IActionResult> Obtener() {
    int dato = await ObtenerDatosAsync(); // ¡Hace otras cosas mientras espera!
    return Ok(dato);
}
```

**Para qué:** Aplicaciones más responsivas y de mejor rendimiento, especialmente en operaciones que implican esperar (bases de datos, servicios web, archivos).

#### Modelos vs DTOs
- **Modelos:** Representan la estructura de las entidades de la base de datos, con todas sus propiedades (incluyendo las de auditoría, relaciones, etc.). Ejemplo:

```csharp
# Ejemplo de modelo (entidad completa)
public class Persona {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateTime FechaCreacion { get; set; }  // Auditoria
    public DateTime? FechaModificacion { get; set; } // Auditoria opcional
    public virtual Marca Marca { get; set; }  // Relación navegacional
}
```

- **DTOs (Data Transfer Object):** Objetos que contienen solo los datos necesarios para transferir entre capas o al cliente. Ejemplo:

```csharp
# Ejemplo de DTO (solo datos esenciales)
public class PersonaDto {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
}
```

**AutoMapper:** Herramienta para automatizar el mapeo entre modelos y DTOs, reduciendo código repetitivo de asignación manual de propiedades. Ejemplo de configuración:

```csharp
# Configuración de AutoMapper en Program.cs
builder.Services.AddAutoMapper(typeof(MappingProfile));

# Perfil de mapeo
public class MappingProfile : Profile {
    public MappingProfile() {
        # Mapeo de entidad a DTO
        CreateMap<Persona, PersonaDto>();
        
        # Mapeo de DTO a entidad (con personalización)
        CreateMap<PersonaDto, Persona>()
            .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
```

**Uso en el servicio:**
```csharp
# Uso en el servicio o controlador
var persona = new Persona { Id = 1, Nombre = "Juan", Email = "juan@test.com" };
var personaDto = _mapper.Map<PersonaDto>(persona); // AutoMapper hace el mapeo automático
```

#### Inyección de Dependencia por Clave (Keyed Services)
Cuando hay múltiples implementaciones de la misma interfaz y se necesita inyectar una específica por nombre/etiqueta. Ejemplo:

```csharp
# Registro de servicios con clave diferenciada
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");
builder.Services.AddKeyedSingleton<IPeopleService, AlternativePeopleService>("altPeopleService");

# Uso en el controlador - inyectar la implementación específica
public class PeopleController {
    private readonly IPeopleService _peopleService;
    
    public PeopleController([FromKeyedServices("peopleService")] IPeopleService peopleService) {
        _peopleService = peopleService;
    }
}

# Escenario: Tener dos servicios que implementan la misma interfaz pero con comportamiento diferente
# - "peopleService": Implementación principal para uso general
# - "altPeopleService": Implementación alternativa para casos específicos o pruebas
```
**Para qué:** Cuando se necesita inyectar una de varias clases que implementan la misma interfaz, según la necesidad específica. Permite mantener el principio de inversión de dependencias mientras se selecciona la implementación correcta en tiempo de ejecución.

#### Cadena de Conexión
Cadena de texto que contiene la información necesaria para conectar con una base de datos. Generalmente se almacena en el archivo `appsettings.json` y se lee en `Program.cs`. Ejemplo completo:

```json
# Contenido de appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=RegisterDB;Trusted_Connection=True;",
    "AlternativeConnection": "Server=(localdb)\\mssqllocaldb;Database=ArchiveDB;Trusted_Connection=True;"
  }
}
```

```csharp
# Lectura de cadena de conexión en Program.cs
var builder = WebApplication.CreateBuilder(args);

# Leer la cadena de conexión configurada
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

# Alternativa: Acceder a todas las cadenas de configuración
var allConnections = builder.Configuration.GetSection("ConnectionStrings").GetChildren()
    .ToDictionary(k => k.Key, v => v.Value);

# Uso con Entity Framework
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(connectionString);
});
```

**Para qué:** Separar la configuración del código facilitar cambiar de entorno (desarrollo, producción) sin modificar el código. Permite tener diferentes cadenas de conexión para desarrollo, pruebas y producción.

#### Migraciones de Base de Datos
Proceso para actualizar el esquema de la base de datos cuando cambian las entidades del código. Ejecución paso a paso:

```bash
# 1. Instalar herramienta global (solo la primera vez)
dotnet tool install --global dotnet-ef

# 2. Crear una nueva migración (después de cambiar tus entidades C#)
dotnet ef migrations add InitialCreate
# o para una migración subsiguiente:
dotnet ef migrations add AgregarCampoTelefono

# 3. Aplicar las migraciones pendientes a la base de datos
dotnet ef database update
# o para una migración específica:
dotnet ef database update InitialCreate
# o para la última migración:
dotnet ef database update
```

```csharp
# Ejemplo de migración generada automáticamente
public class InitialCreate : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
        migrationBuilder.CreateTable(
            "Personas",
            table => table
                .Column<int>("Id").IsPrimaryKey()
                .Column<string>("Nombre").IsRequired()
                .Column<string>("Email").IsRequired()
        );
    }
    
    protected override void Down(MigrationBuilder migrationBuilder) {
        migrationBuilder.DropTable("Personas");
    }
}
```

**Para qué:** Llevar la base de datos al mismo estado que el código, controlar cambios estructurales y mantener consistencia en equipos de trabajo. Permite versionar la base de datos al igual que se versiona el código fuente.

---

#### Cadena de Conexión
Cadena de texto que contiene la información necesaria para conectar con una base de datos. Generalmente se almacena en el archivo `appsettings.json` y se lee en `Program.cs`.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=RegisterDB;Trusted_Connection=True;"
}
```

**Para qué:** Separar la configuración del código facilitar cambiar de entorno (desarrollo, producción) sin modificar el código.

#### Migraciones de Base de Datos
Proceso para actualizar el esquema de la base de datos cuando cambian las entidades del código.

Pasos:
1. Instalar herramienta global: `dotnet tool install --global dotnet-ef`
2. Crear migración: `dotnet ef migrations add InitialCreate`
3. Aplicar migración: `dotnet ef database update`

**Para qué:** Llevar la base de datos al mismo estado que el código, controlar cambios estructurales y mantener consistencia en equipos de trabajo.

---

## 03-Curso de Programación Backend en .NET

### Índice de Conceptos
1. Introducción a .NET
2. Tipos de Propiedades y Creación de Objetos
3. Herencia y Sobrescritura
4. Interfaces
5. Generics (Genéricos)
6. Serialización y Deserialización JSON
7. Controladores ASP.NET Core
8. Métodos HTTP Detallados
9. Tipo de Respuesta `ActionResult<T>`
10. Inyección de Dependencias (Profundización)
11. Programación Asíncrona Profunda
12. Modelos vs DTOs en Backend
11. FluentValidation
12. Refactorización de Código
13. Interfaces Genéricas
14. Repositorio Pattern (Patrón Repositorio)
15. AutoMapper (Profundización)
16. Modificaciones en Modelos EF

### Descripción
Curso enfocado en desarrollo de backends robustos con .NET, incluyendo APIs, controladores, Entity Framework y patrones de arquitectura. Cubre desde conceptos base hasta implementaciones enterprise con validaciones y auto-mapper.

### Objetivo
Desarrollar APIs RESTful completas con .NET 8+, aplicar patrones de arquitectura, manejo de bases de datos con Entity Framework y buenas prácticas de seguridad y validación.

### Contenido del curso

#### Introducción a .NET
Breve historial y diferencias entre .NET Framework (privado, Windows-only, creado 2002) y .NET Core/.NET 5+ (código abierto, multiplataforma, creado 2014). Actual actual: .NET 8+ unificado, con mejoras de performance y cross-platform.

```csharp
# Verificación de versión de .NET
dotnet --version

# Comando para crear un nuevo proyecto de API
dotnet new webapi -n MiApi

# Ver información del proyecto creado
cd MiApi
dotnet run
```

**Para decisiones de arquitectura:** Elegir la versión adecuada según los requerimientos de plataforma y características necesarias.

#### Tipos de Propiedades y Creación de Objetos
Definición de propiedades con accesadores `public`, `private`, `protected`. Creación de instancias con `new`, `new()` o `var`. La palabra `var` permite inferir el tipo de forma implícita (solo dentro de métodos). Ejemplos:

```csharp
# Propiedades con accesadores de acceso público
class Producto {
    public string Nombre { get; set; }  // Accesible desde cualquier parte
    public decimal Precio { get; set; }
    public int Stock { get; private set; }  // Solo se modifica internamente
}

# Creación de objetos con 'new'
var producto1 = new Producto { Nombre = "Laptop", Precio = 1500m, Stock = 10 };

# Uso de 'var' para inferencia de tipo (solo dentro de métodos)
void ProcesarProductos() {
    var producto2 = new Producto(); // El compilador sabe que es Producto
    producto2.Nombre = "Mouse";
    producto2.Precio = 25.50m;
}
```

**Para qué:** Definir claramente la visibilidad de los datos y crear instancias de clases de manera controlada.

#### Herencia y Sobrescritura
Clase que hereda de otra usando `: base`. El método `virtual` en el padre permite `override` en el hijo para polimorfismo en tiempo de ejecución.

**Para qué:** Reutilizar código y establecer jerarquías de tipos donde un tipo es un especialización de otro. Ejemplos:

```csharp
# Clase base con método virtual
public class Figura {
    public string Nombre { get; set; }
    
    # Método virtual que puede ser sobrescrito
    public virtual double CalcularArea() {
        return 0;
    }
    
    # Método con implementación por defecto
    public void MostrarInformacion() {
        Console.WriteLine($"Figura: {Nombre}");
        Console.WriteLine($"Área: {CalcularArea():N2}");
    }
}

# Clase derivada que sobrescribe el método virtual
public class Circulo : Figura {
    public double Radio { get; set; }
    
    # Sobrescritura de método - proporcionar implementación específica
    public override double CalcularArea() {
        return Math.PI * Radio * Radio;
    }
}

# Clase derivada diferente que también sobrescribe
public class Rectangulo : Figura {
    public double Base { get; set; }
    public double Altura { get; set; }
    
    # Sobrescritura de método con implementación diferente
    public override double CalcularArea() {
        return Base * Altura;
    }
}

# Uso de la jerarquía de herencia
Figura figura1 = new Circulo { Radio = 5 };
figura1.MostrarInformacion(); // Usa la implementación de Circulo

Figura figura2 = new Rectangulo { Base = 4, Altura = 5 };
figura2.MostrarInformacion(); // Usa la implementación de Rectangulo
```

**Para qué:** Permite que las clases hijas proporcionen implementaciones específicas de métodos del padre, enabling polimorfismo en tiempo de ejecución.

#### Interfaces
Contrato que define un conjunto de métodos que una clase debe implementar. Una clase puede implementar varias interfaces (a diferencia de la herencia simple, que solo hereda de una). Ejemplos:

```csharp
# Interfaz que define un contrato de comportamiento
public interface IGuardable {
    # Firma del método que debe implementarse
    void Guardar();
    # Propiedad que las implementaciones deben tener
    string NombreArchivo { get; set; }
}

# Clase que implementa la interfaz usando herencia simple
public class Archivo : IGuardable {
    # Implementación del método de la interfaz
    public string NombreArchivo { get; set; } = "archivo.txt";
    
    # Implementación del método de la interfaz
    public void Guardar() {
        Console.WriteLine($"Guardando {NombreArchivo}...");
        # Lógica de guardado en disco
    }
}

# Otra clase que implementa la misma interfaz pero con comportamiento diferente
public class BaseDeDatos : IGuardable {
    # Implementación del método de la interfaz con distinto comportamiento
    public string NombreArchivo { get; set; } = "base_datos.sql";
    
    # Implementación del método de la interfaz
    public void Guardar() {
        Console.WriteLine($"Guardando esquema de base de datos {NombreArchivo}...");
        # Lógica de guardado en BD
    }
}

# Clase que implementa MÚLTIPLES interfaces
public class RepositorioArchivoYBD : IGuardable, IEnumerable<string> {
    # Implementación de la interfaz IGuardable
    public string NombreArchivo { get; set; } = "archivo_repositorio.txt";
    
    # Implementación de la interfaz IGuardable
    public void Guardar() {
        Console.WriteLine($"Guardando en repositorio: {NombreArchivo}");
    }
    
    # Implementación de interfaz IEnumerable (requerida por ser múltiples interfaces)
    public IEnumerator<string> GetEnumerator() {
        yield return "elemento1";
        yield return "elemento2";
    }
    
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
```

**Para qué:** Definir habilidades que debe tener un objeto sin decir cómo las implementa; acoplamiento bajo y facilidad para testing con mocks. El poder implementar varias interfaces es clave para diseñar sistemas flexibles y desacoplados.

#### Generics (Genéricos)
Clases y métodos con tipos parametrizados (`<T>`). Permite reutilizar lógica para diferentes tipos de datos sin duplicar código. Ejemplos:

```csharp
# Clase genérica genérica con tipo parametrizado
public class Lista<T> {
    # Lista interna para almacenar elementos
    private T[] _items;
    private int _contador;
    
    # Constructor que inicializa la lista con tamaño predeterminado
    public Lista(int tamaño = 10) {
        _items = new T[tamaño];
        _contador = 0;
    }
    
    # Agregar un elemento a la lista
    public void Agregar(T item) {
        if (_contador < _items.Length) {
            _items[_contador] = item;
            _contador++;
        }
    }
    
    # Obtener elemento por índice
    public T Obtener(int indice) {
        if (indice >= 0 && indice < _contador) {
            return _items[indice];
        }
        throw new IndexOutOfRangeException();
    }
    
    # Retornar la cantidad de elementos
    public int Contar() {
        return _contador;
    }
}

# Uso de la clase genérica con diferentes tipos
var numeros = new Lista<int>();
numeros.Agregar(1);
numeros.Agregar(2);
numeros.Agregar(3);
Console.WriteLine(numeros.Obtener(0)); // Imprime 1

var textos = new Lista<string>();
textos.Agregar("Hola");
textos.Agregar("Mundo");
Console.WriteLine(textos.Obtener(1)); // Imprime "Mundo"

# Método genérico estático con tipo parametrizado
public static void ImprimirPrimero<T>(Lista<T> lista) {
    Console.WriteLine($"Primer elemento: {lista.Obtener(0)}");
}

# Uso con diferentes tipos
ImprimirPrimero(numeros); // Imprime "Primer elemento: 1"
ImprimirPrimero(textos);  // Imprime "Primer elemento: Hola"
```

**Para qué:** Lógica reutilizable para cualquier tipo de dato (listas, métodos, clases). Evita la duplicación de código y proporciona seguridad de tipos en tiempo de compilación.

#### Serialización y Deserialización JSON
Convertir objetos a texto JSON y viceversa usando `System.Text.Json`. Ejemplos:

```csharp
using System.Text.Json;
using System.Text.Json.Serialization;

# Clase ejemplo a serializar
public class Producto {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public bool Disponible { get; set; }
}

# Serializar objeto a JSON (a cadena de texto)
Producto producto = newProducto: newProducto: newProducto: newProducto { Id = 1, Nombre = "Laptop", Precio = 1500m, Disponible = true };
string json = JsonSerializer.Serialize(producto);
// json: {"Id":1,"Nombre":"Laptop","Precio":1500.0,"Disponible":true}

# Deserializar JSON a objeto
string jsonData = "{\"Id\":2,\"Nombre\":\"Mouse\",\"Precio\":25.50,\"Disponible\":true}";
Producto producto2 = JsonSerializer.Deserialize<Producto>(jsonData);
// producto2.Id es 2, producto2.Nombre es "Mouse", etc.

# Opciones de serialización (para formateo, insensibilidad a mayúsculas/minúsculas, etc.)
var options = new JsonSerializerOptions {
    WriteIndented = true, // Formato con sangría/indentación
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Usar camelCase en el JSON
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull // Ignorar propiedades null
};

string jsonConOpciones = JsonSerializer.Serialize(producto, options);
```

**Para qué:** Intercambio de datos entre sistemas, APIs web, guardado de configuraciones y comunicación con servicios externos. Es el formato estándar para APIs REST.

#### Controladores ASP.NET Core
Estructura base de un controlador de API con atributos de routing y métodos para cada tipo de petición HTTP.

```csharp
[Route("api/[controller]")]
[ApiController]
public class OperationController : ControllerBase {
    [HttpGet("all")] public List<People> GetPeople() => Repository.People;
    [HttpGet("{id}")] public People Get(int id) => Repository.People.First(p => p.Id == id);
    [HttpPost] public ActionResult Add(People people) { ... }
    // ... otros métodos
}
```

Atributos importantes:
- `[Route]`: Define la ruta base de la API.
- `[ApiController]`: Habilita comportamientos automáticos de API (status codes, validación de modelo).

#### Métodos HTTP Detallados
Estructura y uso de cada tipo de petición HTTP en controladores. Ejemplos completos:

```csharp
# HttpGet - Consultar datos (listar o obtener uno específico)
[HttpGet("all")]
public IActionResult ObtenerTodos() {
    var productos = _productoService.ObtenerTodos();
    return Ok(productos); // HTTP 200 con lista de productos
}

[HttpGet("{id:int}")]
public IActionResult ObtenerPorId(int id) {
    var producto = _productoService.ObtenerPorId(id);
    if (producto == null) {
        return NotFound(new { mensaje = "Producto no encontrado" }); // HTTP 404
    }
    return Ok(producto); // HTTP 200 con el producto
}

# HttpPost - Crear un nuevo recurso (puede recibir datos en el cuerpo)
[HttpPost]
public IActionResult Crear([FromBody]Producto productoDto) {
    # Validar el modelo ModelState
    if (!ModelState.IsValid) {
        return BadRequest(ModelState); // HTTP 400 con errores de validación
    }
    
    # Crear el producto en la base de datos
    var producto = _productoService.Crear(productoDto);
    return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto); // HTTP 201 creado
}

# HttpPut - Actualizar un recurso existente
[HttpPut("{id:int}")]
public IActionResult Actualizar(int id, [FromBody]ProductoActualizarDto productoDto) {
    # Verificar si el producto existe
    var productoExistente = _productoService.ObtenerPorId(id);
    if (productoExistente == null) {
        return NotFound(); // HTTP 404
    }
    
    # Actualizar los datos
    _productoService.Actualizar(id, productoDto);
    return NoContent(); // HTTP 204 sin contenido (actualización exitosa)
}

# HttpDelete - Eliminar un recurso
[HttpDelete("{id:int}")]
public IActionResult Eliminar(int id) {
    # Verificar si el producto existe
    var producto = _productoService.ObtenerPorId(id);
    if (producto == null) {
        return NotFound(); // HTTP 404
    }
    
    # Eliminar el producto
    _productoService.Eliminar(id);
    return NoContent(); // HTTP 204 sin contenido (eliminación exitosa)
}
```
**Para qué:** Cada tipo de petición HTTP tiene un propósito específico en una API RESTful y define el comportamiento esperado del cliente y el servidor.

#### Tipo de Respuesta `ActionResult<T>`
Permite a los métodos de controlador regresar tanto códigos de estado HTTP como datos tipados.

```csharp
public ActionResult<People> Get(int id) {
    var person = repo.Find(id);
    if (person == null) return NotFound();  // HTTP 404
    return Ok(person);                      // HTTP 200 con datos
}
```

**`IActionResult`:** Aún más flexible, permite regresar resultados puros sin tipo (`BadRequest()`, `NoContent()`, `Ok()`).

**Para qué:** Respuestas HTTP apropiadas y flexibles en APIs REST.

#### Inyección de Dependencias (Profundización)
Registro y consumo de servicios en el contenedor DI.

- **Singleton:** Una instancia única para toda la vida de la aplicación.
- **Scoped:** Una instancia por cada solicitud HTTP (por defecto en ASP.NET Core).
- **Transient:** Una instancia cada vez que se solicite (ideal para servicios ligeros).

**Inyección en controladores:** Recibir dependencias por el constructor, lo que permite testear con mocks y cambiar implementaciones sin modificar la clase del controlador.

**Inyección por clave (keyed):** Cuando hay múltiples servicios para la misma interfaz y se necesita especificar cuál usar por nombre.

**Para qué:** Acoplamiento bajo, testabilidad y facilidad para reemplazar componentes.

#### Programación Asíncrona Profunda
Uso avanzado de `async` y `await` para tareas que implican esperar (operaciones de BD, llamadas a APIs externas). Ejemplo con `Task` explícito para ejecutar trabajo en paralelo con `Task.Start()` y `Console.WriteLine` mientras tanto.

**Para qué:** Optimizar rendimiento cuando hay múltiples operaciones independientes que pueden paralelizarse.

#### Modelos vs DTOs en Backend
Detalle de cómo diferenciar y usar modelos (entidades completas con todas las propiedades de BD) y DTOs (versiones simplificadas para la capa de presentación).

Ejemplo con Entity Framework:
```csharp
public class Bear {
    [Key]                                          // PK
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
    public int BeerId { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    public virtual Brand Brand { get; set; } // Navigation property
}
```

Atributos clave:
- `[Key]`: Indica a Entity Framework cuál es la primary key.
- `[DatabaseGenerated]`: Especifica si el valor se genera automáticamente (identity).
- `[ForeignKey]`: Define la relación con otra tabla.
- `virtual`: Habilita *lazy loading* (cargar related data cuando se accede a la propiedad).

**Para qué:** Mapear correctamente las entidades a la base de datos y habilitar cargas diferidas.

#### FluentValidation
Biblioteca para validaciones declarativas y centralizadas de modelos DTOs.

```csharp
public class BeerInsertValidator : AbstractValidator<BeerInsertDto> {
    public BeerInsertValidator() {
        RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
        RuleFor(x => x.Name).Length(2, 20).WithMessage("Máximo 20 caracteres");
        RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage("El alcohol debe ser mayor a 0");
    }
}
```

**Uso en controlador:**
```csharp
var validation = await _validator.ValidateAsync(dto);
if (!validation.IsValid) return BadRequest(validation.Errors);
```

**Para qué:** Validaciones consistentes, mensajes amigables para el usuario, centralización y reutilización en diferentes puntos de la aplicación.

#### Refactorización de Código
Reestructuración del código existente sin cambiar su comportamiento externo, con el objetivo de mejorar legibilidad, mantenibilidad y/o rendimiento. Ejemplos:

```csharp
# Ejemplo de refactorización: Mover lógica de un controlador a un servicio

# Antes: Lógica en el controlador
public IActionResult CalcularTotal(int id) {
    var producto = _repositorio.ObtenerPorId(id);
    decimal total = 0;
    
    # Cálculo complejo aquí...
    total = producto.Precio * producto.Cantidad;
    
    # Adicional: Limpieza y formateo
    if (total > 0) {
        total = Math.Round(total, 2);
    }
    
    return Ok(total);
}

# Después: Lógica en el servicio (mejor separación de responsabilidades)
public class ProductoServicio {
    private readonly IRepositorio _repositorio;
    
    public ProductoServicio(IRepositorio repositorio) {
        _repositorio = repositorio;
    }
    
    public decimal CalcularTotal(int id) {
        var producto = _repositorio.ObtenerPorId(id);
        decimal total = producto.Precio * producto.Cantidad;
        return Math.Round(total, 2);
    }
}

# Uso refactorizado en el controlador
public class ProductosController : ControllerBase {
    private readonly ProductoServicio _productoServicio;
    
    public ProductosController(ProductoServicio productoServicio) {
        _productoServicio = productoServicio;
    }
    
    public IActionResult CalcularTotal(int id) {
        # Delegar la lógica al servicio
        decimal total = _productoServicio.CalcularTotal(id);
        return Ok(total);
    }
}
```

**Para qué:** Código más limpio, más fácil de mantener y escalar, y aplicación continua de buenas prácticas. La refactorización debe realizarse de forma incremental y con pruebas que aseguren que el comportamiento no cambia.

#### Interfaces Genéricas
Definir interfaces con parámetros de tipo genérico para operaciones CRUD (Crear, Leer, Actualizar, Borrar) comunes. Ejemplo:

```csharp
public interface IRepositorioGenerico<T> where T : class {
    Task<List<T>> ObtenerTodosAsync();
    Task<T> ObtenerPorIdAsync(int id);
    Task AgregarAsync(T entidad);
    Task ActualizarAsync(T entidad);
    Task EliminarAsync(int id);
}

public class ProductoRepositorio : IRepositorioGenerico<Producto> {
    private readonly ContextoDb _contexto;
    
    public ProductoRepositorio(ContextoDb contexto) {
        _contexto = contexto;
    }
    
    public async Task<List<Producto>> ObtenerTodosAsync() {
        return await _contexto.Productos.ToListAsync();
    }
    
    public async Task<Producto> ObtenerPorIdAsync(int id) {
        return await _contexto.Productos.FindAsync(id);
    }
    
    public async Task AgregarAsync(Producto entidad) {
        await _contexto.Productos.AddAsync(entidad);
        await _contexto.SaveChangesAsync();
    }
    
    public async Task ActualizarAsync(Producto entidad) {
        _contexto.Entry(entidad).State = EntityState.Modified;
        await _contexto.SaveChangesAsync();
    }
    
    public async Task EliminarAsync(int id) {
        var entidad = await _contexto.Productos.FindAsync(id);
        _contexto.Productos.Remove(entidad);
        await _contexto.SaveChangesAsync();
    }
}
```

#### Interfaces Genéricas
Definir interfaces con parámetros de tipo genérico para operaciones CRUD (Crear, Leer, Actualizar, Borrar) comunes.

```csharp
public interface ICommonService<T, TI, TU> {
    Task<IEnumerable<T>> Get();
    Task<T> GetById(int id);
    Task<T> Add(TI insertDto);
    Task<T> Update(int id, TU updateDto);
    Task<T> Delete(int id);
}
```

# Implementación con Activator para instanciar entidades dinámicamente
public class CommonService<T, TI, TU> : ICommonService<T, TI, TU> where T : class {
    private readonly ContextoDb _contexto;
    
    public CommonService(ContextoDb contexto) {
        _contexto = contexto;
    }
    
    public async Task<IEnumerable<T>> Get() {
        return await _contexto.Set<T>().ToListAsync();
    }
    
    public async Task<T> GetById(int id) {
        return await _contexto.Set<T>().FindAsync(id);
    }
    
    public async Task<T> Add(TI insertDto) {
        var entidad = Activator.CreateInstance<T>();
        _contexto.Entry(entidad).State = EntityState.Added;
        await _contexto.SaveChangesAsync();
        return entidad;
    }
    
    public async Task<T> Update(int id, TU updateDto) {
        var entidad = await _contexto.Set<T>().FindAsync(id);
        if (entidad != null) {
            await _contexto.SaveChangesAsync();
        }
        return entidad;
    }
    
    public async Task<T> Delete(int id) {
        var entidad = await _contexto.Set<T>().FindAsync(id);
        if (entidad != null) {
            _contexto.Entry(entidad).State = EntityState.Deleted;
            await _contexto.SaveChangesAsync();
        }
        return entidad;
    }
}

#### Repositorio Pattern (Patrón Repositorio)
Acapular la lógica de acceso a datos y separarla de la lógica de negocio/servicio.

```csharp
public class BeerRepository : IRepository<Beer> {
    private readonly StoreContext _context;
    
    public BeerRepository(StoreContext context) { _context = context; }
    
    public async Task<IEnumerable<Beer>> Get() => await _context.Beers.ToListAsync();
    public async Task<Beer> GetById(int id) => await _context.Beers.FindAsync(id);
    public async Task Add(Beer entity) => await _context.Beers.AddAsync(entity);
    public void Update(Beer entity) { ... }
    public void Delete(Beer entity) => _context.Beers.Remove(entity);
    public async Task Save() => await _context.SaveChangesAsync();
}

public class BeerService {
    private readonly IRepository<Beer> _repo;
    
    public BeerService(IRepository<Beer> repo) { _repo = repo; }
    
    public async Task AddBeer(BeerInsertDto dto) {
        var beer = new Beer { ... };
        await _repo.Add(beer);
        await _repo.Save();
        // ... mapear a DTO y retornar
    }
}
```

**Para qué:** Separation of concerns (separación de responsabilidades), testabilidad sin necesidad de BD real, y facilidad para cambiar de proveedor de datos (EF, Dapper, MongoDB, etc.) sin afectar la capa de servicios.

#### AutoMapper (Profundización)
Configuración y uso avanzado para mapear entre objetos diferentes (generalmente de entidad a DTO y viceversa).

```csharp
// En Program.cs
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Perfil de mapeo
public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<BeerInsertDto, Beer>(); // Mismo nombre de propiedades basta
        CreateMap<Beer, BeerDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b.BeerId)); // Campo distinto
    }
}
```

**Uso en servicio:**
```csharp
// Antes (manual)
var beer = new Beer { Name = dto.Name, BrandId = dto.BrandId, ... };

// Después (con AutoMapper)
var beer = _mapper.Map<Beer>(dto);
```

**Para qué:** Reducir código repetitivo de mapeo manual, asegurar consistencia en transformaciones entre capas.

#### Modificaciones en Modelos EF
Cuando las clases C# cambian (se agregan/quitan propiedades), se deben crear nuevas migraciones y aplicar actualizaciones a la base de datos.

```bash
# 1. Crear nueva migración
dotnet ef migrations add NombreDelCambio

# 2. Aplicar el cambio a la base de datos
dotnet ef database update
```

**Para qué:** Evolucionar el esquema de la base de datos acorde a los cambios en las entidades del código, sin perder datos existentes.

---

## 04-Patrones de diseño en .NET

### Descripción
PATRÓN YA CONFIGURADO - No modificar. Este directorio ya contiene el README perfecto con documentación detallada de patrones de diseño. Consulte `04-Patrones de diseño en .NET/readme.md` para documentación completa.

### Estado
El README original en esta carpeta contiene documentación perfecta y completa de todos los patrones de diseño y **no ha sido modificado** respetando la instrucción del usuario. Este README central solo hace referencia a él.

### Patrones Documentados (Resumen)
1. **Singleton** - Patrón creacional: única instancia global
2. **Factory Method** - Patrón creacional: creación de objetos delegada a subclases
3. **Dependency Injection** - Patrón estructural: desacoplamiento de dependencias
4. **Repository Pattern** - Patrón estructural: abstraer acceso a datos
5. **Unit of Work Pattern** - Patrón estructural: agrupar transacciones múltiples
6. **Strategy Pattern** - Patrón comportamiento: algoritmos intercambiables
7. **Builder Pattern** - Patrón creacional: construcción de objetos complejos
8. **State Pattern** - Patrón comportamiento: comportamiento que cambia por estado

### Tabla Comparativa de Cuándo Usar Cada Patrón
| Patrón | Tipo | Caso de Uso Principal |
|--------|------|----------------------|
| **Singleton** | Creacional | Una instancia global necesaria (logs, configuraciones, conexiones). |
| **Factory Method** | Creacional | Creación de objetos cuando la subclase debe decidir la instancia. |
| **DI** | Estructural | Desacoplamiento de dependencias y testing facil. |
| **Repository** | Estructural | Abstraer acceso a datos/ORM y cambiar proveedores fácilmente. |
| **Unit of Work** | Estructural | Agrupar múltiples operaciones en una sola transacción. |
| **Strategy** | Comportamiento | Variantes de algoritmo que cambian en tiempo de ejecución. |
| **Builder** | Creacional | Objetos complejos con muchos parámetros o variaciones. |
| **State** | Comportamiento | Comportamiento que cambia según el estado interno del objeto. |

### Referencias
- Este repositorio forma parte del curso "Patrones de diseño en .NET"
- Para más detalles sobre cada patrón, consultar `curso.md` en el directorio raíz
- Documentación oficial Microsoft: [Design Patterns](https://docs.microsoft.com/dotnet/standard/design-patterns)

---

## 05-Curso de Full Stack C# .NET

### Descripción
Curso full stack con C#, enfocado en APIs minimal, Blazor frontend, SQL Server y arquitecturas modernas con separación de capas.

### Objetivo
Desarrollar aplicaciones full stack completas con C# .NET, desde APIs minimal hasta interfaces interactivas con Blazor, usando SQL Server como base de datos y aplicando patrones arquitectónicos modernos.

### Contenido del curso

#### Programación Estructurada y Variables
Conceptos básicos de programación: variables con tipos explícitos (`int`, `string`, `bool`, `double`, `decimal`, `char`) o implícitos (`var`). Arreglos como colecciones de tamaño fijo.

```csharp
int edad = 25;
string nombre = "Ana";
bool esMayor = true;
decimal precio = 199.95m; // decimal para dinero
char inicial = 'A';
```

#### Sentencias Condicionales
Estructuras `if-else` para toma de decisiones basada en valores de variables.

```csharp
if (edad >= 18) {
    // Lógica para mayores de edad
} else {
    // Lógica para menores de edad
}
```

#### Programación Orientada a Objetos (Parte 1)
Clases abstractas que no pueden instanciarse directamente y deben heredarse.

```csharp
abstract class Animal {
    public abstract void HacerSonido(); // Método que debe implementar la subclase
}

class Perro : Animal {
    public override void HacerSonido() { Console.WriteLine("Woof!"); }
}
```

**Para qué:** Definir una estructura base común y obligar a las subclases a implementar comportamiento específico.

#### Base de Datos - SQL Management Studio
Uso de SQL Server Management Studio (SSMS) para administración de bases de datos.

- **Crear base de datos:** Nueva base de datos dentro del servidor.
- **Crear tablas:** Definir estructuras con columnas y tipos de datos.
- **Tipos de datos SQL:**
  - `int`: Enteros.
  - `varchar(n)`: Texto de longitud variable (máx n caracteres).
  - `datetime`: Fecha y hora.
  - `nvarchar(n)`: Texto Unicode de longitud variable.
- **Comandos SQL básicos:**
  - `INSERT INTO ... VALUES`: Agregar registros nuevos.
  - `SELECT * FROM`: Recuperar datos.
  - `UPDATE ... SET ... WHERE`: Modificar registros existentes.
  - `DELETE FROM ... WHERE`: Borrar registros.
- **Llaves foráneas (Foreign Keys):** Restricción que establece relación entre tablas (pk en una tablaFK en otra). Integridad referencial.
- **JOINs (Unir tablas):**
  - `INNER JOIN`: Filas que tienen coincidencia en AMBAS tablas.
  - `LEFT JOIN`: Todas de la tabla izquierda + coincidencias de la derecha (NULL si no hay match).
  - `RIGHT JOIN`: Todas de la tabla derecha + coincidencias de la izquierda (NULL si no hay match).
  - `FULL OUTER JOIN`: Todas las filas de ambas tablas, con NULLs donde no hay coincidencia.

**Para qué:** Diseño y manipulación de la base de datos relacional, establecimiento de relaciones y consulta de datos combinados.

```csharp
# Ejemplo de consulta SQL en C# usando ADO.NET
using System.Data;
using System.Data.SqlClient;

# Configuración de conexión
string connectionString = "Server=localhost;Database=Northwind;Trusted_Connection=True;";

# Consultar todos los productos
using (SqlConnection connection = new SqlConnection(connectionString)) {
    connection.Open();
    
    # Crear comando SQL
    using (SqlCommand command = new SqlCommand("SELECT ProductID, ProductName, UnitPrice FROM Products", connection)) {
        # Ejecutar y leer resultados
        using (SqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                decimal precio = reader.GetDecimal(2);
                
                Console.WriteLine($"ID: {id}, Nombre: {nombre}, Precio: {precio}");
            }
        }
    }
}

# Insertar un nuevo producto
using (SqlConnection connection = new SqlConnection(connectionString)) {
    connection.Open();
    using (SqlCommand command = new SqlCommand("INSERT INTO Products (ProductName, UnitPrice) VALUES (@name, @price)", connection)) {
        command.Parameters.AddWithValue("@name", "Producto de Prueba");
        command.Parameters.AddWithValue("@price", 99.99m);
        
        int rowsAffected = command.ExecuteNonQuery();
        Console.WriteLine($"Filas afectadas: {rowsAffected}");
    }
}
```

**Para qué:** Diseño y manipulación de la base de datos relacional, establecimiento de relaciones y consulta de datos combinados. También muestra cómo conectar C# con SQL Server directamente.

#### Arquitectura de Software y Componentes
Definición de componentes como unidades reutilizables de funcionalidad. Concepto de "Dominio": el problema de negocio que el software resuelve, enfocándose en conceptos y reglas del negocio rather than in tecnologías.

```csharp
# Ejemplo de componente reusable en ASP.NET Core

# Interfaz del componente
public interface IProductoComponent {
    Task<IEnumerable<ProductoDto>> ObtenerProductosAsync();
    Task<ProductoDto> ObtenerProductoPorIdAsync(int id);
}

# Implementación del componente
public class ProductoComponent : IProductoComponent {
    private readonly IProductoRepositorio _repositorio;
    private readonly IMapper _mapper;
    
    public ProductoComponent(IProductoRepositorio repositorio, IMapper mapper) {
        _repositorio = repositorio;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductoDto>> ObtenerProductosAsync() {
        var entidades = await _repositorio.ObtenerTodosAsync();
        return _mapper.Map<List<ProductoDto>>(entidades);
    }
    
    public async Task<ProductoDto> ObtenerProductoPorIdAsync(int id) {
        var entidad = await _repositorio.ObtenerPorIdAsync(id);
        if (entidad == null) return null;
        return _mapper.Map<ProductoDto>(entidad);
    }
}

# Uso en un controlador
[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase {
    private readonly IProductoComponent _componente;
    
    public ProductosController(IProductoComponent componente) {
        _componente = componente;
    }
    
    [HttpGet]
    public async Task<IActionResult> Obtener() {
        var productos = await _componente.ObtenerProductosAsync();
        return Ok(productos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id) {
        var producto = await _componente.ObtenerProductoPorIdAsync(id);
        if (producto == null) return NotFound();
        return Ok(producto);
    }
}
```

**Para qué:** Enfocarse en resolver el problema del negocio de manera clara, independientemente de la implementación técnica. Los componentes encapsulan lógica específica y pueden ser reutilizados en diferentes partes de la aplicación.

#### Entity Framework - Scaffolding
Generación automática de clases que mapean a una base de datos existente.

```bash
# 1. Instalar herramienta
dotnet tool install --global dotnet-ef

# 2. Generar clases desde la BD
dotnet ef dbcontext scaffold "Server=MI_SERVIDOR;Database=Mi_BD;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer
```

**Para qué:** Ahorrar tiempo al no tener que crear manualmente todas las clases que representan tablas y relaciones de una base de datos existente.

#### Creación de Backend con Minimal API
Enfoque moderno y simplificado para crear APIs en .NET 8+ sin necesidad de controllers tradicionales y atributos extensos.

**Configuración:**
```csharp
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreFsContext>(options => {
    options.UseSqlServer(connection);
});
builder.Services.AddTransient<IRepository<BrandEntity>, BrandRepository>();
builder.Services.AddTransient<IUseCase<BrandEntity>, BrandUseCase>();
```

**Creación de endpoints (minimal API):**
```csharp
// GET: Obtener todas las marcas
app.MapGet("brand", async (IUseCase<BrandEntity> useCase) => {
    return await useCase.GetAllAsync();
}).WithName("getBrand");

// POST: Agregar nueva marca
app.MapPost("brand", async (IUseCase<BrandEntity> useCase, BrandEntity brand) => {
    await useCase.AddAsync(brand);
    return Results.Created();
});

// PUT: Actualizar marca
app.MapPut("brand/{id}", async (int id, JsonDocument body, IUseCase<BrandEntity> useCase) => {
    var name = body.RootElement.GetProperty("name").GetString();
    var entity = new BrandEntity(id, name);
    await useCase.UpdateAsync(entity);
    return Results.NoContent();
});

// DELETE: Eliminar marca
app.MapDelete("brand/{id}", async (int id, IUseCase<BrandEntity> useCase) => {
    await useCase.DeleteAsync(id);
    return Results.NoContent();
});
```

**Por qué Minimal API:**
- Sintaxis fluida y legible (casi como inglés).
- Menos "boilerplate" (código repetitivo) comparado con APIs tradicionales con controllers.
- Mejor performance por menor overhead.
- Recomendado para nuevas APIs en .NET 8+.

#### Documentación API con Swagger/OpenAPI
Sistema para generar documentación interactiva de la API automáticamente.

```csharp
// Configuración
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Activar en pipeline (desarrollo)
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

**URL de prueba:** `https://localhost:7280/swagger/index.html**

**Para qué:** Que los desarrolladores consumidores de la API puedan ver endpoints, parámetros y probarlos directamente en el navegador, además de generar clientes en otros lenguajes.

#### Introducción a Blazor
Framework que permite construir interfaces web usando C# en lugar de JavaScript. Renderiza en el navegador a través de WebAssembly o señalR.

**Modelos de hospedaje:**
- **Blazor Server:** La lógica se ejecuta en el servidor y las actualizaciones se envían al navegador mediante SignalR. Más fácil depurar y más seguro (código no se envía al cliente).
- **Blazor WebAssembly:** La aplicación se descarga y ejecuta completamente en el navegador. Puede funcionar offline (PWA). Separación completa del backend.
- **Blazor Hybrid:** Combinación con MAUI para aplicaciones móviles.

**Ventajas:**
- Reutilizar código C# en el frontend.
- Tipado fuerte (errores en compilación, no en tiempo de ejecución).
- Un solo stack (todo el equipo usa C#).
- Puede trabajar offline (PWA para WebAssembly).

#### Componentes Razor (.razor files)
Archivos que combinan marcado HTML con código C#. Son los bloques constructores de las interfaces en Blazor.

```razor
@page "/mi-componente" // Define la ruta donde se usará este componente

<h3>Mi Componente</h3>
<p>Hola @nombre</p>

@code {
    private string nombre = "Juan";
}
```

**Data binding:** Mechanismo para que cambios en controles HTML reflejen automáticamente variables C# y viceversa.

```razor
<input type="text" @bind="nombre" />
<p>El valor es: @nombre</p>
```

**Eventos:** Manejadores de acciones del usuario.

```razor
<button @onclick="Incrementar">Sumar 1</button>

@code {
    private int contador = 0;
    
    private void Incrementar() {
        contador++;
    }
}
```

**Parameters (Parámetros):** Para recibir datos de padres o al componer componentes.

```razor
<!-- Usando el componente -->
<MiComponente Nombre="Maria" />

@code {
    [Parameter] public string Nombre { get; set; } = string.Empty;
    [Parameter] public string Info { get; set; } = string.Empty;
}
```

**Ciclos de vida de componentes:** Momentos clave en la existencia de un componente Blazor.

```razor
@code {
    protected override async Task OnInitializedAsync() {
        // Se ejecuta una vez cuando el componente se crea por primera vez
        datos = await Http.GetStringAsync("datos.json");
    }
    
    protected override async Task OnParametersSetAsync() {
        // Se ejecuta cada vez que cambian los parámetros recibidos
        Console.WriteLine($"Parámetro: {Info}");
    }
    
    protected override async Task OnAfterRenderAsync(bool firstRender) {
        // Se ejecuta después de que el HTML se haya renderizado en pantalla
        if (firstRender) {
            // Lógica solo para la primera vez
        }
    }
    
    public void Dispose() {
        // Se ejecuta cuando el componente es removido de la pantalla
        // Limpiar suscripciones, timer, etc.
    }
}
```

**Inyección de dependencia en Blazor:** Inyectar servicios o HttpClient en componentes.

```razor
@inject HttpClient Http

@code {
    protected override async Task OnInitializedAsync() {
        var respuesta = await Http.GetStringAsync("api/endpoint");
        // Procesar respuesta...
    }
}
```

**CORS (Cross-Origin Resource Sharing):** Mecanismo de navegadores que controla qué aplicaciones web pueden acceder a los recursos de otra URL. Esencial cuando el frontend (ej. `localhost:5000`) y backend (ej. `localhost:7280`) corren en puertos diferentes.

```csharp
const string politicaCors = " politicaCors";
builder.Services.AddCors(options => {
    options.AddPolicy(nombrePolitica, politica => {
        politica
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// ¡Importante! Aplicar antes de los endpoints
app.UseCors(politicaCors);
```

**Para qué:** Permitir comunicación entre frontend y backend en diferentes orígenes (dominios/pueros) durante el desarrollo. En producción se configuran políticas más restrictivas.

#### DTOs y Mappers
Objetos que transferen datos entre capas, evitando exponer entidades completas de la base de datos al frontend.

```csharp
public class ProductoDto {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public bool Disponible { get; set; }
}
```

**AutoMapper:** Herramienta para automatizar el mapeo entre objetos de dominio (entidades) y DTOs.

```csharp
// Configuración en Program.cs
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Perfil de mapeo
public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<Producto, ProductoDto>();
        // O con mapeo manual de campos que tienen nombres diferentes:
        CreateMap<InsertarProductoDto, Producto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdGenerado));
    }
}
```

**Uso:** `var dto = _mapper.Map<ProductoDto>(entidad);`

**Para qué:** Que el frontend solo reciba los datos necesarios, ocultar propiedades sensibles de la BD y desacoplar capas.

#### Validaciones en Frontend (FluentValidation)
Biblioteca para validaciones declarativas en formularios frontend (Blazor).

```csharp
public class ProductoDtoValidator : AbstractValidator<ProductoDto> {
    public ProductoDtoValidator() {
        RuleFor(x => x.Nombre)
            .NotEmpty().Con mensaje("El nombre es obligatorio")
            .MaximumLength(100).Con mensaje("Máximo 100 caracteres");
        
        RuleFor(x => x.Precio)
            .GreaterThan(0).Con mensaje("El precio debe ser mayor a 0");
        
        // Validación condicional
        RuleFor((producto, precio) => precio > producto.Costo)
            .Con mensaje("El precio debe ser mayor al costo");
    }
}
```

**Uso en formulario Blazor:**
```razor
<EditForm Modelo="productoDto" OnValidSubmit="Guardar">
    <FluentValidationValidator /> <!-- Validador automático -->
    <ValidationSummary /> <!-- Resumen de todos los errores -->
    
    <div class="mb-3">
        <label>Nombre</label>
        <InputTexto @bind-Value="productoDto.Nombre" />
        <ValidationMessage For="() => productoDto.Nombre" />
    </div>
    
    <!-- Igual para otros campos -->
    
    <button type="submit">Guardar</button>
</EditForm>
```

**Para qué:** Validaciones consistentes entre frontend y backend, mensajes amigables y reutilización de reglas de validación.

#### Módulo Maestro-Detalle
Estructura de datos donde una entidad "padre" (maestro) tiene una o más entidades "hija" (detalle) relacionadas.

**Ejemplo:** Una **Venta** (maestro) puede tener muchos **DetalleVenta** (hija), cada uno con un producto y cantidad.

```text
Venta (maestro)
│
├─ DetalleVenta 1: Producto A, Cantidad 2
├─ DetalleVenta 2: Producto B, Cantidad 1
└─ DetalleVenta 3: Producto C, Cantidad 3
```

**Para qué:** Modelar transacciones como pedidos, facturas, carritos de compra, donde una entidad principal tiene múltiples elementos asociados.

```csharp
# Ejemplo de modelo Maestro-Detalle con Entity Framework

# Entidades del modelo
public class Venta {
    [Key]
    public int VentaId { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    
    # Navegación a las detalles
    public virtual ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
}

public class DetalleVenta {
    [Key]
    public int DetalleVentaId { get; set; }
    
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    
    # Navegaciones
    [ForeignKey("VentaId")]
    public virtual Venta Venta { get; set; }
    
    [ForeignKey("ProductoId")]
    public virtual Producto Producto { get; set; }
}

# Configuración en DbContext
public class TiendaContext : DbContext {
    public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }
    
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<DetalleVenta> DetalleVentas { get; set; }
    public DbSet<Producto> Productos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<DetalleVenta>()
            .HasOne(d => d.Venta)
            .WithMany(v => v.Detalles)
            .HasForeignKey(d => d.VentaId);
    }
}

# Ejemplo de uso en controlador
public class VentasController : ControllerBase {
    private readonly TiendaContext _context;
    
    public VentasController(TiendaContext context) {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> CrearVenta(CrearVentaDto dto) {
        # Crear la venta maestro
        var venta = new Venta {
            Fecha = DateTime.UtcNow,
            Total = 0
        };
        
        _context.Ventas.Add(venta);
        await _context.SaveChangesAsync();
        
        # Crear los detalles (hijas)
        foreach (var item in dto.Detalles) {
            var detalle = new DetalleVenta {
                VentaId = venta.VentaId,
                ProductoId = item.ProductoId,
                Cantidad = item.Cantidad,
                PrecioUnitario = item.PrecioUnitario
            };
            
            _context.DetalleVentas.Add(detalle);
            
            # Actualizar total de la venta
            venta.Total += item.Cantidad * item.PrecioUnitario;
        }
        
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(Obtener), new { id = venta.VentaId }, venta);
    }
}

# DTO para creación de venta
public class CrearVentaDto {
    public List<DetalleVentaDto> Detalles { get; set; }
}

public class DetalleVentaDto {
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}
```

**Para qué:** Modelar transacciones como pedidos, facturas, carritos de compra, donde una entidad principal tiene múltiples elementos asociados. Este patrón es esencial para sistemas de e-commerce, sistemas de facturación y cualquier aplicación que maneje transacciones complejas.

---
```

## Ejercicios Prueba

### Descripción
Ejercicios de prueba técnica para evaluar los conocimientos adquiridos en los cursos. Práctica de problemas reales aplicando los conceptos de los cursos anteriores.

### Objetivo
Demostrar capacidad de aplicar lo aprendido en escenarios reales; prepararse para entrevistas técnicas y desarrollo profesional.

### Contenido
- Ejercicios de práctica técnica individual.
- Aplicación de conceptos C#, .NET, creación de APIs, uso de patrones, trabajo con bases de datos.
- Evaluación de conocimiento práctico.

---

## Nota Importante

- El README de `04-Patrones de diseño en .NET` contiene información perfecta y **no ha sido modificado** respetando la instrucción del usuario.
- Los READMEs individuales en cada carpeta mantienen su contenido original; este archivo raíz sirve como **guía de estudio centralizada y detallada** que cubre desde lo básico hasta buenas prácticas avanzadas en cada curso.
- Esta guía está diseñada para ser consultada al estudiar cada curso; provee contexto, objetivos y explicaciones de cada tema.
- La sección "Fundamentos Compartidos" consolidó temas que aparecen en múltiples cursos para evitar repetición y ofrecer una referencia rápida.
- Cada sección de curso contiene contenido relevante y semánticamente ordenado desde lo básico hasta lo avanzado, sin duplicar conceptosalready presentes en la sección centralizada.