using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PostNetCoreNativo
{
    class Program
    {
        //====================CONSTANTES====================
        const string LibreriaWindows = "EjemploNativo.dll";
        const string LibreriaLinux = "EjemploNativo.so";
        const string LibreriaMacOS = "EjemploNativo.dylib";
        const int STRING_MAX_LENGHT = 1024;

        //====================DECLARACION DE LLAMADAS NATIVAS===================================
        [DllImport(LibreriaWindows, EntryPoint = "GetStringMessage")]
        public static extern void GetStringMessage_Windows(StringBuilder sb, int StringLenght);

        [DllImport(LibreriaLinux, EntryPoint = "GetStringMessage")]
        public static extern void GetStringMessage_Linux(StringBuilder sb, int StringLenght);

        [DllImport(LibreriaMacOS, EntryPoint = "GetStringMessage")]
        public static extern void GetStringMessage_MacOS(StringBuilder sb, int StringLenght);

        [DllImport(LibreriaWindows, EntryPoint = "Suma")]
        public static extern int Suma_Windows(int A, int B);

        [DllImport(LibreriaLinux, EntryPoint = "Suma")]
        public static extern int Suma_Linux(int A, int B);

        [DllImport(LibreriaMacOS, EntryPoint = "Suma")]
        public static extern int Suma_MacOS(int A, int B);

        //Obtenemos el mensaje desde C++
        static string GetStringMessageNativo()
        {
            //Declaramos el objeto que nos devolvera el mensaje
            StringBuilder sb = new StringBuilder(STRING_MAX_LENGHT);

            //En funcion de la plataforma, llamamos a una funcion o a otra, ya que la extension cambia
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                GetStringMessage_Windows(sb, STRING_MAX_LENGHT);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                GetStringMessage_Linux(sb, STRING_MAX_LENGHT);
            else
                GetStringMessage_MacOS(sb, STRING_MAX_LENGHT);

            return sb.ToString();
        }


        static int SumaNativo(int A, int B)
        {
            //En funcion de la plataforma, llamamos a una funcion o a otra, ya que la extension cambia
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return Suma_Windows(A, B);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return Suma_Linux(A, B);
            else
                return Suma_MacOS(A, B);

        }

        static void Main(string[] args)
        {
            //Obtenemos el sistema operativo sobre el que corre la aplicacion
            string OS = RuntimeInformation.OSDescription;
            int sumando1 = 123, sumando2 = 3245;
            Console.WriteLine($"Mensaje escrito en C# sobre {OS}");
            Console.WriteLine(GetStringMessageNativo().ToString());
            Console.WriteLine($"Suma desde codigo nativo '{sumando1} + {sumando2} = {SumaNativo(sumando1, sumando2)}'");

            Console.Read();
        }
    }
}
