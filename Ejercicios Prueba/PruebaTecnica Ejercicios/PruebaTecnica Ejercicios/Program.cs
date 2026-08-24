using System.Text.RegularExpressions;

string Ejemplo = "Samuela";

string Respuesta = "";

for (int i = Ejemplo.Length - 1; i >= 0; i--)
{
    Respuesta += Ejemplo[i];

}

Console.WriteLine("Invertir cadena de string");
Console.WriteLine(Respuesta);

//! Las veces que se repite un caracter


char Caracter = 'a';
int CaracterRepetido = 0;

for (int i = 0; i < Ejemplo.Length;)
{
    if (Ejemplo[i] == Caracter)
    {
        CaracterRepetido++;
    }

    i++;
}

Console.WriteLine("Caracteres que se repiten");
Console.WriteLine(CaracterRepetido);

// Distancia de Hamming

string text1 = "patitosw";
string text2 = "paratosa";

int distance = 0;

if (text1.Length != text2.Length) throw new Exception("Longitudes distintas");

for (int i = 0; i < text1.Length; i++)
{
    if (text1[i] != text2[i]) distance++;
}

Console.WriteLine("Distancia es de: " + distance);

// Contador de palabras

string text = "un texto que tiene muchas palabras por escribir";
int n = 0;

var words =  Regex.Replace(text, @"\s+", " ").Trim().Split(" "); // Split nos devuelve un array separado por lo que especificamos
n = words.Length;

Console.WriteLine("Numero de palabras: " + n);

// Contar numeros

string textwithnumber = "an342sern43nnfdsa4";

int cantidadNumeros = 0;

foreach (var c in textwithnumber)
{
    if (char.IsDigit(c)) cantidadNumeros++;
}

Console.WriteLine("Cantidad de numeros: " + cantidadNumeros);