package main

import (
	"fmt"
	"sort"
	"strconv"
	"strings"
)

func main() {
	var q int
	fmt.Scan(&q)
	for i := 0; i < q; i++ {
		var s string
		fmt.Scan(&s)
		printPairs(hashedDic(s))
	}
}

func hashedDic(str string) map[string]int {
	hashDic := make(map[string]int)
	// arrStr := strings.Split(str, "")
	for length := 1; length < len(str); length++ {
		for start := 0; start <= len(str)-length; start++ {
			hashCode := sortAndGenerateHash(str[start : start+length])
			if _, ok := hashDic[hashCode]; !ok {
				hashDic[hashCode] = 1
			} else {
				hashDic[hashCode]++
			}
		}
	}
	return hashDic
}

func sortAndGenerateHash(str string) string {
	arrStr := strings.Split(str, "")
	// charMap := make(map[])
	sort.Strings(arrStr)
	sortedStr := strings.Join(arrStr, "")
	var hash strings.Builder
	for sortedStr != "" {
		c := string(sortedStr[0])
		oldLen := len(sortedStr)
		sortedStr = strings.TrimLeft(sortedStr, c)
		newLen := strconv.Itoa(oldLen - len(sortedStr))
		hash.WriteString(c + newLen)
	}
	return hash.String()
}

func printPairs(hashDic map[string]int) {
	pairs := 0
	for _, count := range hashDic {
		pairs += count * (count - 1) / 2
	}
	fmt.Println(pairs)
}
