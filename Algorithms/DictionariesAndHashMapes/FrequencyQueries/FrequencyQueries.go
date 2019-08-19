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
	var q, oldFreq int64
	qtemp, _, _ := reader.ReadLine()
	q, _ = strconv.ParseInt(strings.TrimSpace(string(qtemp)), 10, 64)
	queries := make([][2]int64, q)
	for i := int64(0); i < q; i++ {
		qtemp, _, _ = reader.ReadLine()
		queriesTemp := strings.Split(strings.TrimRight(string(qtemp), " \t\r\n"), " ")
		queries[i][0], _ = strconv.ParseInt(queriesTemp[0], 10, 64)
		queries[i][1], _ = strconv.ParseInt(queriesTemp[1], 10, 64)
	}
	xyzMap := make(map[int64]int64)
	freqMap := make(map[int64]int64)

	for i := int64(0); i < q; i++ {
		action := queries[i][0]
		xyz := queries[i][1]
		if action == 3 {
			if val, ok := freqMap[xyz]; ok && 0 < val {
				fmt.Println(1)
			} else {
				fmt.Println(0)
			}
		} else {
			oldFreq = xyzMap[xyz]
			if action == 1 {
				xyzMap[xyz]++
			} else {
				if xyzMap[xyz]--; xyzMap[xyz] < 0 {
					delete(xyzMap, xyz)
				}
			}
			freqMap[xyzMap[xyz]]++
			if freqMap[oldFreq]--; freqMap[oldFreq] < 0 {
				delete(freqMap, oldFreq)
			}
		}
	}
}
