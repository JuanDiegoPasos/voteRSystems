# Sistema de Votaciones - API RESTful

Esta API permite gestionar un sistema de votación simple, con funcionalidades para registrar votantes, candidatos y votos, además de consultar estadísticas del proceso.

## Cómo correr el proyecto

1. Clona el repositorio:
```bash git clone  https://github.com/JuanDiegoPasos/voteRSystems.git


2. Restaura paquetes y compila

dotnet restore
dotnet build

3 ejecuta migraciones y corre la aplicación

dotnet ef database update
dotnet run
