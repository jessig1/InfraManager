terraform {
  backend "azurerm" {
    resource_group_name  = "tfstate"
    storage_account_name = "jwetfstatesa"                 
    container_name       = "tfstate"                    
    key                  = "infra.tfstate"    
    subscription_id = "b3c09163-31cd-49b9-af36-e9306dd2c06e"   
  }
}