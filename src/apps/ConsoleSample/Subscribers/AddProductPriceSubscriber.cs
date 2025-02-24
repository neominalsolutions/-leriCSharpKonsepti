using ConsoleSample.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleSample.Best.EventDrivenSample;

namespace ConsoleSample.Subscribers
{
  public class AddProductPriceSubscriber : ISubscriber
  {
    public void Subscribe(IEvent @event)
    {
      var data = (PriceChanged)@event;
      Console.WriteLine("Product Fiyatı değiştiğinde buradaki listeye bir önceki fiyatın kaydının ekleyen method");
    }
  }
}
