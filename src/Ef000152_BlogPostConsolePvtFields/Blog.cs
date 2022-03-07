// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

public class Blog
{
    private readonly int _id;
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
    public List<Post> Posts { get; } = new();
}
