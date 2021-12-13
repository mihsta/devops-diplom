terraform {
  backend "azurerm" {
    resource_group_name  = "rg-terraformstate"
    storage_account_name = "terrastatestorage5533"
    container_name       = "terraformstate"
    key                  = "testimport.terraform.tfstate"
  }
}