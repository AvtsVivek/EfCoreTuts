// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

public class Blog
{
    private readonly int _id;
    private readonly List<Post> _posts = new List<Post>();
    public Blog(string name)
    {
        Name = name;
    }

    private Blog(int id, string name)
    {
        _id = id;
        Name = name;
    }
    public string Name { get; }
    public IReadOnlyList<Post> Posts => _posts;

    public void AddPost(Post post)
    {
        // Add any constraints on this post object as the business rules dectate.
        // Do validation etc, if they dont pass, throw an exception.
        _posts.Add(post);
    }
}
