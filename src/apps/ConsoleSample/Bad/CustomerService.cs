using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSample.Bad
{

  public class EmailService {
    public void SendEmail(string message)
    {

    }
  }
  public class LogService { 
  
    public void Log(string message)
    {

    }
  }

  public class CustomerService
  {
    EmailService emailService = new EmailService();
    LogService logService = new LogService();


    public void AddCustomer(string customerName)
    {
      Console.WriteLine("Customer added: " + customerName);
      emailService.SendEmail("Email");
      logService.Log("Log");
    }
  }
}
