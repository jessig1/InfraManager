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
  minimum_tls_version = "1.2"
}

resource "azurerm_eventhub" "consumer" {
  name                = "consumerEventHub"
  namespace_name      = azurerm_eventhub_namespace.consumer_eventhub_namespace.name
  resource_group_name = azurerm_resource_group.consumer_rg.name
  partition_count     = 1
  message_retention   = 1
}

resource "azurerm_cosmosdb_postgresql_cluster" "infradb" {
  name                            = "infra-db"
  resource_group_name             = azurerm_resource_group.consumer_rg.name
  location                        = azurerm_resource_group.consumer_rg.location
  administrator_login_password    = "Mytestdb"
  coordinator_storage_quota_in_mb = 32768
  coordinator_vcore_count         = 1
  node_count                      = 0
}