FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

COPY *.sln .
COPY app/*.csproj ./app/
RUN dotnet restore

COPY app/. ./app/
WORKDIR /source/app
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "app.dll"]