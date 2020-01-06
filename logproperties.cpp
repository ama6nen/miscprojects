// logproperties.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <cmath>
#include <cassert>
#include <conio.h>
//logbA = logcA/logcB
double log(double input, double base) {
	double numerator = log10(input);
	double denominator = log10(base);
	return (numerator / denominator);
}
int main()
{
	assert(log(300.42, 18.54) == (log10(300.42) / log10(18.54)));
	assert(log10(40*20) == (log10(40) + log10(20)));
	assert( (float)log10(40. / 20.) == (float)(log10(40.) - log10(20.))); //casting to float due to c++ loving going off in like the 959558th digit due to precision loss
	assert((float)log10(pow(4.5, 5)) == 5.0f * (float)log10(4.5)); //same as above
	assert(log(55, 4) == 1 / (log(4, 55)));
	printf("math has not broken down yet, logarithm properties hold up.\n");
	_getch();
}