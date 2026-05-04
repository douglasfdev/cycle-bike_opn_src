FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/adapters/CycleBike.Adapters.LogGateway/CycleBike.Adapters.LogGateway.csproj", "src/adapters/CycleBike.Adapters.LogGateway/"]
RUN dotnet restore "src/adapters/CycleBike.Adapters.LogGateway/CycleBike.Adapters.LogGateway.csproj"
COPY . .
WORKDIR "/src/src/adapters/CycleBike.Adapters.LogGateway"
RUN dotnet build "./CycleBike.Adapters.LogGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CycleBike.Adapters.LogGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CycleBike.Adapters.LogGateway.dll"]
