using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution {
  static void Main(string[] args) {
    string[] nr = Console.ReadLine().TrimEnd().Split(' ');
    int n = Convert.ToInt32(nr[0]);
    long r = Convert.ToInt32(nr[1]);
    List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();
    ulong totalTripets = 0;
    var firstOnSeq = new Dictionary<long, ulong>();
    var secondOnSeq = new Dictionary<long, ulong>();

    for (int i = 0; i < n; i++) {
      if(arr[i] % r == 0) {
        var ar = arr[i] / r;
        if(secondOnSeq.ContainsKey(ar)) totalTripets += secondOnSeq[ar];
        if(firstOnSeq.ContainsKey(ar)) {
          if(!secondOnSeq.ContainsKey(arr[i])) secondOnSeq.Add(arr[i], 0);
          secondOnSeq[arr[i]] += firstOnSeq[ar];
        }
      }
      if(!firstOnSeq.ContainsKey(arr[i])) firstOnSeq.Add(arr[i], 0);
      firstOnSeq[arr[i]]++;
    }
    Console.WriteLine(totalTripets);
  }
}