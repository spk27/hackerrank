using System;

class MarkAndToys {
  static void Main(string[] args) {
    int[] nk = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), e => Convert.ToInt32(e));
    int n = nk[0];
    int k = nk[1];
    int[] toys = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), e => Convert.ToInt32(e));
    int amount = 0, i = 0, count = 0;
    Array.Sort(toys);
    while (amount + toys[i] < k && i < n) {
      amount += toys[i];
      count++;
      i++;
    }
    Console.WriteLine(count);
  }
}