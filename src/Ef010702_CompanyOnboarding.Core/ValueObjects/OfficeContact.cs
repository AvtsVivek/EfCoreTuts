using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightDdd.SharedKernel;

namespace Ef010702_CompanyOnboarding.Core.ValueObjects;

public class OfficeContact : ValueObject
{
  public OfficeContact(string email, string phoneNumber)
  {
    Email = email ?? throw new ArgumentNullException("Both Email and phone number are needed");
    PhoneNumber = phoneNumber ?? throw new ArgumentNullException("Both Email and phone number are needed");
  }
  public string? Email { get; private set; }
  public string? PhoneNumber { get; private set; }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return new object[] { Email!, PhoneNumber! };
  }
}
