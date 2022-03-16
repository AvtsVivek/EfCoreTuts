using Ef010101_QueryFilters;
using Microsoft.EntityFrameworkCore;


namespace Ef010101_QueryFilters.Test;

public class SqliteSingleEntityContextTests : SingleEntityContextTests
{
  public SqliteSingleEntityContextTests()
      : base(new DbContextOptionsBuilder<SingleEntityContext>()
              .UseSqlite("Filename=SingleEntityTest.db").Options)
  {

  }
}

public class SqliteParentDependentDbContextTests : ParentDependentDbContextTests
{
  public SqliteParentDependentDbContextTests()
      : base(new DbContextOptionsBuilder<ParentDependentDbContext>()
              .UseSqlite("Filename=ParentDependentTest.db").Options)
  {

  }
}
