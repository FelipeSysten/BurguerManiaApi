namespace WebApiBurguerMania.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string PathImage { get; set; } 

        public ICollection<ProductsModel> Products { get; set; }
    }
}
