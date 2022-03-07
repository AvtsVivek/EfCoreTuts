// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public List<User> Users { get; } = new List<User>();
}

