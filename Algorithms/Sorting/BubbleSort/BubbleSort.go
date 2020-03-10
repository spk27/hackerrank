package main

import "fmt"

func main() {
	var n, count int
	fmt.Scan(&n)
	a := make([]int, n)
	for i := 0; i < n; i++ {
		fmt.Scan(&a[i])
	}

	for i := 0; i < n; i++ {
		for j := 0; j < n-1; j++ {
			if a[j+1] < a[j] {
				temp := a[j]
				a[j] = a[j+1]
				a[j+1] = temp
				count++
			}
		}
	}
	fmt.Println("Array is sorted in", count, "swaps.")
	fmt.Println("First Element:", a[0])
	fmt.Println("Last Element:", a[n-1])
}
