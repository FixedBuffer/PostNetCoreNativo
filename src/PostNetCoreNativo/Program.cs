using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PostNetCoreNativo
{
    class Program
    {
        //====================CONSTANTES====================
        const int STRING_MAX_LENGHT = 1024;

        //====================DECLARACION DE LLAMADAS NATIVAS===================================
        [DllImport("EjemploNativo", EntryPoint = "GetStringMessage")]
        public static extern void GetStringMessageNativo(StringBuilder sb, int StringLenght);

        [DllImport("EjemploNativo", EntryPoint = "Suma")]
        public static extern int SumaNativo(int A, int B);

        //Obtenemos el mensaje desde C++
        static string GetStringMessage()
        {
            //Declaramos el objeto que nos devolvera el mensaje
            StringBuilder sb = new StringBuilder(STRING_MAX_LENGHT);
            //Llamamos a la libreria nativa
            GetStringMessageNativo(sb, STRING_MAX_LENGHT);

            return sb.ToString();
        }


        static void Main(string[] args)
        {
            //Obtenemos el sistema operativo sobre el que corre la aplicacion
            string OS = RuntimeInformation.OSDescription;
            int sumando1 = 123, sumando2 = 3245;
            Console.WriteLine($"Mensaje escrito en C# sobre {OS}");
            Console.WriteLine(GetStringMessage());
            Console.WriteLine($"Suma desde codigo nativo '{sumando1} + {sumando2} = {SumaNativo(sumando1, sumando2)}'");

            Console.Read();
        }
    }
}
