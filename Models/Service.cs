namespace InfraManager.Models { 
    public enum ServiceType
    {
        Api,
        Consumer,
        Cron
    }
    public class Service
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        //api, consumer, cron
        public ServiceType ServiceType{ get; set; }
        
        public string Owner { get; set; }
        public string[] Tags { get; set; }

        public bool IsActive { get; set; } = true; // Default is active
        public int EstimatedCost { get; set; }
    }
}

