terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=4.16.0"
    }
  }
}

# Configure the Microsoft Azure Provider

provider "azurerm" {
  skip_provider_registration = true # This is only required when the User, Service Principal, or Identity running Terraform lacks the permissions to register Azure Resource Providers.

  subscription_id = "b3c09163-31cd-49b9-af36-e9306dd2c06e"  
  features {}
}