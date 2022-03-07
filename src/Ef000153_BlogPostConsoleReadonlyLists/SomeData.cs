namespace Ef000153_BlogPostConsoleReadonlyLists;

internal class SomeData
{
  public static Blog GetABlogWithThreePosts()
  {
    var blog = new Blog(".Net Blog");

    blog.AddPost(new Post
    {
      Title = "The new Ef 5.0",
      Content = "Ohh...Many to Many in Ef 5 !!!"
    });

    blog.AddPost(new Post
    {
      Title = "The new and improved F#",
      Content = "Did you know F# improved a lot these days?"
    });

    blog.AddPost(new Post
    {
      Title = "Actually, .net 6 is already out",
      Content = "Yaa... I know"
    });

    return blog;

  }

  public static Blog GetABlogWithFivePosts()
  {
    var blog = new Blog(".Net Blog");

    blog.AddPost(new Post
    {
      Title = "The new Ef 5.0",
      Content = "Ohh...Many to Many in Ef 5 !!!"
    });

    blog.AddPost(new Post
    {
      Title = "The new and improved F#",
      Content = "Did you know F# improved a lot these days?"
    });

    blog.AddPost(new Post
    {
      Title = "Actually, .net 6 is already out",
      Content = "Yaa... I know"
    });

    blog.AddPost(new Post
    {
      Title = "What about C#",
      Content = "Yes, I know there are many in that as well"
    });

    blog.AddPost(new Post
    {
      Title = "Hot reloading ",
      Content = "Ya.. thats a very big improvement...We were chasing from 10 years."
    });

    return blog;
  }
}
