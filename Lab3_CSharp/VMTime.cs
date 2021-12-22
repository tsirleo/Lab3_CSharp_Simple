using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CSharp
{
    class VMTime
    {
        public int vecLength { get; private set; }
        public double sinTime_HA { get; private set; }
        public double sinTime_EP { get; private set; }
        public double cosTime_HA { get; private set; }
        public double cosTime_EP { get; private set; }
        public double sinCosTime_HA { get; private set; }
        public double sinCosTime_EP { get; private set; }

        public VMTime(int length, double stHA, double stEP, double ctHA, double ctEP, double sctHA, double sctEP)
        {
            vecLength = length;
            sinTime_HA = stHA;
            sinTime_EP = stEP;
            cosTime_HA = ctHA;
            cosTime_EP = ctEP;
            sinCosTime_HA = sctHA;
            sinCosTime_EP = sctEP;
        }

        public double[] RetArr
        {
            get { return new[] {sinTime_HA, sinTime_EP, cosTime_HA, cosTime_EP, sinCosTime_HA, sinCosTime_EP}; }
        }

        public double[] RetHA
        {
            get { return new[] { sinTime_HA, cosTime_HA, sinCosTime_HA }; }
        }

        public double[] RetEP
        {
            get { return new[] { sinTime_EP, cosTime_EP, sinCosTime_EP }; }
        }

        public override string ToString() => $"VMTime: vector length = {vecLength}\n\tsinTime_HA = {sinTime_HA} seconds\n\t" +
                                             $"sinTime_EP = {sinTime_EP} seconds\n\tcosTime_HA = {cosTime_HA} seconds\n\t" +
                                             $"cosTime_EP = {cosTime_EP} seconds\n\tsinCosTime_HA = {sinCosTime_HA} seconds\n\t" +
                                             $"sinCosTime_EP = {sinCosTime_EP} seconds\n";
    }
}
