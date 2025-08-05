# Sistema de Votaciones - API RESTful

Esta API permite gestionar un sistema básico de votaciones, incluyendo votantes, candidatos y votos. Fue desarrollada con ASP.NET Core.

Funcionalidades principales:
- Registrar votantes (Voter)
- Registrar candidatos (Candidate)
- Registrar un voto (Vote)
Obtener estadísticas de votación:
- Total de votos por candidato
- Porcentaje de votos
- Total de votantes que han votado

El sistema incluye un Seeder que:
- Registra votantes de ejemplo
- Registra candidatos de ejemplo
- No se registran votos en el Seeder, para mantener la integridad del sistema

El Seeder se ejecuta automáticamente al iniciar la aplicación en modo desarrollo.
## Cómo correr el proyecto

1. Clona el repositorio:
```bash git clone  https://github.com/JuanDiegoPasos/voteRSystems.git


2. Restaura paquetes y compila

dotnet restore
dotnet build

3 ejecuta migraciones y corre la aplicación

dotnet ef database update
dotnet run
