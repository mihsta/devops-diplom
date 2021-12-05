#https://azurearcjumpstart.io/azure_arc_jumpstart/azure_arc_k8s/aks/aks_terraform/
#Only from Cloud Shell
#!/bin/sh
# <--- Change the following environment variables according to your Azure service principal name --->
#az ad sp create-for-rbac -n "http://AzureArcK8s" --role contributor

echo "Exporting environment variables"
export appId=''
export password=''
export tenantId=''
export resourceGroup=''
export arcClusterName=''

# Getting AKS credentials
echo "Log in to Azure with Service Principal & Getting AKS credentials (kubeconfig)"
az login --service-principal --username $appId --password $password --tenant $tenantId
az aks get-credentials --name $arcClusterName --resource-group $resourceGroup --overwrite-existing

# Installing Azure Arc k8s Extensions
echo "Installing Azure Arc Extensions"
az extension add --name connectedk8s
az extension add --name k8s-configuration

echo "Connecting the cluster to Azure Arc"
az connectedk8s connect --name $arcClusterName --resource-group $resourceGroup --location 'West Europe'

#echo "Deleting the cluster to Azure Arc"
#az connectedk8s delete --name $arcClusterName --resource-group $resourceGroup