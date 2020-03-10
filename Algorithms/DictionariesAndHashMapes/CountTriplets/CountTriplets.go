package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	reader := bufio.NewReader(os.Stdin)
	str, _, _ := reader.ReadLine()
	nr := strings.Split(strings.TrimSpace(string(str)), " ")
	r, _ := strconv.ParseInt(nr[1], 10, 64)
	strarr, _, _ := reader.ReadLine()
	arr := strings.Split(strings.TrimSpace(string(strarr)), " ")
	firstOnSeq := make(map[int64]uint64)
	secondOnSeq := make(map[int64]uint64)
	var triplets uint64
	for _, as := range arr {
		a, _ := strconv.ParseInt(as, 10, 64)
		if a%r == 0 {
			ar := a / r
			if _, ok := secondOnSeq[ar]; ok {
				triplets += secondOnSeq[ar]
			}
			if _, ok := firstOnSeq[ar]; ok {
				secondOnSeq[a] += firstOnSeq[ar]
			}
		}
		firstOnSeq[a]++
	}
	fmt.Println(triplets)
}
