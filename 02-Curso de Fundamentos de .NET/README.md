# Fundamentos de .NET

## Solucion vs Proyecto

Una solucion es un Proyecto que engloba un conjunto de Proyectos

## Capa Domain

### Entidad
```c#
    public class PersonEntity
    {
        public Guid Id { get; private set; }

        public string Code { get; private set; } = string.Empty;

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set;} = string.Empty;

        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;

        public PersonEntity(string code, string firstName, string lastName, string email, string phone)
        {
            Id = Guid.NewGuid();
            Code = code.Trim().ToUpper();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email.Trim().ToLower();
            Phone = phone.Trim();
        }


    }
```

### Reglas de dominio

```C#
        public PersonEntity(string code, string firstName, string lastName, string email, string phone)
        {
            ValidateCode(code);
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
            ValidateEmail(email);
            ValidatePhone(phone);

            Id = Guid.NewGuid();
            Code = code.Trim().ToUpper();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email.Trim().ToLower();
            Phone = phone.Trim();
        }

        private void ValidateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Code cannot be null or empty.");
            }
            if (code.Trim().Length < 3)
            {
                throw new ArgumentException("Code must be at least 3 characters long.");
            }
            if (code.Trim().Length > 10)
            {
                throw new ArgumentException("Code cannot be longer than 10 characters.");
            }
        }

        private void ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or empty.");
            }
            if (firstName.Trim().Length < 2)
            {
                throw new ArgumentException("First name must be at least 2 characters long.");
            }
        }

        private void ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null or empty.");
            }
            if (lastName.Trim().Length < 2)
            {
                throw new ArgumentException("Last name must be at least 2 characters long.");
            }
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.");
            }

            if (email.Length > 100)
            {
                throw new ArgumentException("Email cannot be longer than 100 characters.");
            }

            var EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, EmailPattern))
            {
                throw new ArgumentException("Email is not in a valid format.");
            }
        }

        private void ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Phone cannot be null or empty.");
            }
            if (phone.Length > 15)
            {
                throw new ArgumentException("Phone cannot be longer than 15 characters.");
            }
            var PhonePattern = @"^\+?[0-9\s\-()]+$";
            if (!Regex.IsMatch(phone, PhonePattern))
            {
                throw new ArgumentException("Phone is not in a valid format.");
            }
        }
```

### Metodos de utilidad en Entities

Editar Elementos privados
```C#
        public void UpdatePersonalInfo(string firstName, string lastName, string email, string phone)
        {
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
            ValidateEmail(email);
            ValidatePhone(phone);
            this.FirstName = firstName.Trim();
            this.LastName = lastName.Trim();
            this.Email = email.Trim().ToLower();
            this.Phone = phone.Trim();
        }
```

Metodo para obtener fullname
```C#
        public string FullName => $"{FirstName} {LastName}";
```

### Abstracciones

```C#
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }

```

Abstracciones Especificas

```C#
    public interface ICodeRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetCodeAsync(string code);
        Task<bool> ExistsWithCodeAsync(string code);
    }
```

## Capa Aplicacion

Sirve para orquestar la logica, sirve como un intermediario entre las herramientas la infraestructura y la logica de negocio, puede conocerse como un orquestador, en esta capa estaran los casos de uso

### Creacion de Proyecto

Se crea una biblioteca de clase llamada Application > En dependencias Agregas referencias de Proyecto:Domain

### Casos de Usos

Application / UseCases / Persons / CasosDeUso.cs

```C#
    public class GetAllPersonsUseCase
    {
        private readonly IRepository<PersonEntity, Guid> _repository;

        public GetAllPersonsUseCase(IRepository<PersonEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PersonEntity>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
```

```C#
    public class GetPersonByIdUseCase
    {
        private readonly IRepository<PersonEntity, Guid> _repository;

        public GetPersonByIdUseCase(IRepository<PersonEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<PersonEntity> ExecuteAsync(Guid id)
        {
            var person = await _repository.GetByIdAsync(id);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with ID {id} not found.");
            }
            return person;
        }

    }
```

## Capa Data

### Entity Framework ORM

ORM es un mapeador relacional de objetos, es decir podemos trabajar la base de datos como si trabajaramos con objetos, Entity Framework es el ORM por defecto de .NET, el cual se apoya de una extension de lenguaje C# llamado LINQ

### Instalacion de Entity Framework

Dependencias > Administrador Paquetes Nuggets > Instalar Paquetes

Paquetes necesarios:

* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.SqlServer : Contiene lo necesario para trabajar con SqlServer
* Microsoft.EntityFrameworkCore.Design : Sirve para hacer ciertas cosas con el codigo como las migraciones

### Contexto de Entity Framework

Es una clase que sirve para tener la coordinacion de todas las operaciones y le indica a entity framework la estructura de la base de datos

```C#
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PersonEntity> Persons { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonEntity>(entity =>
            {
                entity.ToTable("Persons");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();

                entity.Property(e => e.Code).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.Code).IsUnique();

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);

                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);

                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);

                entity.Property(e => e.Phone).IsRequired().HasMaxLength(15);

                entity.Ignore(e => e.FullName);

                entity.Property<DateTime>("CreateAt").IsRequired().HasDefaultValueSql("GETUTCDATE()");
                entity.Property<DateTime>("UpdateAt").IsRequired().HasDefaultValueSql("GETUTCDATE()");
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // extras
            return base.SaveChangesAsync(cancellationToken);
        }
    }
```

#### Reglas antes de guardar en base de datos

```C#
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // extras
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                if (entry.Metadata.FindProperty("UpdatedAt") != null)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }
            }
        }
```

### Repository


```C#
    public class PersonRepository : IRepository<PersonEntity, Guid>
    {

        private readonly ApplicationDbContext _context;
        
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PersonEntity entity)
        {
            if (entity == null) 
            { 
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.Persons.AddAsync(entity);
        }

        public Task DeleteAsync(PersonEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Persons.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<PersonEntity>> GetAllAsync()
        {
            return await _context.Persons
                .AsNoTracking()
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToListAsync();
        }

        public async Task<PersonEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(PersonEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Persons.Update(entity);
            return Task.CompletedTask;
        }
    }
```

ICodeRepository

```C#
        public async Task<bool> ExistsWithCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));

            var normalizedCode = code.ToUpperInvariant();

            return await _context.Persons.AnyAsync(p => p.Code == normalizedCode);
        }

        public async Task<PersonEntity?> GetCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));

            var normalizedCode = code.ToUpperInvariant();

            return await _context.Persons.FirstOrDefaultAsync(p => p.Code == normalizedCode);

        }
```

## Componente Backend

Solucion > Agregar nuevo Proyecto > ASP.NET Core Web API

### Inyeccion de Dependencias 

```C#
builder.Services.AddOpenApi();

builder.Services.AddScoped<IRepository<PersonEntity, Guid>, PersonRepository>();

builder.Services.AddScoped<CreatePersonUseCase>();
builder.Services.AddScoped<GetAllPersonsUseCase>();
builder.Services.AddScoped<DeletePersonUseCase>();
builder.Services.AddScoped<GetPersonByIdUseCase>();
builder.Services.AddScoped<UpdatePersonUseCase>();

```

### Metodos de Extension

```C#
string name = "juan";

Console.WriteLine(name.Hi());
static class StringExtensions 
{
    public static string Hi(this string str)
    {
        return "Hola " + str;
    }
}
```

### Inyeccion de Dependencias por Componente

Administrar Paquetes Nuggets > Microsoft.Extensions.DependencyInjection.Abstractions

Inyeccion de dependencia centralizada en una clase, ubicada en la `Capa Application`

```C#
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddScoped<IRepository<PersonEntity, Guid>, PersonRepository>();
            services.AddScoped<ICodeRepository<PersonEntity>, PersonRepository>();

            return services;

        }
    }
```

### Cadena de Conexion

```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=RegisterDB;Trusted_Connection=True;MultipleActiveResultSets=True"
  },
```

```C#
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Falta la conexion a la base de datos");
```

### Inyeccion de Dependencia Entity

En dependency injection
```C#
        public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepository<PersonEntity, Guid>, PersonRepository>();
            services.AddScoped<ICodeRepository<PersonEntity>, PersonRepository>();

            return services;

        }
```

En program.cs
```C#
builder.Services.AddData(connectionString);
```

### Migracion a la base de datos

Instalar paquete Nugget > Microsoft.EntityFrameworkCore.Design

#### instalar en la terminal

```powershell
dotnet tool install --global dotnet-ef
```

#### Ejecutar migracion

```powershell
dotnet ef migrations add InitialCreate --project [Proyecto donde se encuentra entity framework] --startup-project [proyecto api]
```

>Si da error prueba compilar la aplicacion del proyecto de la API

#### Creacion de la base de dato en bas ea la migracion

```powershell
dotnet ef database update --project [Proyecto donde se encuentra entity framework] --startup-project [proyecto api]
```

