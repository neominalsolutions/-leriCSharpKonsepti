
using ConsoleSample.Delagates;

public class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello World!");

    DelegateSamples();

    MessageHandler del2 = Sample.SendEmail;
    del2 += Sample.SendSms;
    Log(del2);

  }

  public static void DelegateSamples()
  {
    // Delegate Sample.SendEmail methodundan sorumlu olsun
    MessageHandler del = Sample.SendEmail;
    del += Sample.SendSms; // multicast kullanım örneği
    del("Message1");

    del -= Sample.SendEmail; // subscription kaldırma
    del("Message2");

  }

  // Delegate başka bir methoda paramete olarak gönderilebilir.
  // bu durumda işlem sonrası iş akışını devam ettirebiliriz.
  public static void Log(MessageHandler callback)
  {
    Console.WriteLine("Log started");
    callback("Log message");
    Console.WriteLine("Log ended");
  }
}


