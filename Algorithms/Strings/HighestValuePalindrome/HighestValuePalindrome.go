package main

import (
	"fmt"
	"strings"
)

var n int

func main() {
	var kChances int
	var s string
	fmt.Scan(&n)
	fmt.Scan(&kChances)
	fmt.Scan(&s)
	cProblems, state := howManyProblems(s, n)
	if kChances < cProblems {
		fmt.Println("-1")
	} else {
		sSlice := strings.Split(s, "")
		if remainingChanges := recursiveChanges(sSlice, state, kChances, 0, cProblems); 0 < remainingChanges {
			changeMiddle(sSlice)
		}
		fmt.Println(strings.Join(sSlice, ""))
	}
}

func howManyProblems(s string, n int) (int, []bool) {
	var c int
	state := make([]bool, n/2)
	for i := 0; i < n/2; i++ {
		if s[i] == s[(n-1)-i] {
			state[i] = true
		} else {
			c++
		}
	}
	return c, state
}

func recursiveChanges(s []string, state []bool, kChances, i, cProblems int) int {
	if kChances < 1 || i == n/2 {
		return kChances
	} else if !state[i] || cProblems < kChances {
		switch {
		case kChances == cProblems:
			{
				return recursiveChanges(s, state, kChances-changeOneLower(s, i), i+1, cProblems-1)
			}
		case cProblems < kChances:
			{
				if 1 < kChances {
					if !state[i] {
						cProblems = cProblems - 1
					}
					return recursiveChanges(s, state, kChances-changePair(s, i), i+1, cProblems)
				}

				return kChances - changeOneLower(s, i)
			}
		}
	}
	return recursiveChanges(s, state, kChances, i+1, cProblems)
}

func changeOneLower(s []string, i int) int {
	if left, right := s[i], s[(n-1)-i]; left < right {
		s[i] = s[(n-1)-i]
		return 1
	} else if right < left {
		s[(n-1)-i] = s[i]
		return 1
	}
	return 0
}

func changePair(s []string, i int) int {
	if left, right := s[i], s[(n-1)-i]; left == "9" && right == "9" {
		return 0
	} else if left == "9" || right == "9" {
		s[i], s[(n-1)-i] = "9", "9"
		return 1
	}
	s[i], s[(n-1)-i] = "9", "9"
	return 2
}

func changeMiddle(s []string) {
	if n%2 == 1 {
		s[n/2] = "9"
	}
}
