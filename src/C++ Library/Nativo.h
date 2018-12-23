#ifdef __cplusplus
extern "C" {
#endif

//Utilizamos directivas de preprocesado para definir la macro de la API
//Esto hay que hacerlo porque en Windows y en NoWindows se declaran diferente

#ifdef _WIN32
#  ifdef MODULE_API_EXPORTS
#    define MODULE_API __declspec(dllexport) 
#  else
#    define MODULE_API __declspec(dllimport)
#  endif
#else
#  define MODULE_API
#endif

//Declaracion de los métodos nativos
MODULE_API void GetStringMessage(char* str, int strlen);

MODULE_API int Suma(int A, int B);

#ifdef __cplusplus
}
#endif