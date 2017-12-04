using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreaded
{
  public interface IShowStuff
  {
    Task<string> Show();
  }

  public class ImplmenationDetail : IShowStuff
  {
    public async Task<string> Show()
    {
      return await Task.FromResult("look here");
    }
  }

  public class OrDetail : IShowStuff
  {
    public Task<string> Show()
    {
      return new Task<string>(() => "look here");
    }
  }
}
