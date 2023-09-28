# MELI.CHALLENGE
# Instrucciones para ejecutar el contenedor en local
Este repositorio contiene un contenedor Docker que ejecuta una aplicación web. Siga las instrucciones a continuación para ejecutar el contenedor en su máquina local.

## Requisitos previos
Asegúrese de tener Docker instalado en su máquina. Puede descargar e instalar Docker desde [el sitio web oficial de Docker](https://www.docker.com/get-started).

## Pasos para ejecutar el container
1. Clonar el repositorio ```git clone https://github.com/tanituc/MELI.CHALLENGE.git```
2. ```cd MELI.CHALLENGE```
3. ```docker-compose build```
4. ```docker-compose up```
5. Ya puede acceder a http://localhost:5172/swagger/index.html

## Flujo de trabajo
1. Generar datos, se puede hacer manual generando un usuario y generando los pagos asociados al usuario haciendo uso de los endpoints de ```POST``` de las api ```User``` y ```Payment``` , o se puede generar a travez del endpoint ```GET``` de la api ```MockUp```
2. Obtener el ```Id``` de un usuario puede ser traido del endpoint ```GET: /api/User```y utilizar el endpoint ```GET: /api/Riskment/User/{id}``` 

## Documentacion extra 
[Acceder a la documentacion](https://github.com/tanituc/MELI.CHALLENGE/blob/main/Documentation.md)
