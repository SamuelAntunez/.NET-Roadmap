using BD;
using Microsoft.EntityFrameworkCore;


namespace EntityFrameworkSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<CsharpDbContext> optionsBuilder = new DbContextOptionsBuilder<CsharpDbContext>();
            optionsBuilder.UseSqlServer("Server=Artemas;Database=CsharpDB;Trusted_Connection=true;TrustServerCertificate=True;");


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
                        Show(optionsBuilder);
                        break;
                    case 2:
                        Add(optionsBuilder);
                        break;
                    case 3:
                        Edit(optionsBuilder);
                        break;
                    case 4:
                        Delete(optionsBuilder);
                        break;
                    case 5:
                        again = false;
                        break;
                }
            }
            while (again);
        }

        public static void Show(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Console.WriteLine("Cervezas en la base de datos");

            using (var context = new CsharpDbContext(optionsBuilder.Options))
            {
                //List<Beer> beers = context.Beers.OrderBy(b => b.Name).ToList();
                List<Beer> beers = (from b in context.Beers
                                     orderby b.Name
                                     select b).Include(b=> b.Brand).ToList();
                foreach (var beer in beers)
                {
                    Console.WriteLine($"{beer.Id} - {beer.Name} - {beer.Brand.Name}");
                }
            }
        }

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

        public static void Edit(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Editar cerveza");
            Console.WriteLine("Escribe el id de tu cerveza a editar");
            int id = int.Parse(Console.ReadLine());

            using (var context = new CsharpDbContext(optionsBuilder.Options))
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
        public static void ShowMenu()
        {
            Console.WriteLine("\n --- Menú ---");
            Console.WriteLine("1. Mostrar datos");
            Console.WriteLine("2. Insertar datos");
            Console.WriteLine("3. Actualizar datos");
            Console.WriteLine("4. Eliminar datos");
            Console.WriteLine("5. Salir");
        }
    }
}
