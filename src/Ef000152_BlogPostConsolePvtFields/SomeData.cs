namespace Ef000152_BlogPostConsolePvtFields;

internal class SomeData
{
  public static Blog GetABlogWithThreePosts()
  {
    return new Blog(".Net Blog")
    {
      Posts = {
                    new Post{
                        Title = "The new Ef 5.0",
                        Content = "Ohh...Many to Many in Ef 5 !!!"
                    },
                    new Post{
                        Title = "The new and improved F#",
                        Content = "Did you know F# improved a lot these days?"
                    },
                    new Post{
                        Title = "Actually, .net 6 is already out",
                        Content = "Yaa... I know"
                    }
                }
    };
  }

  public static Blog GetABlogWithFivePosts()
  {
    return new Blog(".Net Blog")
    {
      Posts = {
                    new Post{
                        Title = "The new Ef 5.0",
                        Content = "Ohh...Many to Many in Ef 5 !!!"
                    },
                    new Post{
                        Title = "The new and improved F#",
                        Content = "Did you know F# improved a lot these days?"
                    },
                    new Post{
                        Title = "Actually, .net 6 is already out",
                        Content = "Yaa... I know"
                    },
                    new Post{
                        Title = "What about C#",
                        Content = "Yes, I know there are many in that as well"
                    },
                    new Post{
                        Title = "Hot reloading ",
                        Content = "Ya.. thats a very big improvement...We were chasing from 10 years."
                    }
                }
    };
  }
}
