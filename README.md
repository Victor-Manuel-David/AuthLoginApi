# AuthLoginAPI

Este proyecto es un servicio de autenticación y login desarrollado en .NET 8.0. Proporciona endpoints para autenticación de usuarios utilizando JWT y una arquitectura limpia basada en capas.

## Estructura del proyecto

- **AuthServer.Api**: API principal con los controladores y configuración.
- **AuthServer.Application**: Lógica de negocio y servicios de autenticación.
- **AuthServer.Domain**: Entidades y abstracciones del dominio.
- **AuthServer.Infrastructure**: Implementaciones concretas (JWT, repositorios, configuración).

## Características
- Autenticación de usuarios con JWT
- Repositorio de usuarios en memoria
- Versionado de API recomendado
- Configuración por entorno (`appsettings.json` y `appsettings.Development.json`)

## Requisitos
- .NET 8.0 SDK
- Git

## Instalación
1. Clona el repositorio:
	```powershell
	git clone <url-del-repositorio>
	```
2. Restaura los paquetes:
	```powershell
	dotnet restore
	```
3. Ejecuta la API:
	```powershell
	dotnet run --project AuthServer.Api
	```

## Uso
- Endpoint principal: `/api/auth/login`
- Enviar credenciales para obtener un token JWT.

## Versionamiento
- Se recomienda usar versionado semántico y tags en Git (`v1.0.0`, `v1.1.0`, etc).
- Actualiza la propiedad `<Version>` en los archivos `.csproj` para cada release.

## Contribuciones
Las contribuciones son bienvenidas. Por favor, abre un issue o pull request para sugerencias o mejoras.

## Licencia
Este proyecto está bajo la licencia MIT.
