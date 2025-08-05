# Sistema de Votaciones - API RESTful

Esta API permite gestionar un sistema de votaci�n simple, con funcionalidades para registrar votantes, candidatos y votos, adem�s de consultar estad�sticas del proceso.

## C�mo correr el proyecto

1. Clona el repositorio:
```bash git clone  https://github.com/JuanDiegoPasos/VoteSystem.git

2. Restaura paquetes y compila

dotnet restore
dotnet build

3 ejecuta migraciones y corre la aplicaci�n

dotnet ef database update
dotnet run