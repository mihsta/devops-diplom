#https://registry.terraform.io/providers/hashicorp/azurerm/latest
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "2.87.0"
    }
  }

  required_version = ">= 0.14"
}

