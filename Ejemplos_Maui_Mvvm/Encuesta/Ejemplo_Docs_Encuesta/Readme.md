
## Generar una apk universal

Desarrollo de ejemplos mvvm 
Integración con graphql


![Login](ejemplo_estadistica.gif)



## Nuget aplicación

```
Microsoft.Extensions.Http
CommunityToolkit.Mvvm
CommunityToolkit.Maui
```

## Nuget servicio web (graphql, restapi)

```
Duende.IdentityServer
dotnet add package HotChocolate.AspNetCore
HotChocolate.AspNetCore.Authorization
Microsoft.AspNetCore.Authentication.JwtBearer
Scalar.AspNetCore
```


## Generación token de prueba

```
curl -X POST https://geometriafernando.somee.com/connect/token  -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=client_id"  -d "client_secret=secret"  -d "grant_type=password" -d "username=fernando" -d "password=1234" -d "scope=api1"
```

###Ejemplos

Desde somee.com
observer que en scope solo dice api1, es el scope para las consultas graphql
```bash
C:\Users\fernando>curl -X POST https://geometriafernando.somee.com/connect/token  -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=client_id"  -d "client_secret=secret"  -d "grant_type=password" -d "username=fernando" -d "password=1234" -d "scope=api1"
{"access_token":"eyJhbGciOiJSUzI1NiIsImtpZCI6Ijk2NzBBNDI5MTI2QjdFMzFCNDNGQzlFM0IzQ0VCOTY2IiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwczovL2dlb21ldHJpYWZlcm5hbmRvLnNvbWVlLmNvbSIsIm5iZiI6MTc3MTU1ODU4MywiaWF0IjoxNzcxNTU4NTgzLCJleHAiOjE3NzE1NjIxODMsInNjb3BlIjpbImFwaTEiXSwiYW1yIjpbInBhc3N3b3JkIl0sImNsaWVudF9pZCI6ImNsaWVudF9pZCIsInN1YiI6IjEiLCJhdXRoX3RpbWUiOjE3NzE1NTg1ODMsImlkcCI6ImxvY2FsIiwicm9sZSI6IkFkbWluIiwibmFtZSI6ImZlcm5hbmRvIiwianRpIjoiNzc0QzUyNTNCMjcyNTMxMEREODM2OTlBMUQzMzNDNTUifQ.R3ixrcQuI-psNRJavj8bZrY5M6zCUzPKKHupWgG6_9SbOR27LW-CTaMmu5UQpIVNIVrMqN6Q7o1fdK-l1rGZPrsx_tMW0EE_uYVc6td2sgvVjIXjogAvQY3jb7ZjFyvRgZQ-2e6FXiTgjIx-kEiuHgvAItzDw72SWT8g-RXVEcowWg00h_h9EoX7DdrIEkp2ZQO3FNg8R5kiPYbG7Bb5BTc8L8FdEnf9Vp_gjfdmnFy4OA3J8UDJmwrd5JfPXL_nTio3A9cq6T6PnD2xCu1alYOLpwPOIC3_j-ZLvv07aLpMCjGUxLCJynd1SxHzHYepq5M3bqdxU2pxznufPHoQpA","expires_in":3600,"token_type":"Bearer","scope":"api1"}
```

Para loguerse y api
```bash
C:\Users\fernando>curl -X POST https://geometriafernando.somee.com  -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=client_id"  -d "client_secret=secret"  -d "grant_type=password" -d "username=fernando" -d "password=1234" -d "scope=api1 offline_access"
```


# Autentificación

Una vez generado el token hay que agregar un parámetro en el HTTP 
Ejemplo

Authorization

![texto alternativo](ejemplo_consulta.png)