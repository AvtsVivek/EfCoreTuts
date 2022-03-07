using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightDdd.SharedKernel;

namespace MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;

public class Subscription : BaseEntity<ulong>
{
  public long CompanyId { get; private set; } = default!;
  public string BillingCycle { get; private set; } = default!;
  public string SubscriptionStatus { get; private set; } = default!;
  public string BillingType { get; private set; } = default!; // Using Credit card or cheque etc.
  public string Plan { get; private set; } = default!; // Free for ever etc.
  public List<string> BillingVariables { get; private set; } = default!;
}
