using System;

class BubbleSort
{
  static void Main(string[] args) {
    int n = Convert.ToInt32(Console.ReadLine().TrimEnd());
    int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), e => Convert.ToInt32(e));
    int temp, count = 0;
    for (int i = 0; i < n; i++)
      for (int j = 0; j < n - 1; j++) {
        if (a[j] > a[j + 1]) {
          temp = a[j];
          a[j] = a[j+1];
          a[j+1] = temp;
          count++;        
        }
      }
    Console.WriteLine("Array is sorted in " + count + " swaps.");
    Console.WriteLine("First Element: " + a[0]);
    Console.WriteLine("Last Element: " + a[n-1]);
  }
}