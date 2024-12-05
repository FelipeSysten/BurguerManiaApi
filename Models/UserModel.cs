using System.Text.Json.Serialization;

namespace WebApiBurguerMania.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public ICollection<OrderModel> Order { get; set; }

    }
}
