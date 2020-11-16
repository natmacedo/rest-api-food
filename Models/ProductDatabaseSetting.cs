namespace OpenFoodApi.Models
{
    public class ProductDatabaseSettings : IProductDatabaseSettings
    {
        public string ProductsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProductDatabaseSettings
    {
        string ProductsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
