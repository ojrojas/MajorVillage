#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/NotesAndMaths/NotesAndMaths.Api/NotesAndMaths.Api.csproj", "src/NotesAndMaths/NotesAndMaths.Api/"]
RUN dotnet restore "src/NotesAndMaths/NotesAndMaths.Api/NotesAndMaths.Api.csproj"
COPY . .
WORKDIR "/src/src/NotesAndMaths/NotesAndMaths.Api"
RUN dotnet build "NotesAndMaths.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotesAndMaths.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesAndMaths.Api.dll"]
