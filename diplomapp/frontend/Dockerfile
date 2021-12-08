FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
WORKDIR /src
COPY [".", "."]
RUN dotnet publish "frontend.csproj" -c Release -o /app/publish



FROM nginx:alpine AS final

WORKDIR /var/www/web
COPY --from=publish /app/publish/wwwroot .
COPY ["./nginx.conf", "/etc/nginx/nginx.conf"]

# Healthcheck
# HEALTHCHECK --interval=15s --timeout=3s CMD curl -f http://localhost:80
#RUN addgroup -S nginx && adduser -S nginx -G appgroup
#RUN chown -R nginx:nginx /var/cache/nginx /var/run/nginx.pi
#USER nginx

EXPOSE 8080

CMD ["nginx", "-g", "daemon off;"]
