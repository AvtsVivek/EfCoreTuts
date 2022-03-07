using Microsoft.EntityFrameworkCore;

namespace Ef000302_PieBakeryConsole;

public class PieRepository : IPieRepository
{
  private readonly BakeryDbContext _applicationDbContext;

  public PieRepository(BakeryDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task<IEnumerable<Pie>> FindAllAsync(int pageIndex)
  {
    return await _applicationDbContext.Pies
        .OrderBy(x => x.Name)
        .Skip(pageIndex * 10)
        .Take(10)
        .ToListAsync();
  }

  public async Task<Pie> FindByIdAsync(Guid id)
  {
    return await _applicationDbContext.Pies
        .Include(x => x.Portions).AsSingleQuery()
        .Include(x => x.Ingredients).AsSplitQuery()
        //.SingleOrDefaultAsync(x => x.Id == id);
        .SingleAsync(x => x.Id == id);
    // If you are going to get these ingredents, dont include them in the join statements.
    // Because the sql statements become too large and perform badly.
    // Execute a second sql command, get those ingredents and then add
    // them in memory to the pie's ingredents collection.
  }

  public async Task<Pie> SaveAsync(Pie pie)
  {
    await _applicationDbContext.Pies.AddAsync(pie);
    await _applicationDbContext.SaveChangesAsync();

    return pie;
  }
}


