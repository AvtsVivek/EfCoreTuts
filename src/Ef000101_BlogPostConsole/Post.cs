namespace Ef000101_BlogPostConsole;

public class Post
{
  public int Id { get; set; }
  public string Title { get; set; } = default!;
  public string Content { get; set; } = default!;
  //public int BlogId { get; set; }
  public virtual Blog Blog { get; set; } = default!;
}
