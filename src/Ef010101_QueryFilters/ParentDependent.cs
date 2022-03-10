using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef010101_QueryFilters;

public class Principal
{
  public int Id { get; set; }
  public List<Dependent> Dependents { get; set; } = default!;
}

public class Dependent
{
  public int Id { get; set; }
  public bool SoftDeleted { get; set; }
  public int PrincipalId { get; set; }
}
