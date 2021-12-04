## CONTROL_NODE: install ansible (1m)
```
sudo apt update && apt upgrade -y
sudo apt-add-repository ppa:ansible/ansible
sudo apt install ansible
ansible --version
```
## CLUSTER_NODE: install os (10m)
```
ubuntu 20.04
secureboot disable (cos needs drivers key for vbox)
```
## CLUSTER_NODE: install ssh & vbox, add ansible user (5m)
```
sudo apt update
sudo apt install openssh-server
sudo systemctl status ssh
sudo ufw allow ssh
sudo apt install virtualbox

sudo adduser ansible
sudo echo "ansible ALL=(ALL) NOPASSWD: ALL" > /etc/sudoers.d/ansible
```
## fix if ssh Authentication refused: bad ownership or modes for directory
```
sudo chmod go-w ~/
sudo chmod 700 ~/.ssh
sudo chmod 600 ~/.ssh/authorized_keys
```
## CONTROL_NODE: create user ansible envvar sshhost & copy pub key (1m)
```
export SSH_CLUSTER_HOST=ansible@ipaddress
sudo adduser ansible
ssh-keygen -q -N "" -f /home/ansible/.ssh/id_rsa <<<y >/dev/null 2>&1  
sudo ssh-copy-id -i /home/ansible/.ssh/id_rsa.pub $SSH_CLUSTER_HOST -f
```
## CONTROL_NODE: create envvar sshhost test connect (1m)
```
su ansible
ssh $SSH_CLUSTER_HOST
```
## CONTROL_NODE: install k8s (20m)
ansible-playbook -i inventory -v pb_install_cluster.yml

## CLUSTER_NODE: copy /home/vagrant/.kube/config (2m)
#gotovmk8smaster
sudo vagrant ssh k8s-master 
nano /home/vagrant/.kube/config #copy2buffer
#backtovmhost
exit 
mkdir -p /home/ansible/.kube
nano /home/ansible/.kube/config #paste config
chown ansible:ansible /home/ansible/.kube/config
kubectl config view
## CLUSTER_NODE: connect to Azure Arc

#https://docs.microsoft.com/en-us/azure/azure-arc/kubernetes/quickstart-connect-cluster?tabs=azure-cli
#https://docs.microsoft.com/en-us/azure/app-service/manage-create-arc-environment?tabs=bash
#https://docs.microsoft.com/ru-ru/azure/architecture/hybrid/arc-hybrid-kubernetes?bc=/azure/cloud-adoption-framework/_bread/toc.json&toc=/azure/cloud-adoption-framework/scenarios/hybrid/toc.json
#https://docs.microsoft.com/en-us/azure/azure-arc/kubernetes/cluster-connect#option-2-service-account-bearer-token
#https://docs.microsoft.com/en-us/azure/azure-arc/kubernetes/cluster-connect
#Export env var
export CLUSTER_NAME="AzureArcDevOnPrem"
export RESOURCE_GROUP="AzureArcDev"
export REGION="WestEurope"

#install AzureCLI
curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
az upgrade
az login

#Install the connectedk8s Azure CLI extension of version >= 1.2.0:
az extension add --name connectedk8s

#Install az providers
az provider register --namespace Microsoft.Kubernetes
az provider register --namespace Microsoft.KubernetesConfiguration
az provider register --namespace Microsoft.ExtendedLocation
#Check az providers
az provider show -n Microsoft.Kubernetes -o table
az provider show -n Microsoft.KubernetesConfiguration -o table
az provider show -n Microsoft.ExtendedLocation -o table

#Create a resource group
az group create --name $RESOURCE_GROUP --location $REGION --output table

#Connect an existing Kubernetes cluster
az connectedk8s connect --name $CLUSTER_NAME --resource-group $RESOURCE_GROUP

#Verify cluster connection
az connectedk8s list --resource-group $RESOURCE_GROUP --output table

#View Azure Arc agents for Kubernetes
kubectl get deployments,pods -n azure-arc

#Install the k8s-configuration Azure CLI extension of version >= 1.0.0:
az extension add --name k8s-configuration

#List all Azure Arc-enabled Kubernetes clusters without Azure Monitor extension
az graph query -q "Resources | where type =~ 'Microsoft.Kubernetes/connectedClusters' | extend connectedClusterId = tolower(id) | project connectedClusterId | join kind = leftouter (KubernetesConfigurationResources | where type == 'microsoft.kubernetesconfiguration/extensions' | where properties.ExtensionType == 'microsoft.azuremonitor.containers' | parse tolower(id) with connectedClusterId '/providers/microsoft.kubernetesconfiguration/extensions' * | project connectedClusterId ) on connectedClusterId | where connectedClusterId1 == '' | project connectedClusterId"

#List all Azure Arc-enabled Kubernetes resources
az graph query -q "Resources | project id, subscriptionId, location, type, properties.agentVersion, properties.kubernetesVersion, properties.distribution, properties.infrastructure, properties.totalNodeCount, properties.totalCoreCount | where type =~ 'Microsoft.Kubernetes/connectedClusters'"

#Get toket to connect k8s from portal
ARM_ID_CLUSTER=$(az connectedk8s show -n $CLUSTER_NAME -g $RESOURCE_GROUP --query id -o tsv)
$ARM_ID_CLUSTER
AAD_ENTITY_OBJECT_ID=$(az ad signed-in-user show --query objectId -o tsv)
$AAD_ENTITY_OBJECT_ID
az role assignment create --role "Azure Arc Kubernetes Viewer" --assignee $AAD_ENTITY_OBJECT_ID --scope $ARM_ID_CLUSTER
kubectl create serviceaccount admin-user
kubectl create clusterrolebinding admin-user-binding --clusterrole cluster-admin --serviceaccount default:admin-user
SECRET_NAME=$(kubectl get serviceaccount admin-user -o jsonpath='{$.secrets[0].name}')
TOKEN=$(kubectl get secret ${SECRET_NAME} -o jsonpath='{$.data.token}' | base64 -d | sed $'s/$/\\\n/g')
$TOKEN
```

#connect to cluster from anywhere 
az login
CLUSTER_NAME="AzureArcDevOnPrem"
RESOURCE_GROUP="AzureArcDev"
ARM_ID_CLUSTER=$(az connectedk8s show -n $CLUSTER_NAME -g $RESOURCE_GROUP --query id -o tsv)
az role assignment create --role "Azure Arc Kubernetes Viewer" --assignee $AAD_ENTITY_OBJECT_ID --scope $ARM_ID_CLUSTER

#Access your cluster (Powershell)
$CLUSTER_NAME="AzureArcDevOnPrem"
$RESOURCE_GROUP="AzureArcDev"
az connectedk8s proxy -n $CLUSTER_NAME -g $RESOURCE_GROUP --token $TOKEN

#TODO
#https://docs.microsoft.com/en-us/azure/azure-arc/kubernetes/azure-rbac

#https://docs.microsoft.com/en-us/azure/azure-arc/kubernetes/tutorial-use-gitops-flux2