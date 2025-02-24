using ConsoleSample.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleSample.Best.EventDrivenSample;

namespace ConsoleSample.Subscribers
{
  public class PriceChangedEmailSubscriber : ISubscriber
  {
    public void Subscribe(IEvent @event)
    {
      var data = (PriceChanged)@event;

      Console.WriteLine($"Price changed for product {data.Id} from {data.OldPrice} to {data.NewPrice}");
    }
  }
}
