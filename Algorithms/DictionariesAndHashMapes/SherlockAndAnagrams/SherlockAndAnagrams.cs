using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution {
  static void Main(string[] args) {
    int q = Convert.ToInt32(Console.ReadLine());

    for(int i = 0; i < q; i++) {
      string s = Console.ReadLine();
      var mapHash = HashedDic(s);
      printPairs(mapHash);
    }
  }

  static Dictionary<int, int> HashedDic(string str) {
    var mapHash = new Dictionary<int, int>();
    for (int i = 1; i < str.Length; i++) {
      for (int start = 0; start <= str.Length - i; start++) {
        string substr = str.Substring(start, i);
        int hashCode = SortAndGenerateHash(substr, substr.Length);
        if (mapHash.ContainsKey(hashCode)) {
          mapHash[hashCode]++;
        } else mapHash.Add(hashCode, 1);
      }
    }
    return mapHash;
  }

  static int SortAndGenerateHash(string substr, int length) {
    StringBuilder hash = new StringBuilder();
    char[] characters = substr.ToArray();
    Array.Sort(characters);
    substr = new string(characters);
    char cAux = substr[0];
    int countChar = 1;
    for(int i = 1; i < length; i++) {
      if (cAux == substr[i]) countChar++;
      else {
        hash.Append(cAux + countChar.ToString());
        countChar = 1;
        cAux = substr[i];
      }
    }
    hash.Append(cAux + countChar.ToString());

    return hash.ToString().GetHashCode();
  }

  static void printPairs(Dictionary<int, int> mapHash) {
    int pairs = 0;
    foreach(var hash in mapHash) {
      pairs += hash.Value * (hash.Value - 1) / 2;
    }
    Console.WriteLine(pairs);
  }

}