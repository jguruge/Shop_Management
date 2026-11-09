# Shop Management API: production image.
#   docker build -t shopmanagement-api backend/
#   docker run --env-file backend/.env -p 8080:8080 shopmanagement-api
#
# Configuration comes from environment variables at run time; nothing secret
# is baked in (see .env.example): ConnectionStrings__DefaultConnection,
# Jwt__Key, Cors__AllowedOrigins__0.

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Restore first, in its own layer, so code changes don't re-download packages.
COPY ShopManagement.Api.csproj ./
RUN dotnet restore ShopManagement.Api.csproj

COPY . .
RUN dotnet publish ShopManagement.Api.csproj -c Release -o /app --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080 \
    ASPNETCORE_ENVIRONMENT=Production \
    DOTNET_RUNNING_IN_CONTAINER=true

COPY --from=build /app .

# The base image ships a non-root "app" user; don't run the API as root.
USER $APP_UID
EXPOSE 8080

ENTRYPOINT ["dotnet", "ShopManagement.Api.dll"]
