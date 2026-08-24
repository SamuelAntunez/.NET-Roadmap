namespace Herencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Doctor doctor1 = new Doctor("Juan", 40, "Ginecologo");
            Console.WriteLine(doctor1.GetInfo());
            Console.WriteLine(doctor1.GetData());
        }

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

    }
}
