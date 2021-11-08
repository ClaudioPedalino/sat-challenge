## SAT Recruitment
El objetivo de esta prueba es refactorizar el código de este proyecto.
Se puede realizar cualquier cambio que considere necesario en el código y en los test.

#### Requisitos 
- Todos los test deben pasar.
- El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
- El código resultante debe ser mantenible y extensible.
---
# Claudio Pedalino Challenge
#### Urls:


- Acá dejo una demostración que complementa o reemplaza a la documentación escrita :) - [[Ver Demo]](https://drive.google.com/file/d/1OHIynEADrbFz_UBEOvZ4Re1PSlt_sJJo/view?usp=sharing)
- Acá se puede ver swagger de la api publicada - [Swagger Api Documentantion](http://www.cpedalino-sat-challenge.somee.com/swagger)
- Acá se puede encontrar la collection de postman correspondiente - [Postman collection](https://www.getpostman.com/collections/4c920539e1abef63c994)
- Acá se puede ver el frontend aunque sigo trabajando en él, no está terminado - [Frontend UI](https://sat-challenge.bubbleapps.io/version-test)

#### Resumen
Entiendo que el ejercicio principalmente busca ver si se entiende los principios básicos de separación de responsabilidades y poder escribir un código entendible y mantenible, 
Sin embargo le agregué algunas funcionalidades no requeridas en el enunciado para intentar dar una mejor impresión

## Refactor - Arquitectura y librerías
Se organiza la solución utilizando Clean Architecture y CRQS
---- Los query endpoints (es decir, solo lectura) requieren una **api key** para funcionar, que es "let-me-pass", la misma ya está en la collection de postman para facilitar las pruebas.
---- Los command endpoints tienen autenticación, por lo que será necesario incluir un **access-token**, que se puede obtener tanto haciendo un 'login' con el endpoint correspondiente, la base de datos ya tiene un usuario que dejo como admin para hacer las pruebas; o mismo se puede utilizar el endpoint de 'register' para dar de alta un usuario nuevo y obtener un token de acceso

#### Se utilizaron las siguientes librerias y patrones:
- **Mediatr** para implementar el patrón de mediador y lograr unidireccionalidad en la api, de esta misma librería se utilizan también sus otros 2 features: los **pipeline behaviours** para implementar una **cache** en memoria, e implementar **transaccionabilidad** de los comandos de escritura implementando unit of work, También se aprovecha la librería de mediatr para utilizar su método **publish** y comunicar eventos de dominio, en este caso, solo imprimiendo en consola el evento ocurrido
- **EFCore**, se utiliza **code-first** y una base de datos **sql-server**, las migraciones ya se encuentran aplicadas en el entorno publicado, también se realizan algunos ajustes de **auditoria** en las entridades correspondientes y filtros por defecto para evitar consumir registros eliminados, ya que no se implementó una baja real sino **baja lógica** marcando como "borrado" los registros en la base de datos
- **Swagger** para la documentación de los endpoints, configurando la posibilidad de ingresar el header de autorización necesario y el header de api-key necesario
- Se integró la librería de **Automapper** para el mapeo entre entidades y modelos de sistema
- Se implementó un paginado y filtro en la consulta general
- Se integró la librería de **FluentValidation** para la validación de parámetros de objetos de entrada en endpoints necesarios
- Se integró la librería de **Serliog** para manejo de logs, aunque solo escriben en consola actualmente
- Se integró la librería de **MiniProfiler** para tener visualización de un perfilado de los llamados a la api
- Se integró la librería de **Health-checks** para tener una rápida visualización del estado de los servicios/dependencias de interés
- Se integró la librería de **Rate Limit** para poder limitar la cantidad de llamadas por ip a con diferentes politicas según rutas y tiempos de consulta
- Se deja collection de **postman** para poder probar de una manera sencilla y algunos test de generación de usuario usando el testing de postman
- Se utiliza  la librería de **NBomber** para **pruebas de carga**
- Se utiliza la librería de **K6** para **pruebas de stress**

#### **Testing Unitario**
Dejé 40 Test Unitarios, están corriendo, pero solo testeo la funcionalidad original, que es la de crear un usuario, todo aquello que agregué por mi cuenta no le escribí los test porque me llevaba bastante tiempo y bueno, creo que con lo hecho sería suficiente

#### **Testing de Stress**
Dejé un proyecto de Test de stress utilizando la herramienta de k6. 
Para reproducirlo:
1) Poner a correr la api con el ejecutable que se encuentra en la carpeta:   **/_utils/start-api.bat**
2) Ejecutar los test de stress con el ejecutable en la carpeta: **/Sat.Recruitment.StressTesting/run-k6-stress-test.bat**

El primer ejecutable levanta la api en el puerto 7000 y el segundo ejecutable pone a ejecutar el archivo '*k6-stress-test.js*' que tiene escritas consultas incrementales y secuenciales a la api. Al terminar de ejecutar los test vamos a ecnontrar en consola los resultados de la prueba.

#### **Testing de Carga**
Utilicé la librería de **NBomber** para ejecutar load testing,  
Para reproducirlo:
1) Poner a correr la api con el ejecutable que se encuentra en la carpeta:   **/_utils/start-api.bat**
2) Ejecutar los test de carga con el ejecutable en la carpeta: **/Sat.Recruitment.LoadTesting/run-load-testing.bat**

El primer ejecutable levanta la api en el puerto 7000 y el segundo ejecutable pone a ejecutar el proyecto de consola con net core que utiliza la librería de nbomber, Al finalizar la ejecución nos da los resultados en consola y también guarda una copia con un formato más lindo en la carpeta "reports", por ejemplo, visualizar el html

#### **Testing de Postman**
En la collection de postman dejé una carpeta *"Test"* donde pueden ejecutar el runner para verificar que siga funcionando correctamente, en este caso solo hice la integración del feature de login y register de usuarios

#### **Mini Profiler**
- Lista de request recibidos => https://localhost:7000/profiler/results-index

#### **Health checks**
- UI => https://localhost:7000/healthchecks-ui#/healthchecks
- Service => https://localhost:7000/health