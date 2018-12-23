#include "Nativo.h"
#include <iostream>
#include <algorithm>


void GetStringMessage(char* str, int strlen) {
	std::string result = "Mensaje generado desde C++";

	result = result.substr(0, strlen);

	std::copy(result.begin(), result.end(), str);
	str[std::min(strlen - 1, (int)result.size())] = 0;
}

int Suma(int A, int B) {
    return A + B;
}