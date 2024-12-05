using System.Text.Json.Serialization;

namespace WebApiBurguerMania.Models
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<OrderModel> Order { get; set; }  
    }
}
