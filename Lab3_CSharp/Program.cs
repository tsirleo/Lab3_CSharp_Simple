using System;
using System.Runtime.InteropServices;
using Lab3_CSharp;

namespace MKL_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            VMBenchmark benchmark = new VMBenchmark();
            try
            {
                benchmark.TestMKL_VM_Func(2.1, 16.7, 140);
                benchmark.TestMKL_VM_Func(1.0, 7.1, 1000);
                benchmark.TestMKL_VM_Func(11.1, 160.12, 10000);
                benchmark.TestMKL_VM_Func(1.0, 14000.12, 1000000);
                Console.WriteLine(benchmark.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Oops, something went wrong!\n");
                Console.WriteLine(ex);
            }
        }
    }
}
