using ConsoleSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSample.Repositories
{
  public class ProductRepository
  {
    // db
    List<Product> products = new List<Product>
    {
      new Product {  Id = 1, Name = "Ürün-1", Price = 100 },
      new Product {  Id = 2, Name = "Ürün-1", Price = 200 },

    };

    public Product FindById(int Id)
    {
      Product product =  products.Find(x => x.Id == Id);
      ArgumentNullException.ThrowIfNull(product);

      return product;
    }

    public void Save(Product product)
    {
      // Execute edecek olan kod kısmı
      Console.WriteLine("Product Save edildi");
    }
  }
}
