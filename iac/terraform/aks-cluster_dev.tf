#https://learn.hashicorp.com/tutorials/terraform/aks
# az ad sp create-for-rbac --name "terraform_diplomapp" --skip-assignment
# az aks get-credentials --resource-group $(terraform output -raw resource_group_name) --name $(terraform output -raw kubernetes_cluster_name)
# az aks browse --resource-group $(terraform output -raw resource_group_name) --name $(terraform output -raw kubernetes_cluster_name)

resource "azurerm_resource_group" "Dev" {
  name     = "AzureArcDev"
  location = "West Europe"

  tags = {
    environment = "diplomapp"
  }
}
