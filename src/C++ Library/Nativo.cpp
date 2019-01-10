#include "Nativo.h"
#include <iostream>
#include <algorithm>

void GetStringMessage(char* str, int strsize) {
	//Comprobamos que el tamaño del buffer que nos indican en mayor que 0
	if(strsize > 0) {
		//Definimos el mensaje
		const char result[] = "Mensaje generado desde C++";
		//Obtenemos cual va a ser la longitud maxima que podemos utilizar
		const auto size = std::min<int>(sizeof(result), strsize) - 1;
		//Compiamos al buffer la cadena
		std::copy(result, result + size, str);
		//Indicamos el final de cadena
		str[size] = '\0';
  }	
}

int Suma(int a, int b) {
	return a + b;
}