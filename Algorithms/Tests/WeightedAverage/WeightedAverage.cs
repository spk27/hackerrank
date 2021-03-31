using System;
using System.Collections.Generic;
using System.Linq;
public class WeightedAverage
{
    public static double Mean(IList<long> numbers, IList<long> weights)
    {
        if(
          (numbers == null || weights == null) ||
          numbers.Count != weights.Count ||
          weights.Sum() < 1) 
            throw new ArgumentException();
        
        long total = 0;
        long totalWeights = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            total += numbers[i] * weights[i];
            totalWeights += weights[i];
        }

        return total / (double)totalWeights;
    }

    public static void Main(string[] args)
    {
        int[] values = new int[] { 3, 6 };
        int[] weights = new int[] { 4, 2 };

        Console.WriteLine(WeightedAverage.Mean(values, weights));
    }
}