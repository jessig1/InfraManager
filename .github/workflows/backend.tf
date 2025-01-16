terraform {
  backend "azurerm" {
    resource_group_name  = "tfstate"
    storage_account_name = "jwetfstatesa"                 
    container_name       = "tfstate"                    
    key                  = "initial.tfstate"    
    subscription_id = var.ARM_SUBSCRIPTION_ID    
  }
}
