using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSample.Best
{

  public class EventDrivenSample
  {
    // işaretleme interface
    public interface IEvent
    {
    }

    // EventArgumanı
    public class TestEvent : IEvent
    {
      public string Name { get; set; }
    }

    public delegate void IEventHandler(IEvent @event);


    // IPublisher Interface Eventlerin gönderimi için bir arayüz yaptık.
    public interface IPublisher
    {
      event IEventHandler Event;
      void Publish(IEvent @event);
    }


    public class EventPublisher : IPublisher
    {
      public event IEventHandler Event; // fırlatılacak olan Eventimiz

      public void Publish(IEvent @event)
      {
        Event?.Invoke(@event); // Eventi Invoke methodu ile delegate üzerinden fırlattık.
      }
    }

    public interface ISubscriber
    {
      void Subscribe(IEvent @event); // Delegate ile Eventlerin dinlenmesi için bir arayüz oluşturduk.
    }


    // TestEventine ait Subsciber sadece TestEventini dinlesin
    public class TestEventLogSubsciber: ISubscriber
    {
      public void Subscribe(IEvent @event)
      {
        Console.WriteLine("Log");
        Console.WriteLine(((TestEvent)@event).Name);
      }
    }

    public class TestEventEmailSubscriber : ISubscriber
    {
      public void Subscribe(IEvent @event)
      {
        Console.WriteLine("Email");
        Console.WriteLine(((TestEvent)@event).Name);
      }
    }


  }
  



}
