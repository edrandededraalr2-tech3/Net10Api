FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar únicamente el archivo de proyecto primero para restaurar dependencias
COPY ["Net10Api.Api/Net10Api.Api.csproj", "Net10Api.Api/"]
RUN dotnet restore "Net10Api.Api/Net10Api.Api.csproj"

# Copiar el resto del código fuente
COPY . .
WORKDIR "/src/Net10Api.Api"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Imagen final para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Net10Api.Api.dll"]
