using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSample.Delagates
{

  // Delegate Nedir ? Delagate genel olarak bir metodu temsil eden bir türdür.
  // Delagateler Methodların referansını tutan nesnelerimiz ve bir olay gerçekleştiğinde delegate sayısında bu işlemi başka bir nesneye delege edebiliriz. Sevk edebiliriz.
  // Event güdümlü programlada tercih ettiğimiz bir geliştirme şeklidir.

  // Bu sayede aynı imzaya sahip olan farklı metotları bir arada tutabiliriz.
  public delegate void MessageHandler(string message);

  public static class Sample
  {
    // FIFO mantığı ile methodları işler.
    public static void SendEmail(string message)
    {
      Console.WriteLine("Email sent: " + message);
    } 

    public static void SendSms(string message)
    {
      Console.WriteLine("Sms sent: " + message);
    }


  }
}
