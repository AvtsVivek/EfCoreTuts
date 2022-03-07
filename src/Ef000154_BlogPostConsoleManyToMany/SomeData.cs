namespace Ef000154_BlogPostConsoleManyToMany;

internal class SomeData
{
  public static ICollection<Tag> GetSomeTags()
  {
    return new List<Tag>{
                new Tag{Text = ".NET"},
                new Tag{ Text = "Ef"}
            };
  }

  public static Blog GetABlogWithPostsWithTags()
  {
    var tags = GetSomeTags().ToArray();
    var blog = new Blog(".Net Blog");

    blog.AddPost(new Post
    {
      Title = "Announcing the release of Ef core 6.0",
      Content = "Announcing the release of Ef core 6.0, with full featured cross platform",
    }.AddTag(tags[0]).AddTag(tags[1]));

    blog.AddPost(new Post
    {
      Title = "The new and improved F#",
      Content = "Did you know F# improved a lot these days?",
    }.AddTag(tags[0]));

    blog.AddPost(new Post
    {
      Title = "Actually, .net 6 is already out",
      Content = "Yaa... I know",
    }.AddTag(tags[0]));

    return blog;
  }
}
