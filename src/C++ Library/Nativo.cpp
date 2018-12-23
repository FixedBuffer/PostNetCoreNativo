#include "Nativo.h"
#include <iostream>
#include <algorithm>


void GetStringMessage(char* str, int strlen) {
	//Definimos el mensaje
	std::string result = "Mensaje generado desde C++";
	//Cortamos lo que sobre si el buffer que nos pasan es pequeño
	result = result.substr(0, strlen);
	//Copiamos el mensaje en el buffer de salida
	std::copy(result.begin(), result.end(), str);
	//Colocamos un '\0' en la ultima posición, ya que es el delimitador de strings nativas
	str[std::min(strlen - 1, (int)result.size())] = '\0';
}

int Suma(int A, int B) {
	return A + B;
}