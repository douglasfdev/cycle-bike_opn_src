FROM mcr.microsoft.com/dotnet/aspire:8.0 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
WORKDIR /src/src/adapters/CycleBike.Adapters.gRPC
RUN dotnet restore "CycleBike.Adapters.gRPC.csproj"
RUN dotnet build "CycleBike.Adapters.gRPC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CycleBike.Adapters.gRPC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CycleBike.Adapters.gRPC.dll"]