# Etapa base: Imagen ligera para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
# Cambiamos a puerto 80 para coincidir con ASPNETCORE_URLS
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

# Etapa build: Imagen con SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StudentManagementApi.csproj", "./"]
RUN dotnet restore "StudentManagementApi.csproj" --disable-parallel
COPY . .
RUN dotnet build "StudentManagementApi.csproj" -c Release -o /app/build

# Etapa publish: Publicar la aplicación
FROM build AS publish
RUN dotnet publish "StudentManagementApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final: Imagen final basada en la base
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentManagementApi.dll"]
