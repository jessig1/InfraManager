resource "azurerm_resource_group" "consumer_rg" {
  name     = "consumer-rg"
  location = "East US"
}

resource "azurerm_eventhub_namespace" "consumer_eventhub_namespace" {
  name                = "consumerEventHubNamespace"
  location            = azurerm_resource_group.consumer_rg.location
  resource_group_name = azurerm_resource_group.consumer_rg.name
  sku                 = "Standard"
  capacity            = 1
}

resource "azurerm_eventhub" "example" {
  name                = "consumerEventHub"
  namespace_name      = azurerm_eventhub_namespace.consumer_eventhub_namespace.name
  resource_group_name = azurerm_resource_group.consumer_rg.name
  partition_count     = 1
  message_retention   = 1
}
