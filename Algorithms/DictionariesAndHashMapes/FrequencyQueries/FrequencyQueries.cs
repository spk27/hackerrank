using System;
using System.Collections.Generic;
using System.Linq;
class FrequencyQueries
{
  static Dictionary<int, int> freqHash;
  static Dictionary<int, int> numberHash;
  static void Main(string[] args) {
    int q = Convert.ToInt32(Console.ReadLine().TrimEnd());
    freqHash = new Dictionary<int, int>();
    numberHash = new Dictionary<int, int>();
    int action, xyz;
    int[][] arr = new int[q][];
    for(int i = 0; i < q; i++) {
      var temp = Console.ReadLine().TrimEnd().Split(' ');
      arr[i] = new int[2] { Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]) };
    }
    for (int i = 0; i < q; i++) {
      action = arr[i][0];
      xyz = arr[i][1];
      if(action == 3) {
        if(freqHash.ContainsKey(xyz) && 0 < freqHash[xyz])
          Console.WriteLine("1");
        else
          Console.WriteLine("0");
      } else {
        if (action == 1) {
          if (!numberHash.ContainsKey(xyz)) numberHash.Add(xyz, 0);
          numberHash[xyz]++;
          updateFreq(numberHash[xyz] - 1, numberHash[xyz]);
        } else {
          if (numberHash.ContainsKey(xyz) && 0 < numberHash[xyz]) {
            numberHash[xyz]--;
            updateFreq(numberHash[xyz] + 1, numberHash[xyz]);
          }
        }
      }
    }
  }

  static void updateFreq(int oldFreq, int newFreq) {
    if (freqHash.ContainsKey(oldFreq) && freqHash[oldFreq]-- < 0)
      freqHash.Remove(oldFreq);
    if (freqHash.ContainsKey(newFreq)) { freqHash[newFreq]++; }
    else if (0 < newFreq) { freqHash.Add(newFreq, 1); }
  }
}