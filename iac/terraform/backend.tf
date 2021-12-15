terraform {
  backend "azurerm" {
    resource_group_name  = "rg-terraformstate"
    storage_account_name = "__terraformstorageaccount__"
    container_name       = "terraformstate"
    key                  = "testimport.terraform.tfstate"
  }
}