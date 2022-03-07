// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
  public string Content { get; set; } = default!;
  public Blog Blog { get; set; } = default!;
  private readonly List<Tag> _tags = new List<Tag>();
    public IReadOnlyList<Tag> Tags => _tags;
    public Post AddTag(Tag tag)
    {
        _tags.Add(tag);
        return this;
    }
}


public class Tag
{
    public int Id { get; set; }
    public string Text { get; set; } = default!;
  public ICollection<Post> Posts { get; } = new List<Post>();
}
