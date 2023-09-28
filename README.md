# MELI.CHALLENGE
# Instrucciones para ejecutar el contenedor en local
Este repositorio contiene un contenedor Docker que ejecuta una aplicación web. Siga las instrucciones a continuación para ejecutar el contenedor en su máquina local.

## Requisitos previos
Asegúrese de tener Docker instalado en su máquina. Puede descargar e instalar Docker desde [el sitio web oficial de Docker](https://www.docker.com/get-started).
Asegúrese de tener DBeaver instalado o algun manejador de base de datos a eleccion. Puede descargar e instalar DBeaver desde [el sitio oficial de DBeaver](https://dbeaver.io/download/).

## Pasos a ejecutar el container
1. Clonar el repositorio ```git clone https://github.com/tanituc/MELI.CHALLENGE.git```
2. ```cd MELI.CHALLENGE```
3. ```docker-compose build```
4. ```docker-compose up```
5. Ejecutar los scripts de la carpeta SQL atravez de DBeaver:
	1. Clickear en New Data Base Connection
	2. Seleccionar la opcion SQLServer y presionar el boton de Siguiente
	3. En el casillero Host colocar tu ip local, en el casillero Port deberia ir el valor ```1433```, user deberia ser ```sa``` y la contraseña ```Challenge2023```y presionar el boton de OK
	4. Click derecho sobre la conexion > SQL Editor > New SQL Script
	5. Pegar el contenido de los scripts de la carpeta ```MELI.CHALLENGE\SQL``` y ejecutarlos en orden en base al prefijo con ```ALT + X```
6. Ya puede acceder a http://localhost:5172/swagger/index.html
