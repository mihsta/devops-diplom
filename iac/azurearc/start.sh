#set prod context az cli
CLUSTER_NAME="funny-hawk-aks"
RESOURCE_GROUP="funny-hawk-rg" 
az aks start --name $CLUSTER_NAME --resource-group $RESOURCE_GROUP