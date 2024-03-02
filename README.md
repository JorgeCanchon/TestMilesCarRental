# TestMilesCarRental
WebApi con la funcionalidad para buscar vehiculos disponibles para su renta
---

# Ejecutar proyecto

Escriba el siguiente comando en un CLI para ejecutar el docker-compose.yml en la carpeta raiz del proyecto  \TestMilesCarRental

```shell
docker-compose up -d
```

Una vez descargue y esten listos los contenedores ejecute el siguiente comando para ver los contenedores

```shell
docker ps 
```
Con esto abrá instalado un contenedor con MySQL

---

# Crear Tablas DB

Para crear las tablas de la base de datos vamos a usar migrations.
Vamos acceder a la siguiente ruta desde una consola: 

- \TestMilesCarRental\MilesCarRental.Infrastructure

Luego ejecutamos el siguiente comando para restaurar la migracion.

```shell
dotnet ef --startup-project ../milescarrental.api/ database update
```

Conectarse a la instancia de mysql

Para conectarse a la instancia de MySql desde el CLI ejecute el siguiente comando:

```shell
docker exec -it [name] mysql -u umilescarrental -p'pmilescarrental'
```
Abra la solucion y ejecute el proyecto con el IIS Express

![image](https://github.com/JorgeCanchon/TestMilesCarRental/assets/20799377/fcd4fc04-e8eb-4556-a833-c356b6deea01)

---

# Accediendo a la Documentacion Swagger del API

Acceda al api por la siguiente URL:

[https://localhost:50825/swagger/index.html](https://localhost:44391/swagger/index.html)

see [docker-compose.yaml](./docker-compose.yaml)

---
# Insercion Data Prueba

Al correr el API encontramos este endpoint tipo POST para insertar data inicial para pruebas.

![image](https://github.com/JorgeCanchon/TestMilesCarRental/assets/20799377/91536a7a-edd9-495d-9da3-9c750ba4c55d)

Adicional entontramos este método para obtener laos vehiculos disponibles por localidad

![image](https://github.com/JorgeCanchon/TestMilesCarRental/assets/20799377/ba7a6939-df7c-456a-a5a7-49fe47b5871f)

# Test de integración y Test unitarios

