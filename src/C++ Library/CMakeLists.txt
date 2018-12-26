# Version mínima de CMake
cmake_minimum_required(VERSION 3.0)
#Nombre del proyecto
project(EjemploNativo)
#Añadimos los ficheros y le decimos que sera una librería compartida
add_library(EjemploNativo SHARED Nativo.cpp Nativo.h)
#Quitamos los prefijos (esto quita el "lib" que añade)
set_target_properties(EjemploNativo PROPERTIES PREFIX "")
#Indicamos el nombre de la salida
set_target_properties(EjemploNativo PROPERTIES OUTPUT_NAME EjemploNativo)