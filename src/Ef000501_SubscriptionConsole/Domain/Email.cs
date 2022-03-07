using Ef000501_SubscriptionConsole.SharedKernel;

namespace Ef000501_SubscriptionConsole.Domain;

public class Email : ValueObject
{
  public string Value { get; }

  public Email(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      throw new ArgumentNullException(nameof(value));
    }

    if (value.Length > 320)
    {
      throw new ArgumentOutOfRangeException("value is too long");
    }
    //more validations
    Value = value;
  }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
