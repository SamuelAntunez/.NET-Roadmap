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

