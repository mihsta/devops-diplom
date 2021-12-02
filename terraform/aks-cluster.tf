#https://learn.hashicorp.com/tutorials/terraform/aks
# az ad sp create-for-rbac --skip-assignment
resource "random_pet" "prefix" {}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "default" {
  name     = "Dev-${random_pet.prefix.id}-rg"
  location = "West Europe"

  tags = {
    environment = "Dev"
  }
}

resource "azurerm_kubernetes_cluster" "default" {
  name                = "dev-${random_pet.prefix.id}-aks"
  location            = azurerm_resource_group.default.location
  resource_group_name = azurerm_resource_group.default.name
  dns_prefix          = "dev-${random_pet.prefix.id}-k8s"

  default_node_pool {
    name            = "default"
    node_count      = 1
    vm_size         = "Standard_D2_v3"
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
    environment = "Demo"
  }
}
