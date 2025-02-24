using ConsoleSample.Events;
using ConsoleSample.Models;
using ConsoleSample.Repositories;
using ConsoleSample.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleSample.Best.EventDrivenSample;

namespace ConsoleSample.Services
{
  public class ProductService
  {
    // Eventleri servisler içerisine encapsulate ettik.
    public void ChangePrice(int ProductId,decimal newPrice)
    {
      EventPublisher eventPublisher = new();
      AddProductPriceSubscriber addProductPriceSubscriber = new(); // PRE SAVE
      PriceChangedEmailSubscriber sub = new(); // AFTER SAVE

      ProductRepository productRepository = new();
      var product = productRepository.FindById(ProductId);
      var oldPrice = product.Price;
      product.Price = newPrice; // Update Price

      PriceChanged @event = new(oldPrice, newPrice, ProductId);

      // PRE SAVE için Publisher 
      eventPublisher.Event  += addProductPriceSubscriber.Subscribe;
      eventPublisher.Publish(@event);
      // Exception alınırsa rollback olur ve eventler geri alınır.
      // Exception yoksa işlem commit edilmiş olur.


      // AFTER SAVE

      productRepository.Save(product); // After Hook 

 
      eventPublisher.Event-= addProductPriceSubscriber.Subscribe;
      eventPublisher.Event += sub.Subscribe;
      eventPublisher.Publish(@event);



    }

  }
}
