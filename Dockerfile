FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY ./Adapter.RestfulAPI.Src/bin ./Adapter.RestfulAPI.Src/bin
COPY ./CLI.Migration/bin ./CLI.Migration/bin
COPY ./Domain.Core/bin ./Domain.Core/bin
COPY ./Domain.Services/bin ./Domain.Services/bin
COPY ./In/bin ./In/bin
COPY ./Out/bin ./Out/bin
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]