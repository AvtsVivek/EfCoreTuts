

using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {

        var random = Guid.NewGuid().ToString("N").ToUpper();

        Console.WriteLine(random.Substring(0, 9));

        using var dbContext = new BlogContext();
        dbContext.Database.EnsureCreated();

        dbContext.Blogs.Add(new Blog
        {
            Name = "Blog1",
            Posts = new List<Post>
            {
                new Post { Title = "Title1" }
            }
        });

        dbContext.SaveChanges();
    }
}

public class BlogContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; } = default!;
    public DbSet<Post> Posts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        //optionsBuilder.UseNpgsql(@"Host=localhost;Username=root;Password=root;Database=PostGressTrial");
        optionsBuilder.UseSqlite("Data Source=database.sqlite");
        // Host=localhost;Username=root;Password=root;Database=Onboarding
    } 
}

public class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; } = default!;
    public List<Post> Posts { get; set; } = default!;
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; } = default!;
}