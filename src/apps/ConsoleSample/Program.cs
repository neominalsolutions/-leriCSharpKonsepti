
using ConsoleSample.Delagates;

public class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello World!");
    //DelegateSamples01();
    //DelegateSamples02();
    DelegateSample03();

  }

  public static void DelegateSamples01()
  {
    // Delegate Sample.SendEmail methodundan sorumlu olsun
    MessageHandler del = Sample.SendEmail;
    del += Sample.SendSms; // multicast kullanım örneği
    del("Message1");

    del -= Sample.SendEmail; // subscription kaldırma
    del("Message2");

  }

  public static void DelegateSamples02()
  {
    #region Delagates


    MessageHandler del2 = Sample.SendEmail;
    del2 += Sample.SendSms; // Subscription
    Log(del2);

    // Runtime üzerinden Delegate yapısı kullanıma örnek

    Console.WriteLine("Hangi tipte gönderim yapmak istersiniz ?");
    string methodName = Console.ReadLine();

    // Not: bu kodu eğer delegate üzerinden dinamik olarak çağıramasaydık aşağıdaki gibi bir if else bloğu yazmamız gerekirdi.
    var del = (MessageHandler)Delegate.CreateDelegate(typeof(MessageHandler), typeof(Sample), methodName);

    // Bu bağımlı bir sürüdülebilir olmayan bir kod örneği
    if (methodName == "SendSMS")
    {
      Sample.SendSms("Test");
    }
    else if (methodName == "SendEmail")
    {
      Sample.SendEmail("Test");
    }


    Console.WriteLine("Mesajınızı yazınız");
    string message = Console.ReadLine();

    ArgumentNullException.ThrowIfNull(del);

    del.DynamicInvoke(message);


    // Not: dışardında içerisine parametre alan ve void dönüş tipi için kullanılan bir delegate türüdür. 
    Action<string, string> concat = (x, y) => {
      Console.WriteLine($"{x} {y}");
    };
    concat("Hello", "World");

    //List<string> names = new List<string> { "Ali", "Veli", "Deli" };
    //names.ForEach(x => Console.WriteLine(x));

    // Function delegate Action delegateden tek farkı geriye bir değer döndürmesidir.
    Func<int, int, double> avg = (x, y) => (x + y) / 2;
    double result = avg(9, 6);
    Console.WriteLine(result);


    // en çok kullanıdığı kısım eventlerde kullanılır.
    // bir işlemden sonra callback döndürmek yani işlem sonrası süreci başka bir işleme devretmek amaçlı kullanılır.
    // Asenkron programlamada sıklıkla bu tarz anonim delegate tipleri kullanılır.
    var showMessage = delegate (string message)
    {
      Console.WriteLine(message);
    };

    showMessage("Hello World");


    Log(concat);


    #endregion
  }


  // Lamda ifadelerde Where ile kullanım örneği ve Predicate ile kullanım örneği
  // Predicate Nedir ? Predicate genel olarak bir koşul ifadesi belirtir ve bu koşul ifadesine uyan tüm elemanları döndürür.
  public static void DelegateSample03()
  {

    List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]; // en yeni
    List<int> numbers2 = new List<int>(); // en eski
    List<int> numbers3 = new(); // 2.en yeni
    var numbers4 = new List<int>(); // var eski bir kısa yazım şeklidir.

    Func<int, bool> isOdd = x =>
    {
      return x % 2 != 0;
    };

    // tek sayıların filtrelenmesi
    numbers.Where(isOdd).ToList().ForEach(x => Console.WriteLine(x));


  }


  // Delegate başka bir methoda paramete olarak gönderilebilir.
  // bu durumda işlem sonrası iş akışını devam ettirebiliriz.
  public static void Log(MessageHandler callback)
  {
    Console.WriteLine("Log started");
    callback("Log message");
    Console.WriteLine("Log ended");
  }

  public static void Log(Action<string,string> callback)
  {
    Console.WriteLine("Log started");
    callback("Hello","Word");
    Console.WriteLine("Log ended");
  }


}


