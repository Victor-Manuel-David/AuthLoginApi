#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AuthServer.Api/AuthServer.Api.csproj", "src/AuthServer.Api/"]
COPY ["src/AuthServer.Application/AuthServer.Application.csproj", "src/AuthServer.Application/"]
COPY ["src/AuthServer.Domain/AuthServer.Domain.csproj", "src/AuthServer.Domain/"]
COPY ["src/AuthServer.Infrastructure/AuthServer.Infrastructure.csproj", "src/AuthServer.Infrastructure/"]
COPY ["src/Shared.Contracts/Shared.Contracts.csproj", "src/Shared.Contracts/"]
RUN dotnet restore "./src/AuthServer.Api/AuthServer.Api.csproj"
COPY . .
WORKDIR "/src/src/AuthServer.Api"
RUN dotnet build "./AuthServer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AuthServer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthServer.Api.dll"]