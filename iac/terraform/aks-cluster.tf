#https://learn.hashicorp.com/tutorials/terraform/aks
# az ad sp create-for-rbac --name "terraform_diplomapp" --skip-assignment
# az aks get-credentials --resource-group $(terraform output -raw resource_group_name) --name $(terraform output -raw kubernetes_cluster_name)
# az aks browse --resource-group $(terraform output -raw resource_group_name) --name $(terraform output -raw kubernetes_cluster_name)

# Impurt https://cloudskills.io/blog/terraform-azure-07
# https://github.com/hashicorp/terraform-provider-azurerm/tree/main/examples/kubernetes

resource "random_pet" "prefix" {}


provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "default" {
  name     = "funny-hawk-rg"
  location = "West Europe"

  tags = {
    environment = "diplomapp"
  }
}

resource "azurerm_kubernetes_cluster" "default" {
  name                = "funny-hawk-aks"
  location            = azurerm_resource_group.default.location
  resource_group_name = azurerm_resource_group.default.name
  dns_prefix          = "funny-hawk-k8s"

  default_node_pool {
    name            = "default"
    node_count      = 1
    vm_size         = "Standard_B2s"
    os_disk_size_gb = 30
  }
  service_principal {
    client_id     = var.appId
    client_secret = var.password
  }

  role_based_access_control {
    enabled = true
  }

  tags = {
    environment = "diplomapp"
  }
}
  resource "azurerm_kubernetes_cluster_node_pool" "user" {
    name                  = "user"
    kubernetes_cluster_id = azurerm_kubernetes_cluster.default.id
    vm_size               = "Standard_B2s"    
    enable_auto_scaling   = true
    node_count            = 0
    min_count             = 0
    max_count             = 2 
    os_disk_size_gb       = 30  

  }