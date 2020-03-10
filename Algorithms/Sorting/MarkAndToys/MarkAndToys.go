package main

import (
	"fmt"
	"sort"
)

func main() {
	var n, k, count, i, amount int
	fmt.Scan(&n)
	fmt.Scan(&k)
	toys := make([]int, n)
	for i := 0; i < n; i++ {
		fmt.Scan(&toys[i])
	}
	sort.Ints(toys)
	for amount+toys[i] < k && i < n {
		amount += toys[i]
		count++
		i++
	}
	fmt.Println(count)
}
