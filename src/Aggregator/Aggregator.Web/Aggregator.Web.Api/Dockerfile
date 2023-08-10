#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Aggregator/Aggregator.Web/Aggregator.Web.Api/Aggregator.Web.Api.csproj", "src/Aggregator/Aggregator.Web/Aggregator.Web.Api/"]
RUN dotnet restore "src/Aggregator/Aggregator.Web/Aggregator.Web.Api/Aggregator.Web.Api.csproj"
COPY . .
WORKDIR "/src/src/Aggregator/Aggregator.Web/Aggregator.Web.Api"
RUN dotnet build "Aggregator.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aggregator.Web.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aggregator.Web.Api.dll"]
