# Documentaci�n de la Estructura del Proyecto
## Consigna
En este proyecto, se desarrollar� un sistema de detecci�n de fraude que utiliza datos de pagos y usuarios. 
1. Nuevo usuario (< 7 d�as desde el registro).
2. Cantidad de pagos rechazados en el �ltimo d�a.
3. Monto acumulado total (en usd) de pagos por usuario en la �ltima semana.
Adem�s, se proporcionar� una API REST para acceder a esta informaci�n.

## Estructura de la Base de Datos

Para lograr este objetivo, se propondr� la siguiente estructura de tabla:

### Tabla de Pagos

- `id del pago` (identificador �nico del pago)
- `id del usuario` (identificador �nico del usuario que realiz� el pago)
- `pa�s` (pa�s del usuario)
- `moneda local` (moneda local utilizada en el pago)
- `total en moneda local` (monto total del pago en la moneda local)
- `fecha del pago` (fecha en que se realiz� el pago)
- `estado del pago` (estado actual del pago)

### Tabla de Usuarios

- `id del usuario` (identificador �nico del usuario)
- `fecha creaci�n de la cuenta` (fecha en que se registr� el usuario)

## API REST

Se construir� una API REST que proporcionar� los siguientes datos en formato JSON:

```json
{
  "IsNewId": bool,
  "RejectedPaymentsQuantityLastDay": double,
  "TotalAmmountLastWeek": double
}
```
## Descripci�n

Esta documentaci�n proporciona una visi�n general de la estructura del proyecto "Challenge". El proyecto se compone de varios m�dulos que trabajan juntos para construir una aplicaci�n completa.

## M�dulos

### Challenge.API

- **Descripci�n**: Este m�dulo es la interfaz principal de la aplicaci�n. Proporciona puntos de entrada para interactuar con la aplicaci�n a trav�s de API REST.
    - **Finalidad de los controlardores**:
        - **MockUp**: Tiene un unico endpoint con la finalidad de inizializar la base de datos
        - **User**: Acciones CRUD para poder probar la validacion
        - **Payment**: Acciones CRUD para poder probar la validacion
        - **Riskment**: Contiene el endpoint correspondiente a la validacion de un usuario en base a las reglas definidas. 

### Challenge.Data

- **Descripci�n**: El m�dulo Challenge.Data se encarga de la capa de acceso a datos de la aplicaci�n. Contiene configuraciones de Entity Framework para la base de datos.
    - **Contenido**:
        - **Migraciones**: Contiene el codigo que ejecuta en la base de datos las migraciones necesarias para el funcionamiento del ORM
        - **ChallengeContext**: Es la clase principal con la que gestinomamos los accesos a la base de datos, esta misma es la principal encargada de la comunicacion entre la base de datos y la aplicacion.
### Challenge.ExternalServices

- **Descripci�n**: Este m�dulo contiene el acceso a servicios externos o integraciones de terceros, como APIs externas.
    - **Contenido**:
      - **CurrencyConverter**: Contiene la llamada a una api externa a traves de la herrmaiente ```WebRequestAdapter``` para traer el valor de la moneda a cambiar.

### Challenge.Service

- **Descripci�n**: Challenge.Service es el n�cleo de la aplicaci�n. Contiene la l�gica empresarial y servicios de la aplicaci�n.
    - **Contenido**:
      - **Servicios**: Se aplica la logica de negocios y se ejecutan los comandos de base de datos a traves dentro de la misma capa.
      - **Interfaces**: Proporciona el acceso a los controladores y a los test, al servicio.
### Challenge.Shared

- **Descripci�n**: Este m�dulo almacena c�digo compartido que puede ser utilizado por otros m�dulos de la aplicaci�n. Puede contener utilidades, clases de utilidad y definiciones comunes asi como los modelos de datos.
    - **Contenido**:
        - **DTOs**: Siendo estos los modelos de entrada y salida con la estructura necesaria para aplicar la logica de negocio.
        - **MockUpData**: Es el manejador del endpoint para generar data para la base de datos.
        - **Models**: Son la representacion de los modelos que voy a utilizar en mi base de datos.
        - **PolyEnums**: Estructuras de datos para referenciar en el proyecto datos innecesarios de almacenar en la base de datos para aumentar la performance reduciendo la cantidad de accesos a la misma.
### Challenge.ToolKit

- **Descripci�n**: Challenge.ToolKit es un conjunto de herramientas y utilidades que pueden ser �tiles en toda la aplicaci�n.
    - **Contenido**: 
        - **WebRequestAdapter**: Es el manejador Http para poder realizar llamadas con la implementacion de un get, tanto con headers como sin headers.
### Challenge.Tests

- **Descripci�n**: Este m�dulo contiene pruebas unitarias y de integraci�n para validar el funcionamiento de los diferentes componentes de la aplicaci�n.
    - **Contenido**
        -**RiskMentShuold**: Es la prueba unitaria que valida los tres campos solicitados por el endpoint ```api/Riskment/User/{id}```
