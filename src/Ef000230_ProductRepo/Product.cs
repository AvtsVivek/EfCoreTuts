using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef000230_ProductRepo;

public class Product
{
  public int Id { get; set; }
  public string Name { get; set; } = default!;
  public bool IsAvailable { get; set; }
}
