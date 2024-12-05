using System.Text.Json.Serialization;

namespace WebApiBurguerMania.Models
{
    public class ProductsModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string PathImage { get; set; }
        public string Price { get; set; }
        public string BaseDescription { get; set; }
        public string FullDescription { get; set; }

        [JsonIgnore]
        public OrderModel Order { get; set; } // Cada produto pode estar associado a um pedido

        public CategoryModel Category { get; set; }


    }
}
