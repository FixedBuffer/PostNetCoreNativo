using System;
using System.Runtime.InteropServices;

namespace PostNetCoreNativo
{
    class Program
    {
        [DllImport(@"EjemploNativo.dll",EntryPoint = "MetodoNativo")]
        public static extern void Windows_MetodoNativo();
        [DllImport(@"EjemploNativo.so", EntryPoint = "MetodoNativo")]
        public static extern void NoWindows_MetodoNativo();


        static void MetodoNativo()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                Windows_MetodoNativo();
            else
                NoWindows_MetodoNativo();
        }

        static void Main(string[] args)
        {
            string OS = RuntimeInformation.OSDescription;
            Console.WriteLine($"Escribo esto desde C# sobre {OS}");
            MetodoNativo();
            Console.Read();
        }
    }
}
