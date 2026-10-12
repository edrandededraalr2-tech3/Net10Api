# 1. Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Net10Api.Api/Net10Api.Api.csproj", "Net10Api.Api/"]
RUN dotnet restore "Net10Api.Api/Net10Api.Api.csproj"
COPY . .
WORKDIR "/src/Net10Api.Api"
RUN dotnet publish "./Net10Api.Api.csproj" -c Release -h -o /app/publish /p:UseAppHost=false

COPY . .
RUN dotnet publish "Net10Api.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 2. Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Net10Api.Api.dll"]
