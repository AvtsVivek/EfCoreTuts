namespace Ef000201_GetStartedConsole;

public class Blog
{
  public int BlogId { get; set; }
  public string Url { get; set; } = default!;
  public List<Post> Posts { get; } = new();
}
