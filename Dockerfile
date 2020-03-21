FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

COPY *.sln .
COPY PixelDataApp/*.csproj ./PixelDataApp/
RUN dotnet restore

COPY PixelDataApp/. ./PixelDataApp/
WORKDIR /source/PixelDataApp
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "PixelDataApp.dll"]