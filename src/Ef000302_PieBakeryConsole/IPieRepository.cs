namespace Ef000302_PieBakeryConsole;

internal interface IPieRepository
{
  Task<IEnumerable<Pie>> FindAllAsync(int pageIndex);
  Task<Pie> FindByIdAsync(Guid id);
  Task<Pie> SaveAsync(Pie pie);
}
