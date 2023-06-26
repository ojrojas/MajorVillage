#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Identity/Identity.Api/Identity.Api.csproj", "src/Identity/Identity.Api/"]
COPY ["src/Identity/Identity.Core/Identity.Core.csproj", "src/Identity/Identity.Core/"]
COPY ["src/BuildingBlock/BuildingBlock.Commons/BuildingBlock.Commons.csproj", "src/BuildingBlock/BuildingBlock.Commons/"]
COPY ["src/BuildingBlock/BuildingBlock.Repository/BuildingBlock.Repository.csproj", "src/BuildingBlock/BuildingBlock.Repository/"]
COPY ["src/Identity/Identity.Infraestructure/Identity.Infraestructure.csproj", "src/Identity/Identity.Infraestructure/"]
RUN dotnet restore "src/Identity/Identity.Api/Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/Identity/Identity.Api"
RUN dotnet build "Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]
