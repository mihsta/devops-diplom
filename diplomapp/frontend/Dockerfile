FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
WORKDIR /src
COPY [".", "."]
RUN dotnet publish "frontend.csproj" -c Release -o /app/publish

FROM nginxinc/nginx-unprivileged:stable-alpine AS final
COPY --from=publish /app/publish/wwwroot /var/www/web
COPY ["./nginx.conf", "/etc/nginx/nginx.conf"]

HEALTHCHECK --interval=60s --timeout=3s CMD curl -f http://localhost:8080

