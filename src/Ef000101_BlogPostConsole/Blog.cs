namespace Ef000101_BlogPostConsole;

public class Blog
{
  public int Id { get; set; }
  public string Url { get; set; } = default!;
  protected virtual List<Post> Posts { get; set; } = default!;
}
