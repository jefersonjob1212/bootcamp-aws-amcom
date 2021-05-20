FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Bootcamp.Servless.API/*.csproj ./Bootcamp.Servless.API/
COPY Bootcamp.Servless.Services/*.csproj ./Bootcamp.Servless.Services/

RUN dotnet restore

# copy everything else and build app
COPY Bootcamp.Servless.API/. ./Bootcamp.Servless.API/
COPY Bootcamp.Servless.Services/. ./Bootcamp.Servless.Services/

WORKDIR /app/Bootcamp.Servless.API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app

COPY --from=build /app/Bootcamp.Servless.API/out ./
ENTRYPOINT ["dotnet", "Bootcamp.Servless.API.dll"]