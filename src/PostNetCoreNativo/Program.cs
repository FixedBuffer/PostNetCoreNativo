using System;
using System.Runtime.InteropServices;

namespace PostNetCoreNativo
{
    class Program
    {
        [DllImport(@"EjemploNativo.dll",EntryPoint = "MetodoNativo")]
        public static extern void MetodoNativo();    

        static void Main(string[] args)
        {
            string OS = RuntimeInformation.OSDescription;
            Console.WriteLine($"Escribo esto desde C# sobre {OS}");
            MetodoNativo();
            Console.Read();
        }
    }
}
