FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/adapters/CycleBike.Adapters.WebApi/CycleBike.Adapters.WebApi.csproj", "src/adapters/CycleBike.Adapters.WebApi/"]
COPY ["src/adapters/CycleBike.Adapters.SocketServerAdapter/CycleBike.Adapters.SocketServerAdapter.csproj", "src/adapters/CycleBike.Adapters.SocketServerAdapter/"]
COPY ["src/adapters/CycleBike.Adapters.NoSQLContext/CycleBike.Adapters.NoSQLContext.csproj", "src/adapters/CycleBike.Adapters.NoSQLContext/"]
COPY ["src/core/CycleBike.Core.Common/CycleBike.Core.Common.csproj", "src/core/CycleBike.Core.Common/"]
COPY ["src/adapters/CycleBike.Adapters.SocketAdapter/CycleBike.Adapters.SocketAdapter.csproj", "src/adapters/CycleBike.Adapters.SocketAdapter/"]
COPY ["src/adapters/CycleBike.Adapters.GenericHttpClient/CycleBike.Adapters.GenericHttpClient.csproj", "src/adapters/CycleBike.Adapters.GenericHttpClient/"]
COPY ["src/core/CycleBike.Core.Domain/CycleBike.Core.Domain.csproj", "src/core/CycleBike.Core.Domain/"]
RUN dotnet restore "src/adapters/CycleBike.Adapters.WebApi/CycleBike.Adapters.WebApi.csproj"
COPY . .
WORKDIR "/src/src/adapters/CycleBike.Adapters.WebApi"
RUN dotnet build "./CycleBike.Adapters.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CycleBike.Adapters.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CycleBike.Adapters.WebApi.dll"]
