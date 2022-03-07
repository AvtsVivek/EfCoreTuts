namespace Ef000302_PieBakeryConsole;

public record Portions
{
  public int Minimum { get; private set; } // Why not init
  public int Maximum { get; private set; } // Why not init

  public Portions(int minimum, int maximum)
  {
    if (minimum < 1) throw new ArgumentException("Minimum must be above zero.", nameof(minimum));
    if (maximum < 1) throw new ArgumentException("Maximum must be above zero.", nameof(maximum));
    if (maximum <= minimum) throw new ArgumentException("Maximum must be above minimum.", nameof(maximum));

    Minimum = minimum;
    Maximum = maximum;
  }
}
