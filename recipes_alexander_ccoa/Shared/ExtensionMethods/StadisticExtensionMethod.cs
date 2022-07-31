using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipes_alexander_ccoa.Shared.ExtensionMethods
{
    public static class StadisticExtensionMethod
    {
        public static double  GetPercentage(this double value, double total, int significantValues = 2)
        => Math.Round((value/total)*100, significantValues);
        
        public static decimal GetPercentage(this decimal value, decimal total, int significantValues = 2)
        => Math.Round((value/total)*100, significantValues);

        public static decimal GetPercentage(this int value, decimal total, int significantValues = 2)
        => Math.Round((value/total)*100, significantValues);

    }
}
