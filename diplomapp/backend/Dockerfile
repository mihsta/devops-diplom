FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS="http://*:8080"


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
WORKDIR /src
COPY [".", "."]
RUN dotnet publish "backend.csproj" -c Release -o /app/publish



FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .

#HEALTHCHECK --interval=15s --timeout=3s CMD curl -f http://localhost/weatherforecast

RUN useradd -U -u 1000 -m -s /bin/sh appuser && chown appuser:appuser /app /app/* 
USER appuser

ENTRYPOINT ["dotnet", "backend.dll"]



