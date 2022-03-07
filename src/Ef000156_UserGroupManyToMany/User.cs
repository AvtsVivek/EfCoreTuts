// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public List<Group> Groups { get; } = new List<Group>();
}
