using System.Text.Json.Serialization;

namespace WebApiBurguerMania.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public float Value { get; set; }
        public UserModel User { get; set; }
        public StatusModel Status { get; set; }

        public ICollection<ProductsModel> Products { get; set; }
    }
}
