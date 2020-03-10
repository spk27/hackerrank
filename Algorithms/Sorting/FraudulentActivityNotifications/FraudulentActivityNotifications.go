package main

import (
	"fmt"
	"math"
)

func main() {
	var n, d, m1, m2, count int
	m, fract := 0.0, float64(2)
	fmt.Scan(&n)
	fmt.Scan(&d)
	i1 := int(math.Floor(float64(d-1) / fract))
	i2 := int(math.Ceil(float64(d-1) / fract))
	expenditures := make([]int, n)
	cs := make([]int, 201)
	for i := 0; i < n; i++ {
		fmt.Scan(&expenditures[i])
	}
	for i := 0; i < d; i++ {
		cs[expenditures[i]]++
	}
	for i := d; i < n; i++ {
		for j, k := 0, 0; k <= i1; k, j = k+cs[j], j+1 {
			m1 = j
		}
		for j, k := 0, 0; k <= i2; k, j = k+cs[j], j+1 {
			m2 = j
		}
		m = float64(m1+m2) / fract
		if m*fract <= float64(expenditures[i]) {
			count++
		}
		cs[expenditures[i]]++
		cs[expenditures[i-d]]--
	}
	fmt.Println(count)
}
