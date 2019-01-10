#pragma once

//Utilizamos directivas de preprocesado para definir la macro de la API
//Esto hay que hacerlo porque en Windows y en NoWindows se declaran diferente
#ifdef _WIN32
#  ifdef MODULE_API_EXPORTS
#    define MODULE_API extern "C" __declspec(dllexport) 
#  else
#    define MODULE_API extern "C" __declspec(dllimport)
#  endif
#else
#  define MODULE_API extern "C"
#endif
//Declaracion de los métodos nativos
MODULE_API void GetStringMessage(char *str, int strsize);

MODULE_API int Suma(int a, int b);