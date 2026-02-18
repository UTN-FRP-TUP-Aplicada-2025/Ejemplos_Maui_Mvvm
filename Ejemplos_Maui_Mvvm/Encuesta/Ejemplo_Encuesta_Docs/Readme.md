
## Generar una apk universal

Desarrollo de ejemplos mvvm 
Integración con graphql



# Generación token de prueba

```
curl -X POST https://localhost:7041/connect/token  -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=maui-client"  -d "client_secret=secret"  -d "grant_type=password" -d "username=fernando" -d "password=1234" -d "scope=api1"
```

Ejemplos

```bash
C:\Users\fernando>curl -X POST https://localhost:7041/connect/token  -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=maui-client"  -d "client_secret=secret"  -d "grant_type=password" -d "username=fernando" -d "password=1234" -d "scope=api1"
{"access_token":"eyJhbGciOiJSUzI1NiIsImtpZCI6IjI0QTMyQjRDRENDMkZGOTZBRDlBQTJFREU2REFGMjJDIiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDQxIiwibmJmIjoxNzcxNDE3MTE0LCJpYXQiOjE3NzE0MTcxMTQsImV4cCI6MTc3MTQyMDcxNCwic2NvcGUiOlsiYXBpMSJdLCJhbXIiOlsicGFzc3dvcmQiXSwiY2xpZW50X2lkIjoibWF1aS1jbGllbnQiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzcxNDE3MTE0LCJpZHAiOiJsb2NhbCIsImp0aSI6IjRGM0M0NTFCOTM0RkIxNEMwMzg0NkQ4NDQ0NjEwNjc2In0.ZxJQcAhxAB7kIEvuVyxj-H_B8iVvcpXx44qEd92vxwQzIrAMDGAhbggoeXx1lCZudnSlZ5PYLjIuipBcw-GUX7WlkO0aIV_9mVEQ2rRacay_pLRO9Ivw8fx3Md7cCW9c_kcqvtrgIptWbM4BFtMdNX4Ja6-VMgtmmZd_kcJ185oIx4_mQIYm4w7SwXfKCHGzQhWApbFOharzMFYwj1qAMR10pX4rlgtkCoFJhrXV1fqfeFeS-ADYS-y0zOTyqUYrFgfcalM3_QdhHTvhaMrr88d042UdaDAjgiazpGzMxErloT9p5MQDuhByP9XLhPy2HpTazNwIZX2hHtBXyyE7MQ","expires_in":3600,"token_type":"Bearer","scope":"api1"}

C:\Users\fernando>curl -X POST https://localhost:7041/connect/token  -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=maui-client"  -d "client_secret=secret"  -d "grant_type=password" -d "username=fernando" -d "password=1234" -d "scope=api1"
{"access_token":"eyJhbGciOiJSUzI1NiIsImtpZCI6IjI0QTMyQjRDRENDMkZGOTZBRDlBQTJFREU2REFGMjJDIiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDQxIiwibmJmIjoxNzcxNDM2NzU5LCJpYXQiOjE3NzE0MzY3NTksImV4cCI6MTc3MTQ0MDM1OSwic2NvcGUiOlsiYXBpMSJdLCJhbXIiOlsicGFzc3dvcmQiXSwiY2xpZW50X2lkIjoibWF1aS1jbGllbnQiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzcxNDM2NzU5LCJpZHAiOiJsb2NhbCIsImp0aSI6IkNGMzA0RkQxNjQ3M0M3MTA0NkM5M0YxRjVCOERFQzY0In0.UFoiqdTx-V6H_Z8VXH4XZUO4PSIoxBT9CD1_BQb0vGvi3_-vwE5PAFtrbga61d3TLSmkOaWd9eWad2whKTUcs5EIWmcLpLGaFbCcP0UabtPvFHKts2If-MC-HjxtaGQcnP2QlVe_5BrSNyjeEun7PAx2zS8l2dWp9DAn0vbZJkdsjfFtjZMauBOnPttLqzUIxq9vuvwinNoKYJa0dTMAEH7saRSpz97FFbV5n4YWoF2fzw50pnsdxFx21wK3Ps2gyjsu1T1nbdehhqQ4cBaqg_QMJcmILPtRGErAz-F8arEJtoBrlPrLPO11E3TU2oWgJi4eO1qFNSa0Dt-xfOEjng","expires_in":3600,"token_type":"Bearer","scope":"api1"}
C:\Users\fernando>

C:\Users\fernando>curl -X POST https://geometriafernando.somee.com/connect/token  -H "Content-Type: application/x-www-form-urlencoded"  -d "client_id=maui-client"  -d "client_secret=secret"  -d "grant_type=password" -d "username=fernando" -d "password=1234" -d "scope=api1"
{"access_token":"eyJhbGciOiJSUzI1NiIsImtpZCI6IkRGRTU2QzQwMEJEOUM0Q0NGNDkzNDI5NjUzRTk4OUY5IiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwczovL2dlb21ldHJpYWZlcm5hbmRvLnNvbWVlLmNvbSIsIm5iZiI6MTc3MTQzOTY4MSwiaWF0IjoxNzcxNDM5NjgxLCJleHAiOjE3NzE0NDMyODEsInNjb3BlIjpbImFwaTEiXSwiYW1yIjpbInBhc3N3b3JkIl0sImNsaWVudF9pZCI6Im1hdWktY2xpZW50Iiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTc3MTQzOTY4MSwiaWRwIjoibG9jYWwiLCJqdGkiOiJGQkIwMzdCQkVGODc1QkQyRjc2NDlCQTE1MjJBMzYwMCJ9.DFQ56HaUpq-EOB0fUW3LwojAd7UV_WrKWCowdlqKeX6Lop0YvXMWB9BYhUXDfss0wMudUNhAb1wP8l5kJH4OX2ivE08jFgOKG6xkvWMJc0I6OlbSlfjosx3YLZAgyT0kAQMRW3At6lxRhX-x2QAeVQw03Wpnd-KypyfmxsP7zV0v5mnTBuD6MKNREGvWDz8kvRs2lVT7_e6DIjDMR5wEH1YrY__h0M0WBfDDG5XQRSxsY2h0sEsJXvwoHKhlzP0ibdOigDwCcodFjPKrxJE-jJFC5BBNK9fhp1eOoU-i0BLP1FN2qHqeti8IA-l3kea5QF6tbRC0eJ2pjRt38Ia60w","expires_in":3600,"token_type":"Bearer","scope":"api1"}
```


# Autentificación

Una vez generado el token hay que agregar un parámetro en el HTTP 
Ejemplo

Authorization

![texto alternativo](ejemplo_consulta.png)