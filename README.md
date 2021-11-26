# Links
**[GITREPO](https://github.com/mihsta/devops-diplom)**

**[DASHBOARD](https://dev.azure.com/mihsta/DevOps-diploma/_dashboards)**

**[CI/CD PIPELINE](https://dev.azure.com/mihsta/DevOps-diploma/_build?definitionId=10&_a=summary)**

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=mihsta_devops-diplom&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=mihsta_devops-diplom) [![Build Status](https://dev.azure.com/mihsta/DevOps-diploma/_apis/build/status/mihsta.devops-diplom?branchName=main)](https://dev.azure.com/mihsta/DevOps-diploma/_build/latest?definitionId=10&branchName=main)

# Application description 
<details>
  <summary>Click to expand</summary>
  
  ## Heading
Develop a simple (lightweight) 3-tire application (front-end, back-end, database). 
 
Back-end (collects data) must: 
1. Retrieve a portion of data from API (see in your Variant) and store it in a database 
2. Update data on demand 
3. Update DB schema if needed on app’s update 
 
Front-end (outputs data) must: 
1. Display any portion of the data stored in the DB 
2. Provide a method to trigger data update process 
 
Database: 
1. Choose Database type and data scheme in a suitable manner.  
2. Data must be stored in a persistent way 
3. It’s better to use cloud native DB solutions like an RDS/AzureSQL/CloudSQL. 
</details>


# Docker commands
```bash
docker build -f '.\Dockerfile.backend' -t backend . --no-cache
docker build -f '.\Dockerfile.frontend' -t frontend . --no-cache
dockercompose up
dockercompose down
```
