/*
package main

import (
	"fmt"
	"sort"
	"strings"
)

var s string

func main() {
	fmt.Scan(&s)
	var q int
	fmt.Scan(&q)
	for i := 0; i < q; i++ {
		sub, n := initializeQuery()
		sort.Strings(sub)
		fmt.Println(buildPalindrome(sub, n, 0))
	}
}

func initializeQuery() ([]string, int) {
	var l, r int
	fmt.Scan(&l)
	fmt.Scan(&r)
	return strings.Split(s[l-1:r], ""), (r - l) + 1
}

func buildPalindrome(sub []string, n, singleChars int) int {
	if n <= 1 {
		return 1
	} else if 1 < singleChars {
		return 0
	}

	if sub[0] != sub[1] {
		return buildPalindrome(append(sub[1:], sub[0]), n-1, singleChars+1)
	}

	return buildPalindrome(sub[2:], n-2, singleChars)
}

*/