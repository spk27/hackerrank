using System;
using System.Collections.Generic;
using System.Linq;

class FraudulentActivityNotifications {
  static void Main(string[] args) {
    var nd = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), e => Convert.ToInt32(e));
    int n = nd[0], d = nd[1], count = 0;
    var expenditure = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), e => Convert.ToInt32(e));
    var subSetExp = new int[d];
    var arr = new int[201];
    Queue<int> queue = new Queue<int>(expenditure.Take(d));
    for(int i = 0; i < d; i++) {
      arr[expenditure[i]]++;
    }
    for(int i = d; i < n; i++) {
      int[] cs = arr.ToArray();
      for(int j = 1; j < 201; j++) {
        cs[j] += cs[j-1];
      }
      int m = mediaExpenditure(cs, d);
      if(m <= expenditure[i]) count++;

      arr[expenditure[i-d]]--;
      arr[expenditure[i]]++;
    }
    Console.WriteLine(count);
  }

  static int mediaExpenditure(int[] cs, int d) {
    int index = d/2;
    int m = 0, i = 0;
    if(d%2 == 0) {
      while(i < 201) {
        if(index <= cs[i]) {
          m = i;
          break;
        }
        i++;
      }
      while(i < 201) {
        if(index + 1 <= cs[i]) {
          m += i;
          break;
        }
        i++;
      }
    } else {
      while(i < 201) {
        if(index + 1 <= cs[i]) {
          m = i * 2;
          break;
        }
        i++;
      }
    }
    return m;
  }
}