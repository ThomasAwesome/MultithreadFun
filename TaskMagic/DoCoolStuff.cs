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

    public async Task Authenicate()
    {
      await Task.Delay(5000);
    }

    public async Task<string> MakeRequestForData()
    {
      await Task.Delay(2000);
      return await client.GetStringAsync("https://www.google.com");
    }
  }
}
