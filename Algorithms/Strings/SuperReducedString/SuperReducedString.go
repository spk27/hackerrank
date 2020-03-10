package main

import (
	"fmt"
)

func main() {
	var s string
	fmt.Scan(&s)
	if result := reduce(s, len(s)); result == "" {
		fmt.Println("Empty String")
	} else { fmt.Println(result) }
}

func reduce(s string, n int) string {
	switch {
	case n < 2: return s
	case s[0] == s[1]: return reduce(s[2:], n-2)
	case s[0] != s[1]:
		ss := string(s[0]) + reduce(s[1:], n-1)
		if s == ss { return s }
		return reduce(ss, len(ss))
	default: return s
	}
}
