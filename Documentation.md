# Documentación de la Estructura del Proyecto
## Consigna
En este proyecto, se desarrollará un sistema de detección de fraude que utiliza datos de pagos y usuarios. 
1. Nuevo usuario (< 7 días desde el registro).
2. Cantidad de pagos rechazados en el último día.
3. Monto acumulado total (en usd) de pagos por usuario en la última semana.
Además, se proporcionará una API REST para acceder a esta información.

## Estructura de la Base de Datos

Para lograr este objetivo, se propondrá la siguiente estructura de tabla:

### Tabla de Pagos

- `id del pago` (identificador único del pago)
- `id del usuario` (identificador único del usuario que realizó el pago)
- `país` (país del usuario)
- `moneda local` (moneda local utilizada en el pago)
- `total en moneda local` (monto total del pago en la moneda local)
- `fecha del pago` (fecha en que se realizó el pago)
- `estado del pago` (estado actual del pago)

### Tabla de Usuarios

- `id del usuario` (identificador único del usuario)
- `fecha creación de la cuenta` (fecha en que se registró el usuario)

## API REST

Se construirá una API REST que proporcionará los siguientes datos en formato JSON:

```json
{
  "IsNewId": bool,
  "RejectedPaymentsQuantityLastDay": double,
  "TotalAmmountLastWeek": double
}
```
## Descripción

Esta documentación proporciona una visión general de la estructura del proyecto "Challenge". El proyecto se compone de varios módulos que trabajan juntos para construir una aplicación completa.

## Módulos

### Challenge.API

- **Descripción**: Este módulo es la interfaz principal de la aplicación. Proporciona puntos de entrada para interactuar con la aplicación a través de API REST.
    - **Finalidad de los controlardores**:
        - **MockUp**: Tiene un unico endpoint con la finalidad de inizializar la base de datos
        - **User**: Acciones CRUD para poder probar la validacion
        - **Payment**: Acciones CRUD para poder probar la validacion
        - **Riskment**: Contiene el endpoint correspondiente a la validacion de un usuario en base a las reglas definidas. 

### Challenge.Data

- **Descripción**: El módulo Challenge.Data se encarga de la capa de acceso a datos de la aplicación. Contiene configuraciones de Entity Framework para la base de datos.
    - **Contenido**:
        - **Migraciones**: Contiene el codigo que ejecuta en la base de datos las migraciones necesarias para el funcionamiento del ORM
        - **ChallengeContext**: Es la clase principal con la que gestinomamos los accesos a la base de datos, esta misma es la principal encargada de la comunicacion entre la base de datos y la aplicacion.
### Challenge.ExternalServices

- **Descripción**: Este módulo contiene el acceso a servicios externos o integraciones de terceros, como APIs externas.
    - **Contenido**:
      - **CurrencyConverter**: Contiene la llamada a una api externa a traves de la herrmaiente ```WebRequestAdapter``` para traer el valor de la moneda a cambiar.

### Challenge.Service

- **Descripción**: Challenge.Service es el núcleo de la aplicación. Contiene la lógica empresarial y servicios de la aplicación.
    - **Contenido**:
      - **Servicios**: Se aplica la logica de negocios y se ejecutan los comandos de base de datos a traves dentro de la misma capa.
      - **Interfaces**: Proporciona el acceso a los controladores y a los test, al servicio.
### Challenge.Shared

- **Descripción**: Este módulo almacena código compartido que puede ser utilizado por otros módulos de la aplicación. Puede contener utilidades, clases de utilidad y definiciones comunes asi como los modelos de datos.
    - **Contenido**:
        - **DTOs**: Siendo estos los modelos de entrada y salida con la estructura necesaria para aplicar la logica de negocio.
        - **MockUpData**: Es el manejador del endpoint para generar data para la base de datos.
        - **Models**: Son la representacion de los modelos que voy a utilizar en mi base de datos.
        - **PolyEnums**: Estructuras de datos para referenciar en el proyecto datos innecesarios de almacenar en la base de datos para aumentar la performance reduciendo la cantidad de accesos a la misma.
### Challenge.ToolKit

- **Descripción**: Challenge.ToolKit es un conjunto de herramientas y utilidades que pueden ser útiles en toda la aplicación.
    - **Contenido**: 
        - **WebRequestAdapter**: Es el manejador Http para poder realizar llamadas con la implementacion de un get, tanto con headers como sin headers.
### Challenge.Tests

- **Descripción**: Este módulo contiene pruebas unitarias y de integración para validar el funcionamiento de los diferentes componentes de la aplicación.
    - **Contenido**
        -**RiskMentShuold**: Es la prueba unitaria que valida los tres campos solicitados por el endpoint ```api/Riskment/User/{id}```
