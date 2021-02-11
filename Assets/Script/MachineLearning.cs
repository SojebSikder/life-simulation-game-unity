using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineLearning
{

    public static void LinearRegression(
          double[] xVals,
          double[] yVals,
          out double rSquared,
          out double yIntercept,
          out double slope )
    {
        if (xVals.Length != yVals.Length)
        {
            throw new Exception("Input values should be with the same length.");
        }

        double sumOfX = 0;
        double sumOfY = 0;
        double sumOfXSq = 0;
        double sumOfYSq = 0;
        double sumCodeviates = 0;

        for (var i = 0; i < xVals.Length; i++)
        {
            var x = xVals[i];
            var y = yVals[i];
            sumCodeviates += x * y;
            sumOfX += x;
            sumOfY += y;
            sumOfXSq += x * x;
            sumOfYSq += y * y;
        }

        var count = xVals.Length;
        var ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
        var ssY = sumOfYSq - ((sumOfY * sumOfY) / count);

        var rNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
        var rDenom = (count * sumOfXSq - (sumOfX * sumOfX)) * (count * sumOfYSq - (sumOfY * sumOfY));
        var sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

        var meanX = sumOfX / count;
        var meanY = sumOfY / count;
        var dblR = rNumerator / Math.Sqrt(rDenom);

        rSquared = dblR * dblR;
        yIntercept = meanY - ((sCo / ssX) * meanX);
        slope = sCo / ssX; // y differ / x differ


    }

    public static double mean(params double[] vals)
    {
        double sum = 0;
        double result;

        for (int i = 0; i < vals.Length; i++)
        {
            sum += vals[i];
        }

        result = sum / vals.Length;

        return result;
    }
}
