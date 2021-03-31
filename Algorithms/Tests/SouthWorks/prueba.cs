using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        var arr = new int[10000001];

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] >= 0) arr[A[i]] = 1;
        }

        for (int i = 0; i < 10000001; i++)
        {
            if (arr[i] == 0) return arr[i];
        }

        //int res = 1000001;

        //for (int i = 0; i < A.Length; i++)
        //{
        //    if (res < A[i] && A[i] > 0) res = A[i];
        //}

        //return 0;
    }
}
