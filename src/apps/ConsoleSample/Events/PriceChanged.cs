using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleSample.Best.EventDrivenSample;

namespace ConsoleSample.Events
{
  public class PriceChanged:IEvent
  {
    public PriceChanged(decimal oldPrice, decimal newPrice, int id)
    {
      OldPrice = oldPrice;
      NewPrice = newPrice;
      Id = id;
    }

    // which net version use init properties
    // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
   
    public decimal OldPrice { get; init; }
    public decimal NewPrice { get; init; }
    public int Id { get; init; }

       

  }
}
