package main

import (
	"fmt"
)

var s string

func main() {
	fmt.Scan(&s)
	fmt.Println(preProcess(len(s)))
	// var q int
	// fmt.Scan(&q)
	// for i := 0; i < q; i++ {
	// 	sub, n := initializeQuery()
	// 	sort.Strings(sub)
	// 	fmt.Println(buildPalindrome(sub, n, 0))
	// }
}

func preProcess(n int) [1000][1000]int {
	dp := [1000][1000]int{}
	a := []rune(s)
	for i := 'a'; i <= 'z'; i++ {
		if dp[0][i] = 0; a[0] == i {
			dp[0][i] = 1
		}
		for j := 1; j < n; j++ {
			dp[j][i] = dp[j-1][i]
			if a[j] == i {
				dp[j][i]++
			}
		}
	}
	return dp
}
