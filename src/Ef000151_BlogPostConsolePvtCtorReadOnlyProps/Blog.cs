// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

public class Blog
{
    public Blog(string name)
    {
        Name = name;
    }

    private Blog(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; private set; }
    public string Name { get; }
    public List<Post> Posts { get; } = new();
}
