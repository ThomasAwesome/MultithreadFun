using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskMagic
{
  public class DoCoolStuff
  {
    private HttpClient client = new HttpClient();

    public void Authenicate() { Task.Delay(5000).Wait(); }

    public string MakeRequestForData()
    {
      Task.Delay(2000).Wait();
      var text = client.GetStringAsync("https://www.google.com").Result;
      return text;
    }
  }
}
