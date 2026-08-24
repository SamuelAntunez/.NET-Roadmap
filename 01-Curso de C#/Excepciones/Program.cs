using System.IO;

namespace Excepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {

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

            try
            {

            } catch (InvalidBeerException ex)
            {
                throw new InvalidBeerException();
            }

        }
    }

    public class InvalidBeerException : Exception
    {
        public InvalidBeerException () : base("La cerveza no tiene nombre o marca, por lo cual es invalida")
        {
            
        }
    }

    
}
