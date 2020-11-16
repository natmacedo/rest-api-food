using OpenFoodApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace OpenFoodApi.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IProductDatabaseSettings settings)
        {
            // var client = new MongoClient(settings.ConnectionString);
            var client = new MongoClient("mongodb+srv://nat:natalia191785@cluster0.poltn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("OpenFoodData");

            _products = database.GetCollection<Product>("Products");

        }

        public List<Product> Get() =>
            _products.Find(product => true).ToList();

        public Product Get(string id) =>
            _products.Find<Product>(product => product.Id == id).FirstOrDefault();

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product productIn) =>
            _products.ReplaceOne(product => product.Id == id, productIn);

        public void Remove(Product productIn) =>
            _products.DeleteOne(product => product.Id == productIn.Id);

        public void Remove(string id) =>
            _products.DeleteOne(product => product.Id == id);
    }
}
