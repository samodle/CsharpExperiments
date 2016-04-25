using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PertEstimate
{
    public static class PertEstimate
    {

        public static double Estimate(double likelyAmount, double bestCaseAmount, double worstCaseAmount)
        {
            return (likelyAmount * 4 + bestCaseAmount + worstCaseAmount) / 6;
        }


    }
}
