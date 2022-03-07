namespace Ef000156_UserGroupManyToMany;

internal class SomeData
{
  private static User vivek = new User { Name = "Vivek" };
  private static User bala = new User { Name = "Bala" };
  private static User naga = new User { Name = "Nagabhushan" };
  private static User daasari = new User { Name = "Daasari" };
  private static User pradhnya = new User { Name = "Pradhnya" };
  private static User nivesh = new User { Name = "Nivesh" };
  private static User sunil = new User { Name = "Sunil" };
  private static User akhilesh = new User { Name = "Akhilesh" };
  private static User amit = new User { Name = "Amit" };
  private static User vinay = new User { Name = "Vinay" };
  private static User devendra = new User { Name = "Devendra" };
  private static User hari = new User { Name = "Hari" };
  private static User sumit = new User { Name = "Sumit" };
  private static User sonal = new User { Name = "Sonal" };


  private static Group backend = new Group { Name = "Backend" };
  private static Group frontend = new Group { Name = "Frontend" };
  private static Group product = new Group { Name = "Product" };
  private static Group hr = new Group { Name = "Hr" };
  private static Group all = new Group { Name = "All" };

  public static ICollection<User> GetSomeUsers()
  {
    //var vivek = new User { Name = "Vivek" };
    //var bala = new User { Name = "Bala" };
    //var naga = new User { Name = "Nagabhushan" };
    //var daasari = new User { Name = "Daasari" };

    //var pradhnya = new User { Name = "Pradhnya" };
    //var nivesh = new User { Name = "Nivesh" };
    //var sunil = new User { Name = "Sunil" };
    //var akhilesh = new User { Name = "Akhilesh" };

    //var amit = new User { Name = "Amit" };
    //var vinay = new User { Name = "Vinay" };
    //var devendra = new User { Name = "Devendra" };
    //var hari = new User { Name = "Hari" };

    //var sumit = new User { Name = "Sumit" };
    //var sonal = new User { Name = "Sonal" };
    return new List<User>() {
                vivek, bala, naga, daasari, pradhnya, nivesh, sunil,
      akhilesh, amit, vinay, devendra, hari, sumit, sonal
            };
  }

  public static ICollection<Group> GetSomeGroups()
  {
    return new List<Group>() {
                backend, frontend, product, hr, all,
            };
  }

  public static void AssociateGroupsToUsers()
  {
    backend.Users.AddRange(new[] { vivek, bala, naga, daasari });
    frontend.Users.AddRange(new[] { pradhnya, nivesh, sunil, akhilesh });
    product.Users.AddRange(new[] { amit, vinay, devendra, hari });
    hr.Users.AddRange(new[] { sonal, sumit });
    all.Users.AddRange(new[] { vivek, bala, naga, daasari, pradhnya, nivesh,
      sunil, akhilesh, amit, vinay, devendra, hari, sumit, sonal });
  }
}
