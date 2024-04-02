FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build-env
WORKDIR /App

COPY . ./
RUN dotnet restore
# TODO: use `--property:PublishDir=out` instead of `-o out`, then copy all output to /out
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled-composite
EXPOSE 8080
WORKDIR /App
ARG ENV=Production
COPY --from=build-env /App/out .
ENV ASPNETCORE_ENVIRONMENT=${ENV}
ENTRYPOINT ["dotnet", "Adapter.RestfulAPI.Src.dll"]