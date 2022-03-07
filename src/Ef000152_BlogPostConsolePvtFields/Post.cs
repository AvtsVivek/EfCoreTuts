// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
  public string Content { get; set; } = default!;
  public Blog Blog { get; set; } = default!;
}
