
## Generar una apk universal

Desarrollo de ejemplos mvvm 
Integración con graphql


![Login](ejemplo_estadistica.gif)



## Nuget

AddHttpClient
Microsoft.Extensions.Http


## Generación token de prueba

```
curl -X POST https://localhost:7041/connect/token  -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=client_id"  -d "client_secret=secret"  -d "grant_type=password" -d "username=fernando" -d "password=1234" -d "scope=api1 offline_access"
```

###Ejemplos

Desde somee
```bash
C:\Users\fernando>curl -X POST https://geometriafernando.somee.com/connect/token  -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=client_id"  -d "client_secret=secret"  -d "grant_type=password" -d "username=fernando" -d "password=1234" -d "scope=api1 offline_access"
{"access_token":"eyJhbGciOiJSUzI1NiIsImtpZCI6Ijk2NzBBNDI5MTI2QjdFMzFCNDNGQzlFM0IzQ0VCOTY2IiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwczovL2dlb21ldHJpYWZlcm5hbmRvLnNvbWVlLmNvbSIsIm5iZiI6MTc3MTU1NTA0NiwiaWF0IjoxNzcxNTU1MDQ2LCJleHAiOjE3NzE1NTg2NDYsInNjb3BlIjpbImFwaTEiLCJvZmZsaW5lX2FjY2VzcyJdLCJhbXIiOlsicGFzc3dvcmQiXSwiY2xpZW50X2lkIjoiY2xpZW50X2lkIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTc3MTU1NTA0NiwiaWRwIjoibG9jYWwiLCJyb2xlIjoiQWRtaW4iLCJuYW1lIjoiZmVybmFuZG8iLCJqdGkiOiJFOTk2NjdFM0ZCNTIyN0JDOUY1MUJGQTZFNDg5ODNGNyJ9.CtDVBvToKZySR9LlE_ijJIGqMmRAs9qnjAuFI8OfHEWsMWO4tNi1SsKMvW9a9tbXISLBsqo9aWScVgr_s4szn0mVB5M23CigJzIknx-UeM2wfgYqyAHIK5Fn6zFdhxCmRZ8OO5p_23trc4M04pg0EMYUGQdw4CBXyzcIsEzGamXiMBuCeTmlihvmRPb3bAuj24qq0K-Hl1kzwO1Bm_7MMI3pqFbpBSxGb_mm6fbGcadz6xPZ3bIEgW0uNikl-JVQEU21PQa4qFLVGFWYtzZPASRtq1DF3a-AFdnE1_gnPx_tscpCoszpOwBZy-DdssBuw6MZzUc3ASRBydpGcwacDg","expires_in":3600,"token_type":"Bearer","refresh_token":"06B1F05D9A3268BA3E8AD5CD394DA0FE7BE529C6D398299407246C788855E0AC-1","scope":"api1 offline_access"}
```


# Autentificación

Una vez generado el token hay que agregar un parámetro en el HTTP 
Ejemplo

Authorization

![texto alternativo](ejemplo_consulta.png)