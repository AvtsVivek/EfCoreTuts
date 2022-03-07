using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MeWurk.Hrms.CompanyOnboarding.Core.DataAccess;

public interface IDataContextTransaction
{
  void BeginTransaction();
  void Commit();
  void Rollback();
  // https://gunnarpeipman.com/ef-core-repository-unit-of-work/
}
public abstract class BaseDbContext : DbContext, IDataContextTransaction
{
  public BaseDbContext() { }
  public BaseDbContext(DbContextOptions options)
      : base(options) { }

  private IDbContextTransaction _transaction = default!;
  public void BeginTransaction()
  {
    _transaction = Database.BeginTransaction();
  }

  public void Commit()
  {
    try
    {
      SaveChanges();
      _transaction.Commit();
    }
    finally
    {
      _transaction.Dispose();
    }
  }

  public void Rollback()
  {
    _transaction.Rollback();
    _transaction.Dispose();
  }
}
