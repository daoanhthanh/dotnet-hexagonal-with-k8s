FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src.RestfulAPI/Src.RestfulAPI.csproj", "Src.RestfulAPI/"]
RUN dotnet restore "Src.RestfulAPI/Src.RestfulAPI.csproj"
COPY . .
WORKDIR "/src/Src.RestfulAPI"
RUN dotnet build "Src.RestfulAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Src.RestfulAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Src.RestfulAPI.dll"]
