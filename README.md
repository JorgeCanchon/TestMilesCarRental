# TestMilesCarRental
WebApi buscador vehiculos para la renta

Configuracion MySQL And Docker
---
Descargar imagen mysql 
```shell
docker pull mysql
```

# Plain docker
```shell
docker run -d --rm --name mysqlc -p 3306:3306 -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=milescarrental -v mysql_data:/var/lib/mysql mysql:latest
```
Conectarse a la instancia de mysql del container

```shell
docker exec -it mysqlc mysql -u root -p'root'
```

# Docker Compose

```shell
docker-compose up -d
```

see [docker-compose.yaml](./docker-compose.yaml)

Conectarse a la instancia de mysql

```shell
docker exec -it [name] mysql -u umilescarrental -p'pmilescarrental'
```


