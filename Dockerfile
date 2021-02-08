# Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY *.csproj ./
COPY *.sln /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

# comment this if you need Production mode
ENV ASPNETCORE_ENVIRONMENT Development

# web.api.dll — name of my api-project dll
CMD ASPNETCORE_URLS=http://*:$PORT dotnet web.api.dll