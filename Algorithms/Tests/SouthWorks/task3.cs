using System;
using System.Collections.Generic;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public static int solution(int[] A) {

        var dic = new Dictionary<int, List<int>>();
        int maxSum = -1;

        for (int i = 0; i < A.Length; i++)
        {  
            var key = digitsSum(A[i]);

            if(!dic.ContainsKey(key)) dic.Add(key, new List<int>() { A[i] });
            else dic[key].Add(A[i]);
        }

        var keys = dic.Keys.ToList();

        foreach (var key in keys.OrderByDescending(c => c))
        {
            if(dic[key].Count >= 2) {
                int num1 = dic[key][0];
                int num2 = dic[key][1];
                for (int i = 2; i < dic[key].Count; i++)
                {
                    if(num1 < num2) 
                    { 
                        if(num1 < dic[key][i]) num1 = dic[key][i]; 
                    }
                    else if(num2 < dic[key][i]) num2 = dic[key][i];

                }

                if(maxSum < num1 + num2) maxSum = num1 + num2;
            }
        }

        return maxSum;
    }

    public static int digitsSum(int e) {
        int aux = 0;

        while(e > 0)
        {
            aux += e % 10;
            e = e / 10;
        }

        return aux;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(solution(new int[] {78,546,487}));
    }
}
