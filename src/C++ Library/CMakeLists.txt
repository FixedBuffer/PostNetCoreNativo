# Configure our Required Version
cmake_minimum_required(VERSION 3.0)

project(EjemploNativo)

add_library(EjemploNativo SHARED Nativo.cpp Nativo.h)
set_target_properties(EjemploNativo PROPERTIES PREFIX "")
set_target_properties(EjemploNativo PROPERTIES OUTPUT_NAME EjemploNativo)
# Para uniformizar el acceso desde NetCore, defino todo como .dll
#set_target_properties(EjemploNativo PROPERTIES SUFFIX ".dll")