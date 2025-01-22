namespace InfraManager.Models
{
    public class Consumer
    {

        public int ConsumerId { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public string[] Topics { get; set; }
        public string ConsumerGroup { get; set; }
        //kafka permissions (read/write/both)
        public string Permissions { get; set; }
    }
}
