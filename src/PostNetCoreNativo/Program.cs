using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PostNetCoreNativo
{
    class Program
    {
        //====================CONSTANTES====================
        const string LibreriaWindows = "EjemploNativo.dll";
        const string LibreriaNoWindows = "EjemploNativo.so";
        const int STRING_MAX_LENGHT = 1024;

        //====================DECLARACION DE LLAMADAS NATIVAS===================================
        [DllImport(LibreriaWindows,  EntryPoint = "GetStringMessage")]
        public static extern void GetStringMessage_Windows(StringBuilder sb, int StringLenght);

        [DllImport(LibreriaNoWindows, EntryPoint = "GetStringMessage")]
        public static extern void GetStringMessage_NoWindows(StringBuilder sb, int StringLenght);

        [DllImport(LibreriaWindows, EntryPoint = "Suma")]
        public static extern int Suma_Windows(int A, int B);

        [DllImport(LibreriaNoWindows, EntryPoint = "Suma")]
        public static extern int Suma_NoWindows(int A, int B);
        
        //Obtenemos el mensaje desde C++
        static string GetStringMessageNativo()
        {
            //Declaramos el objeto que nos devolvera el mensaje
            StringBuilder sb = new StringBuilder(STRING_MAX_LENGHT);

            //En funcion de la plataforma, llamamos a una funcion o a otra, ya que la extension cambia
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                GetStringMessage_Windows(sb, STRING_MAX_LENGHT);
            else
                GetStringMessage_NoWindows(sb, STRING_MAX_LENGHT);

            return sb.ToString();
        }


        static int SumaNativo (int A, int B)
        {
            //En funcion de la plataforma, llamamos a una funcion o a otra, ya que la extension cambia
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
               return Suma_Windows(A,B);
            else
               return Suma_NoWindows(A, B);

        }
        static void Main(string[] args)
        {
            //Obtenemos el sistema operativo sobre el que corre la aplicacion
            string OS = RuntimeInformation.OSDescription;
            Console.WriteLine($"Mensaje escrito en C# sobre {OS}");
            Console.WriteLine(GetStringMessageNativo().ToString());
            Console.WriteLine($"Suma desde codigo nativo de los números 4 y 5");
            Console.WriteLine(SumaNativo(4,5));

            Console.Read();
        }
    }
}
