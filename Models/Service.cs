namespace InfraManager.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //path of source code repo
        public string Location { get; set; }
        //api, consumer, cron
        public string Type { get; set; }
        public string[] Topics { get; set; }
        public string ConsumerGroup { get; set; }
        //kafka permissions (read/write/both)
        public string Permissions { get; set; }
        public string Owner { get; set; }
        public string[] Tags { get; set; }
        public int EstimatedCost { get; set; }
    }
}

