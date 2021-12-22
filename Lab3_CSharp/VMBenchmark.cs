using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CSharp
{
    class VMBenchmark
    {
        List<VMTime> timeTestRes { get; set; }
        List<VMAccuracy> accComparRes { get; set; }

        public VMBenchmark()
        {
            timeTestRes = new List<VMTime>();
            accComparRes = new List<VMAccuracy>();
        }

        private double[] makeArgs(double head, double end, int N)
        {
            var step = (end - head) / N;
            double[] args = new double[N];
            args[0] = head;
            args[N - 1] = end;
            for (int i = 1; i < N-1; i++)
            {
                args[i] = args[i - 1] + step;
            }

            return args;
        }

        public override string ToString()
        {
            if (timeTestRes != null && accComparRes != null)
            {
                string output = "";
                for (int k = 0; k < timeTestRes.Count; k++)
                {
                    output += $"Experiment number {k + 1}:\n" + timeTestRes[k].ToString() + accComparRes[k].ToString() +
                              "\n***********************************************************\n";
                }

                return output;
            }

            return "Sorry, all lists in benchmark class are empty.";
        }


        public void TestMKL_VM_Func(double head, double end, int N)
        {
            double[] args = makeArgs(head, end, N);
            double[] valsHA = new double[args.Length];
            double[] valsEP = new double[args.Length];
            double[] tempValsHA = new double[args.Length];
            double[] tempValsEP = new double[args.Length];
            double sinTimeHA = 0.0, sinTimeEP = 0.0, cosTimeHA = 0.0, cosTimeEP = 0.0, scTimeHA = 0.0, scTimeEP = 0.0;
            int ret = -1;
            try
            {
                VMAccuracy acc = new VMAccuracy(N, new double[2] { head, end });
                VM_Sin(N, args, valsHA, valsEP, ref sinTimeHA, ref sinTimeEP, ref ret);
                Console.WriteLine($"VM_Sin test: ret = {ret}");
                acc.MaxDiffModule(valsHA, valsEP, "sin");
                acc.ValArgMaxDiff(args, valsHA, valsEP, "sin");
                VM_Cos(N, args, valsHA, valsEP, ref cosTimeHA, ref cosTimeEP, ref ret);
                Console.WriteLine($"VM_Cos test: ret = {ret}");
                acc.MaxDiffModule(valsHA, valsEP, "cos");
                acc.ValArgMaxDiff(args, valsHA, valsEP, "cos");
                VM_SinCos(N, args, tempValsHA, tempValsEP, valsHA, valsEP, ref scTimeHA, ref scTimeEP, ref ret);
                Console.WriteLine($"VM_SinCos test: ret = {ret}");
                acc.MaxDiffModule(valsHA, valsEP, "sincos");
                acc.ValArgMaxDiff(args, valsHA, valsEP, "sincos");
                Console.WriteLine("***********************************************************");
                timeTestRes.Add(new VMTime(N, sinTimeHA, sinTimeEP, cosTimeHA, cosTimeEP, scTimeHA, scTimeEP));
                accComparRes.Add(acc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [DllImport("..\\..\\..\\..\\x64\\DEBUG\\CPP_DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VM_Sin(int n, double[] x, double[] yHA, double[] yEP, ref double timeHA, ref double timeEP, ref int ret);
        [DllImport("..\\..\\..\\..\\x64\\DEBUG\\CPP_DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VM_Cos(int n, double[] x, double[] yHA, double[] yEP, ref double timeHA, ref double timeEP, ref int ret);
        [DllImport("..\\..\\..\\..\\x64\\DEBUG\\CPP_DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void VM_SinCos(int n, double[] x, double[] yHA, double[] yEP, double[] zHA, double[] zEP, ref double timeHA, ref double timeEP, ref int ret);
    }
}
