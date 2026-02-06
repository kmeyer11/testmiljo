# ---------- Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# ---------- Build ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Kopiér alle projekter med deres mappestruktur
COPY AuthService.API/ AuthService.API/
COPY AuthService.Application/ AuthService.Application/
COPY AuthService.Domain/ AuthService.Domain/
COPY AuthService.Infrastructure/ AuthService.Infrastructure/

# Restore alle projekter
WORKDIR /src/AuthService.API
RUN dotnet restore

# Byg og publish
RUN dotnet publish -c Release -o /app/publish
# RUN dotnet publish -c Release -o /app/publish /p:UseRazorBuildServer=false


# ---------- Final ----------
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AuthService.API.dll"]
