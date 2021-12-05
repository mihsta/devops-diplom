# Links
**[GITREPO](https://github.com/mihsta/devops-diplom)**

**[DASHBOARD](https://dev.azure.com/mihsta/DevOps-diploma/_dashboards)**

**[CI/CD PIPELINE](https://dev.azure.com/mihsta/DevOps-diploma/_build?definitionId=10&_a=summary)**

**[DOCKER](https://hub.docker.com/repositories)**

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=mihsta_devops-diplom&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=mihsta_devops-diplom) [![Build Status](https://dev.azure.com/mihsta/DevOps-diploma/_apis/build/status/mihsta.devops-diplom?branchName=main)](https://dev.azure.com/mihsta/DevOps-diploma/_build/latest?definitionId=10&branchName=main)

<details>
  <summary>Application description</summary>

## Develop a simple (lightweight) 3-tire application (front-end, back-end, database). 
 
#### Back-end (collects data) must: 
1. Retrieve a portion of data from API (see in your Variant) and store it in a database 
2. Update data on demand 
3. Update DB schema if needed on app’s update 
 
#### Front-end (outputs data) must: 
1. Display any portion of the data stored in the DB 
2. Provide a method to trigger data update process 
 
#### Database: 
1. Choose Database type and data scheme in a suitable manner.  
2. Data must be stored in a persistent way 
3. It’s better to use cloud native DB solutions like an RDS/AzureSQL/CloudSQL.
  
</details>

<details>
<summary>Docker commands</summary>
<p>

```
docker build -f '.\Dockerfile.backend' -t backend . --no-cache
docker build -f '.\Dockerfile.frontend' -t frontend . --no-cache

dotnet publish .\diplomapp\backend\backend.csproj -c Release
dotnet publish .\diplomapp\frontend\frontend.csproj -c Release

dotnet pusln .\diplomapp\diplomapp.sln list

docker-compose down
docker image prune -f
docker-compose pull
docker-compose up --detach

```

</p>
</details>  

<details>
<summary>Git commands</summary>
<p>

```
#https://www.atlassian.com/ru/git/tutorials/comparing-workflows/gitflow-workflow
#https://github.com/nvie/gitflow
#https://yapro.ru/article/6172

```

</p>
</details>  

