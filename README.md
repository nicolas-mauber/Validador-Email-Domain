# Validador-Email-Domain

Este programa sirve para validar dominios de email. El mismo funciona de dos maneras. El primer metodo utiliza procesos.
Estos ejecutan en una consola el comando de nslok up que valida dominios. el mismo captura la respuesta y devuelve true o false.

La otra forma se ejecuta en el caso de que la consola no se puda ejecutar por cualquier motivo. 
Este metodo consta de la llamada a una api, capturando su respuesta en formato JSON y validando el dominio ingresado.
