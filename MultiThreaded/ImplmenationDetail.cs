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
      return await Task.Run(() => "look here");
    }
  }

  public class OrDetail : IShowStuff
  {
    public Task<string> Show()
    {
      return Task.Run(() => "look at me");
    }
  }
}
