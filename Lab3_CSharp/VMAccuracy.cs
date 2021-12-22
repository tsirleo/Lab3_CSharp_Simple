using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CSharp
{
    class VMAccuracy
    {
        public int vecLength { get; private set; }
        public double[] segment { get; private set; } 
        public double sinMaxDiffMod { get; private set; }
        public double sinArgMaxDiff { get; private set; }
        public double sinValMaxDiff { get; private set; }
        public double cosMaxDiffMod { get; private set; }
        public double cosArgMaxDiff { get; private set; }
        public double cosValMaxDiff { get; private set; }
        public double scMaxDiffMod { get; private set; }
        public double scArgMaxDiff { get; private set; }
        public double scValMaxDiff { get; private set; }

        public VMAccuracy(int len, double[] seg)
        {
            vecLength = len;
            segment = seg;
        }

        public void MaxDiffModule(double[] valsHA, double[] valsEP, string flag)
        {
            if (valsEP != null && valsHA != null)
            {
                double maxmod = Math.Abs(valsHA[0] - valsEP[0]);
                for (int i = 1; i < valsHA.Length; i++)
                {
                    var temp = Math.Abs(valsHA[i] - valsEP[i]);
                    if (temp > maxmod)
                    {
                        maxmod = temp;
                    }
                }

                switch (flag)
                {
                    case "sin":
                        sinMaxDiffMod = maxmod;
                        break;
                    case "cos":
                        cosMaxDiffMod = maxmod;
                        break;
                    case "sincos":
                        scMaxDiffMod = maxmod;
                        break;
                }
            }
        }

        public void ValArgMaxDiff(double[] args, double[] valsHA, double[] valsEP, string flag)
        {
            if (valsEP != null && valsHA != null && args != null)
            {
                double maxdiff = valsHA[0] - valsEP[0];
                int imax = 0;
                for (int i = 1; i<valsHA.Length; i++)
                {
                    var temp = valsHA[i] - valsEP[i];
                    if (temp > maxdiff)
                    {
                        maxdiff = temp;
                        imax = i;
                    }
                }

                switch (flag)
                {
                    case "sin":
                        sinArgMaxDiff = args[imax];
                        sinValMaxDiff = maxdiff;
                        break;
                    case "cos":
                        cosArgMaxDiff = args[imax];
                        cosValMaxDiff = maxdiff;
                        break;
                    case "sincos":
                        scArgMaxDiff = args[imax];
                        scValMaxDiff = maxdiff;
                        break;
                }
            }
        }

        public override string ToString() => $"VMAccuracy: vector length = {vecLength}\ton interval = [{segment[0]}; {segment[1]}]\n\t" +
                                             $"sinMaxDiffMod = {sinMaxDiffMod}\tsinValMaxDiff = {sinValMaxDiff}\tsinArgMaxDiff = {sinArgMaxDiff}\n\t" +
                                             $"cosMaxDiffMod = {cosMaxDiffMod}\tcosValMaxDiff = {cosValMaxDiff}\tcosArgMaxDiff = {cosArgMaxDiff}\n\t" +
                                             $"scMaxDiffMod = {scMaxDiffMod}\tscValMaxDiff = {scValMaxDiff}\tscArgMaxDiff = {scArgMaxDiff}\n";
    }
}
