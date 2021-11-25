# devops-diplom
https://dev.azure.com/mihsta/DevOps-diploma/_dashboards

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=mihsta_devops-diplom&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=mihsta_devops-diplom) [![Build Status](https://dev.azure.com/mihsta/DevOps-diploma/_apis/build/status/mihsta.devops-diplom?branchName=main)](https://dev.azure.com/mihsta/DevOps-diploma/_build/latest?definitionId=10&branchName=main)


#docker
```bash
docker build -f '.\Dockerfile.backend' -t backend . --no-cache
docker build -f '.\Dockerfile.frontend' -t frontend . --no-cache

dockercompose up
dockercompose down
```