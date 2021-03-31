using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution {
class Solution {
    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine().TrimEnd());
        int aux = 0, max = 0, count = 0;
        bool flag = false;
        
        for (int i = 0; i < n; i++)
        {
            string[] s = Console.ReadLine().Split(' ');            

            for (int j = 0; j < s.Count(); j++)
            {
                if(flag) continue;
                if(Int32.TryParse(s[j], out aux)) {
                    max = max < aux ? aux : max;
                    count++;
                } else {
                    Console.WriteLine($"FAILURE => WRONG INPUT (LINE {j+1})");
                    flag = true;
                }              
            }
            
            if(!flag) {
                if(count == max) {
                    Console.WriteLine($"SUCCESS => RECEIVED: {count}");
                } else {
                    Console.WriteLine($"FAILURE => RECEIVED: {count}, EXPECTED: {max}");
                }
            }

            aux = 0;
            max = 0;
            count = 0;
            flag = false;
        }
    }
}
}