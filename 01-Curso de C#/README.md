# Curso C#

## Estructura VSCode

* Solucion: Es un grupo donde puedes tener varios proyectos
* Proyectos: Estan dentro de la soluciones

## Imprimir en Consola

Para imprimir en consola

## Tipos de Datos

* int: Numeros enteros que no poseen decimales (1, 2, 3)
* double: Permite guardar numeros decimales (12.21)
* char: permite guardar *1 caracter*, para guardar se utiliza `''` comillas simples
* string: permite guardar cadenas de texto, se utiliza `""` comillas dobles
* bool: Permite guardar booleanos, caracteres verdaderos o falsos

## Interpolacion de Strings

Se utiliza `$` antes del string y la variable se usa como `{variable}`

```C#
    $"Esta clase se ha utilizado {variable} veces"
```

## Funciones

Procesos de codigo que quieras encapsular

* Funcion que no recibe nada y no regresa nada
```C#
int a = 1;
int b = 2;

static void Show()
{
    Console.WriteLine("Hola, soy un texto que se imprime desde function")
}
```
* Funcion que recibe datos y no regresa nada
```C#
static void Sum(int a, int b)
{
    int c = a + b;
    Console.WriteLine(c);
}
```
* Funcion que recibe datos y regresa algo

```C#
static int Mul(int a, int b)
{
    int c = a * b;
    return c;
}
```

## Logica Booleana 

* AND: `&&` ambas condiciones tienen que cumplirse
* OR: `||` una condicion necesita cumplirse
* EQUAL: `==` QUe sean exactamente iguales
* MAYOR: `>` 
* MAYOR O IGUAL: `>=`
* MENOR O IGUAL: `<=`

## Sentencias

### Sentencia if

Sirve para agregar condicionales

```C#
static void Main(string[] args)
{
    bool areYouHungry = true;
    bool youHaveMoney = false;
    if (areYouHungry && youHaveMoney && IsOpenRestaurant("Lonches pepe", 11))
    {
        Console.WriteLine("Come");
    }
    else
    {
        Console.WriteLine("No comes");
    }
}


static bool IsOpenRestaurant(string name, int hour = 0)
{
    if(name == "Lonches pepe" && hour > 5)
    {
        return true;
    }
    else if(name == "Restaurant 24 horas")
    {
        return true;
    }
    else
    {
        return false;
    }
}
```

### Sentencia Switch

Evalúa una variable y ejecuta un bloque de código según el valor coincidente. 

```C#
int op = 1;
switch (op)
{
    case 1:
        Console.WriteLine("Seleccionaste el 1");
        break;
    case 2:
        Console.WriteLine("Seleccionaste el 2");
        break;
    case 3:
    case 4:
        Console.WriteLine("Opcion 3 o 4 anidada");
        break;
    case > 4 and < 6:
        Console.WriteLine("Opcion entre 4 y 6")
    default:
        Console.WriteLine("Invalido");
        break;
}
```

> No se usan los operadores `&&` o `||` en su lugar se usa `and` y `or`



### Sentencia While

Sirve para hacer un bucle hasta que se cumpla la condicion

```C#
int i = 0;
while (i < 10)
{
    Console.WriteLine("Iteracion de i " + i);
    //i = i + 1;
    i++;
}
int j = 0;
while (j < 100)
{
    if (j > 10)
        break; // Romper el bucle
    Console.WriteLine("Iteracion de i " + j);
}
           
```

### Do While 

Igual que `While` pero primero hace la accion y luego revisa la condicion

```C#
bool run = false;
do
{
    Console.WriteLine("entro una vez y ya");
}
while (run);
```

### Sentencia For

El bucle for va a tener 3 espacios 
* Primer espacio: Definir los elementos que van a estar en el inicio antes de empezar las iteraciones
* Segundo espacio: Comparativa, que es lo que va a detener la tarea del ciclo
* Tercer espacio: Entre cada iteracion que es lo que se quiere cambiar

```C#
string[] friends = new string[7]
{
    "Juan",
    "paco",
    "Ana",
    "Ruben",
    "Karla",
    "Luis",
    null
};
for (int i = 0; i < friends.Length; i++)
{
    Console.WriteLine(friends[i]);
}
```

### Sentencia ForEach 

```C#
List<int> numbers2 = new List<int>()
{
    1,2,3,6
};
foreach (var number in numbers2)
{
    Console.WriteLine("for each " + number);
}
```

tambine se pueden recorrer objetos

```C#
List<People> students = new List<People>()
{
    new People() { Name = "Hector", Country = "Pais"},
    new People() { Name = "Ra", Country = "Pais"},
    new People() { Name = "RE", Country = "Pais"}
};
static void Show(List<People> students)
{
    Console.WriteLine("--Personas--");
    foreach (var people in students)
    {
        Console.WriteLine($"Nombre: {people.Name}, Pais: {people.Country}");
    }
}
```

> se puede colocar `var = new List<People>()` y var automaticamente inferira el tipo, solo dentro de metodos 

## Arreglos

Es una variable que puede guardar muchos elementos

```C#
string[] friends = new string[7]
{
    "Juan",
    "paco",
    "Ana",
    "Ruben",
    "Karla",
    "Luis", 
    null
};
friends[6] = "Samuel";
Console.WriteLine(friends[0]);
Console.WriteLine(friends[5]);
```


## Programacion Orientada a Objetos

Un objeto es una representacion de una entidad que tiene propiedades y tiene funcionalidades

Dentro de una clase las propiedades pueden 
* `public`: se puede acceder fuera de la clase
* `private`: se puede acceder solo dentro de la clase
* `protected`: se puede acceder solo dentro de la clase y las clases hijas

> Para acceder a los valores fuera de la clase necesitas que sea public

```C#

    internal class Program
    {
        static void Main(string[] args)
        {
            Sale sale1 = new Sale(100, DateTime.Now);
            sale1.GetInfo();
        }
    }

class Sale
{
    int total;
    DateTime date;
    public Sale(int total, DateTime date)
    {
        this.total = total;
        this.date = date;
    }
    public string GetInfo()
    {
        return total + " " + date.ToLongDateString();
    }
    public void Show() 
    {
        Console.WriteLine("Soy una venta");
    }
}
```

* El Constructor se instancia con el mismo nombre de la clase, en este caso la clase se llama `Sale` y el constructor igualmente sera `Sale(){}`


### Propiedades

Una propiedad nos ayuda a acceder a los valores o atributos de un objeto, se inicializan dentro de una clase. por lo general con el nombre de el atributo al que quieres acceder con mayuscula y seguida de un `get` o un `set`

```C#
public int Total
{
    get
    {
        return total;
    }
        set
    {
        if (value < 0) value = 0;
        total = value;
    }
}
```

> solo puedes cambiar el valor si estableces el set, usando solo get, es para obtener datos


### Herencia

Heredar caracteristicas de otra clase te ayuda a no tener que reescribir codigo

* Para heredar una clase se utilizan los dos puntos `class Doctor : People`
* En el constructor `public Doctor(string name, int age, string speciality) : base(name, age)`

```C#
class People
{
    private string _name;
    private int _age;
    public People(string name, int age)
    {
        _name = name;
        _age = age;
    }
    public string GetInfo()
    {
        return _name + ": " + _age;
    }
}
class Doctor : People
{
    private string _speciality;
    public Doctor(string name, int age, string speciality) : base(name, age)
    {
        _speciality = speciality;
    }
    public string GetData()
    {
        return GetInfo() + ", especialidad: " + _speciality;
    }
}
class Dev : People
{
    private string _language;
    public Dev(string name, int age, string language) : base(name, age)
    {
        _language = language ;
    }
    public string GetData()
    {
        return GetInfo() + ", especialidad: " + _language;
    }
}
```

### Sobrecarga de metodos

Es la capacidad que tienen las clases para tener la posibilidad de tener metodos con el mismo nombre, invocados con diferentes parametros 

```C#
public int Sum(int a, int b)
{
    return a + b;
}
public int Sum(string a, string b)
{
    return int.Parse(a) + int.Parse(b);
}
public int Sum(int[] numbers)
{
    int result = 0;
    int i = 0;
    while (i < numbers.Length)
    {
        result += numbers[i]; 
        i++;
    }
    return result;
}
```

### Sobreescritura de Metodos

Te permite soberescribir funcionalidades de una clase padre en una clase hijo

* el metodo a sobreescribir necesita tener `virtual` ex: `public virtual decimal GetTotal()`
* Para sobreescribirlo en la clase hija se coloca `override` ex: `public override decimal GetTotal()`
* El `base.GetTotal()` hace referencia al metodo padre 

```C#
internal class Program
{
    static void Main(string[] args)
    {
        B b = new B();
        SaleWithTax saleWithTax = new SaleWithTax(10, 1.16m);
        saleWithTax.Add(4);
        saleWithTax.Add(5);
        Console.WriteLine(saleWithTax.GetTotal());
    }
}
public class Sale
{
    private decimal[] _amounts;
    private int _n;
    private int _end;
    public Sale(int n) 
    {
        _amounts = new decimal[n];
        _n = n;
        _end = 0;
    }
    public void Add(decimal amount)
    {
        if (_end < _n)
        {
            _amounts[_end] = amount;
            _end++;
        }
    }
    public virtual decimal GetTotal()
    {
        decimal result = 0;
        int i = 0;
        while (i < _amounts.Length)
        {
            result += _amounts[i];
            i++;
        }
        return result;
    }
}
public class SaleWithTax : Sale
{
    private decimal _tax;
    public SaleWithTax(int n, decimal tax) : base(n) 
    {
        _tax = tax;
    }
    public override decimal GetTotal()
    {
        return base.GetTotal() * _tax;
    }
}
```
> Para establecer decimales en C# necesitas colocar la `m` al final del numero, ejemplo: `1.16m` asi es un numero decimal

### Static

Cuando se usa puedes acceder a los metodos y atributos sin la necesidad de instanciar una nueva clase, es una propiedad perteneciente a la clase y unica a la clase

```C#
static void Main(string[] args)
{
    People people1 = new People() // Instancias la clase, pero no puedes usar Count
    {
        Name = "Samuel",
        Age = 34,
    };
    Console.WriteLine(People.Count); // Usas count directamente desde la clase
}
public class People
{
    public static int Count = 0;
    public string Name { get; set; }
    public int Age { get; set; }
}
```

Tambien se puede usar static en las clases, cuando se usa static en una clase, todos los metodos y propiedades tienen que ser staticos

### Formato JSON

Para serializar un objeto en formato JSON se utiliza el `using System.Text.Json;` en la parte superior, similar al import de js

```C#
static void Main(string[] args)
{
    Beer myBeer = new Beer()
    {
        Name = "Pikantus",
        Brand = "Erdinger"
    };
    string json = JsonSerializer.Serialize(myBeer); // Serializar
    Beer beer = JsonSerializer.Deserialize<Beer>(json); // Deserializar
}
public class Beer
{
    public string Name { get; set; }
    public string Brand { get; set; }
}
```
## Listas

```C#
static void Main(string[] args)
{
    List<int> numbers = new List<int>();
    numbers.Add(5);
    numbers.Add(2);
    Console.WriteLine(numbers.Count);
    List<int> numbers2 = new List<int>()
    {
        1,2,3,6
    };
    Console.WriteLine(numbers2);
    numbers2.Clear();
    Console.WriteLine(numbers2.Count);
    List<string> countries = new List<string>()
    {
        "mexico", "argentina", "venezuela"
    };
}
```

### Metodos comunes de Listas 

* insert: `number.Insert(0, element);` inserta un elemento (6) en la posicion especificada en el primer parametro
* Contains: `number.Contains(element);` verifica si el elemento existe en la lista, devuelve un booleano
* IndexOf: `number.IndexOf(element);` Te devuelve la posicion del elemento, si el elemento no existe te devuelve un -1
* Sort: `number.Sort()` ordena la lista con valores por defecto
* AddRange: Añade una lista a otra lista
    ```C#
    number.AddRange(new List<int>()
    {
        200, 500, 400
    });
    ```

> Inmutabilidad, cuando un objeto es inmutable no lo puedes cambiar, necesitas redeclararlo

## Tipos de Datos Anonimos

Te permite crear objetos sin necesidad de tener una clase, como es un objeto anonimo tiene la caracteristica de que es `readonly`

```C#
var samuel = new
{
    Name = "Samuel",
    Country = "Venezuela"
};
Console.WriteLine($"{samuel.Name} {samuel.Country}");
```

## Tuplas

Lista de variables que se pueden guardar en un dato, si son editables

```C#
(int id, string name) product = (1, "Cerveza stout");
Console.WriteLine($"{product.id} {product.name}");
var person = (1, "Hector");
Console.WriteLine($"persona {person.Item1} {person.Item2}");


(int id, string name)[] = new[] 
{
    (1, "Sam"),
    (2, "Pepe")
};
```

## Excepciones 

Sirve para manejar errores

```C#
try
{
    string content = File.ReadAllText(@"C:\Users\WinterOS\Desktop\Programacion\Portafolio\public\txt.txt");
    Console.WriteLine(content);
    throw new Exception("Mandando excepcion");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("El archivo no existe");
}
catch (Exception ex)
{
    Console.WriteLine("excepcion general");
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Siempre se ejecutara al final");
}
```

## Excepcion personalizada


```C#
try
{
} catch (InvalidBeerException ex)
{
    throw new InvalidBeerException();
}

public class InvalidBeerException : Exception
{
    public InvalidBeerException () : base("La cerveza no tiene nombre o marca, por lo cual es invalida")
    {
        
    }
}
```

## LINQ

Nos va a permitir trabajar con colecciones

```C#
namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Beer> beers = new List<Beer>()
            {
                new Beer()
                {
                    Name="Corona", Country="Mexico"
                },
                new Beer()
                {
                    Name="Polar", Country="Colombia"
                },
                new Beer()
                {
                    Name="Light", Country="Alemania"
                },
            };

            foreach(var beer in beers)
                Console.WriteLine(beer);

            Console.WriteLine("------------------------------");

            // Select

            var beersName = from b in beers
                            select new
                            {
                                Name = b.Name,
                                Letters = b.Name.Length
                            };
            foreach (var beer in beersName)
            {
                Console.WriteLine($"{beer.Name} {beer.Letters}");
            }

            var beersNameReal = from b in beersName
                                select new
                                {
                                    Name = b.Name
                                };
            foreach (var beer in beersNameReal)
            {
                Console.WriteLine($"{beer.Name}");
            }

            Console.WriteLine("---------------------------------------------");

            // Where

            var beersMexico = from b in beers
                              where b.Country == "Mexico"
                              || b.Country == "Alemania"
                              select b;
            foreach(var beer in beersMexico)
                Console.WriteLine($"{beer}");

            var orderedBeers = from b in beers
                               orderby b.Country
                               select b;
            foreach (var beer in orderedBeers)
            {
                Console.WriteLine(beer);
            }
        }       
    }

    public class Beer
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Name}, Country: {Country}";
        }
    }
}

```

## LINQ_JOIN

Nos va a servir para unir 2 colecciones de informacion

```C#
    internal class Program
    {
        static void Main(string[] args)
        {
            var beers = new List<Beer>()
            {
                new Beer() {
                    Name="Corona", Country="Mexico"
                },
                new Beer()
                {
                    Name="Delirium", Country="Belgica"
                },
                new Beer()
                {
                    Name="Erdinger", Country="Alemania"
                }
            };

            var countries = new List<Country>()
            {
                new Country()
                {
                    Name="Mexico", Continent="America"
                },
                new Country()
                {
                    Name="Alemania", Continent="Europa"
                },
                new Country()
                {
                    Name="Belgica", Continent="Europa"
                }
            };

            var beersWithContinent = from beer in beers
                                     join country in countries
                                     on beer.Country equals country.Name
                                     select new
                                     {
                                         Name = beer.Name,
                                         country = beer.Country,
                                         Continent = country.Continent
                                     };
            foreach (var beer in beersWithContinent)
            {
                Console.WriteLine($"{beer.Name} {beer.country} {beer.Continent}");
            }
        }

    }

    public class Beer
    {
        public  required string Name { get; set; }

        public required string Country { get; set; }

    }

    public class Country
    {
        public required string Name { get; set; }

        public required string Continent { get; set; }

    }
```

## Base de datos

### Conexión

```C#
    public class DB
    {
        private string _connectionString;
        protected SqlConnection _connection;

        public DB(string server, string db, string user, string password)
        {
            _connectionString = $"Data Source={server}; Initial Catalog={db};" +
                $"User ID={user};Password={password}";
        }

        public void Connect()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public void Close()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            _connection.Close();
        }
    }
```

### Obtencion de datos 

```C#
        public BeerDB(string server, string db, string user, string password) : base(server, db, user, password)
        {
        }

        public List<Beer> GetAll()
        {
            Connect();

            List<Beer> beers = new List<Beer>();
            string query = "SELECT Id, Name, BrandId FROM BEER";
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);

                beers.Add(new Beer(id, name, brandId));
            }

            Close();
            return beers;
        }
```
### Obtener un dato

```C#
        public Beer Get(int id)
        {
            Connect();

            Beer beer = null;
            string query = "SELECT Id, Name, BrandId FROM BEER " +
                "WHERE Id = @id";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);

                beer = new Beer(id, name, brandId);
            }

            Close();
            return beer;
        }
```
### Insertar Datos

```C#
        public void Add(Beer beer)
        {
            Connect();
            string query = "INSERT INTO Beer(Name, BrandId) " +
                "VALUES(@name, @brandId)";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandId", beer.BrandId);

            command.ExecuteNonQuery();
            Close();
        }

```



### Editar

```C#
        public void Edit(Beer beer)
        {
            Connect();
            string query = "UPDATE beer SET name=@name, brandId=@brandId " +
                "WHERE id=@id";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandId", beer.BrandId);
            command.Parameters.AddWithValue("@id", beer.Id);

            command.ExecuteNonQuery();

             Close();
        }
```

### Eliminar 

```C#
        public void Delete(int id)
        {
            Connect();
            string query = "DELETE FROM beer WHERE id=@id";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();

            Console.WriteLine("Cerveza eliminada correctamente.");
            Close();
        }
```

### Codigo Main

```C#
        static void Main(string[] args)
        {
            try
            {
                BeerDB beerDB = new BeerDB(@"Artemas", "CsharpDB", "", "");
                bool again = true;
                int op = 0;
                do
                {

                    ShowMenu();
                    Console.WriteLine("Elige una opcion:");
                    op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            Show(beerDB);
                            break;
                        case 2:
                            Add(beerDB);
                            break;
                        case 3:
                            Edit(beerDB);
                            break;
                        case 4:
                            Delete(beerDB);
                            break;
                        case 5:
                            again = false;
                            break;
                    }
                }
                while (again);



            } catch (SqlException)
            {
                Console.WriteLine("no se pudo conectar");
            }

        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Mostrar cervezas");
            Console.WriteLine("2. Agregar cerveza");
            Console.WriteLine("3. Actualizar cerveza");
            Console.WriteLine("4. Eliminar cerveza");
            Console.WriteLine("5. Salir");
        }

        public static void Show(BeerDB beerDB)
        {
            Console.Clear();
            Console.WriteLine("Cervezas en la base de datos");
            List<Beer> beers = beerDB.GetAll();

            foreach (var beer in beers)
            {
                Console.WriteLine(beer.BrandId + " - " + beer.Name);
            }
        }

        public static void Add(BeerDB beerDB)
        {
            Console.Clear();
            Console.WriteLine("Agregar nueva cerveza");
            Console.WriteLine("Escribe el nombre:");
            string name = Console.ReadLine();
            Console.WriteLine("Escribe el id de la marca:");
            int brandId = int.Parse(Console.ReadLine());
            Beer beer = new Beer(name, brandId);
            beerDB.Add(beer);

        }

        public static void Edit(BeerDB beerDB)
        {
            Console.Clear();
            Show(beerDB);

            Console.WriteLine("Editar Cerveza");
            Console.WriteLine("Escribe el id de la cerveza a editar:");
            int id = int.Parse(Console.ReadLine());
            Beer beer = beerDB.Get(id);

            if (beer != null)
            {
                Console.WriteLine("Escribe el nombre: ");
                string name = Console.ReadLine();
                Console.WriteLine("Escribe el id de la marca: ");
                int brandId = int.Parse(Console.ReadLine());
                beer.Name = name;
                beer.BrandId = brandId;
                beerDB.Edit(beer);
            }
            else
            {
                Console.WriteLine("La cerveza no existe");
            }

        }

        public static void Delete(BeerDB beerDB)
        {
            Console.Clear();
            Show(beerDB);

            Console.WriteLine("Eliminar Cerveza");
            Console.WriteLine("Escribe el id de la cerveza a Eliminar:");
            int id = int.Parse(Console.ReadLine());
            Beer beer = beerDB.Get(id);

            if (beer != null)
            {
               beerDB.Delete(id);
            }
            else
            {
                Console.WriteLine("La cerveza no existe");
            }
        }
```

## Entity Framework - ORM

Paquetes necesarios:

Dependencias > Administrar Paquetes Nuggets

* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools

### Comando para crear mapeo en clases a partir de una base de datos existente:

* Scaffold-DbContext "Server=TuServidor;Database=TuBaseDeDatos;Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer

Para actualizar a nuevos campos

* Scaffold-DbContext "Server=TuServidor;Database=TuBaseDeDatos;Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -force

### Using

Using nos ayuda a evitar usar el `Dispose` al final de cada llamada

```C#
            DbContextOptionsBuilder<CsharpDbContext> optionsBuilder = new DbContextOptionsBuilder<CsharpDbContext>();
            optionsBuilder.UseSqlServer("Server=Artemas;Database=CsharpDB;Trusted_Connection=true;TrustServerCertificate=True;");
            using (CsharpDbContext context = new CsharpDbContext())
            {
                var beers = context.Beers.ToList();

                foreach (var beer in beers)
                {
                    Console.WriteLine(beer.Name);
                }
            }
```

### Seleccionar Informacion

```C#
public static void Show(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
{
    Console.Clear();
    Console.WriteLine("Cervezas en la base de datos");

    using (var context = new CsharpDbContext(optionsBuilder.Options))
    {
        //List<Beer> beers = context.Beers.OrderBy(b => b.Name).ToList();
        List<Beer> beers = (from b in context.Beers
                             where b.BrandId == 2
                             orderby b.Name
                             select b).Include(b=> b.Brand).ToList();
        foreach (var beer in beers)
        {
            Console.WriteLine($"{beer.Id} - {beer.Name} - {beer.Brand.Name}");
        }
    }
}
```

### Insertar Informacion

```C#
        public static void Add(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Console.WriteLine("Agregar nueva cerveza");
            Console.WriteLine("Escribe el nombre:");
            string name = Console.ReadLine();
            Console.WriteLine("Escribe el id de la marca:");
            int brandId = int.Parse(Console.ReadLine());
            using (var context = new CsharpDbContext(optionsBuilder.Options))
            {
                Beer beer = new Beer
                {
                    Name = name,
                    BrandId = brandId
                };
                context.Beers.Add(beer);
                context.SaveChanges();
            }
        }
```

### Editar Informacion 

```C#
        public static void Edit(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Editar cerveza");
            Console.WriteLine("Escribe el id de tu cerveza a editar");
            int id = int.Parse(Console.ReadLine());

            using (var context = new CsharpDbContext())
            {
                Beer beer = context.Beers.Find(id);
                if(beer != null)
                {
                    Console.WriteLine("Escribe el nombre:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Escribe el id de la marca");
                    int brandId = int.Parse(Console.ReadLine());

                    beer.Name = name;
                    beer.BrandId = brandId;
                    context.Entry(beer).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Cerveza no existente");
                }
            }
        }
```

### Eliminar Informacion 

```C#
        public static void Delete(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Eliminar Cerveza");
            Console.WriteLine("Escribe el id de la cerveza a eliminar");
            int id = int.Parse(Console.ReadLine());

            using (var context = new CsharpDbContext(optionsBuilder.Options)) 
            {
                Beer beer = context.Beers.Find(id);
                if (beer != null)
                {
                    context.Beers.Remove(beer);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Cerveza no existente");
                }
            }
        }
```

## Programacion Funcional

### Programacion funcional vs Programacion Orientada a Objetos

* POO une los datos y las funciones en un solo lugar (objetos) para simular y manipular entidades del mundo real mediante cambios de estado.

* PF separa los datos de las funciones, tratando el software como una tubería donde los datos fluyen a través de funciones que no alteran nada fuera de su alcance.

### Delegado

```C#

Operation mySum = Functions.Sum;

Console.WriteLine(mySum(1,2));

delegate int Operation(int a, int b);
delegate void Show(string message);



public class Functions
{
    public static int Sum(int a, int b) => a + b;
    public static int Mul(int a, int b) => a * b;

    public static void ConsoleShow(string message) => Console.WriteLine(message);
}
```
> Los delegados tienen multidifusion, puedes ejecutar 2 funciones en una


### Funcion de Primer Orden

Las funciones de primer orden son una propiedad del lenguaje que permite tratar a las funciones como variables (asignarlas a Func o Action).

### Funcion de Orden Superior

Las funciones de orden superior son métodos concretos que reciben a otras funciones como parámetro o las devuelven como resultado

### Delegado Generico

```C#
Action<string> showMessage = Console.WriteLine;
showMessage("Hola Mundo");
```

### Expresion Lambda

Similar a las arrow functions en javascript

```C#
Action<string, string> showMessage2 = (a, b) => Console.WriteLine(a + b);
```

### Delegado Generico Func

Este delegado esta hecho para regresar algo siempre. donde el ultimo argumento es siempre el tipo de dato que regresa 

```C#
Func<int, int>numberRandomLimit = (limit) => new Random().Next(1, limit); 
Console.WriteLine(numberRandomLimit(10));
```

### Delegado Generico Predicate

Nos permite crear delegados que tengan un tipo de una funcion que reciba algo pero siempre regrese un boolean

```C#
Predicate<string> hasSpace = (word) => word.Contains(" ");
Console.WriteLine(hasSpace("Hello World"));
```