#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 81

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/School/School.Api/School.Api.csproj", "src/School/School.Api/"]
COPY ["src/School/School.Core/School.Core.csproj", "src/School/School.Core/"]
COPY ["src/BuildingBlock/BuildingBlock.Commons/BuildingBlock.Commons.csproj", "src/BuildingBlock/BuildingBlock.Commons/"]
COPY ["src/BuildingBlock/BuildingBlock.Repository/BuildingBlock.Repository.csproj", "src/BuildingBlock/BuildingBlock.Repository/"]
COPY ["src/School/School.Infraestructure/School.Infraestructure.csproj", "src/School/School.Infraestructure/"]
RUN dotnet restore "src/School/School.Api/School.Api.csproj"
COPY . .
WORKDIR "/src/src/School/School.Api"
RUN dotnet build "School.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "School.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "School.Api.dll"]
