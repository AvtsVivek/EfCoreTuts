using PluralsightDdd.SharedKernel;

namespace MeWurk.Hrms.CompanyOnboarding.Core.CompanyAggregate;

// This should be a value object.
// https://tall-nova-c74.notion.site/Company-Profile-1d2a0d5a3ba347e9bee7912f48c8c646
public class CompanyProfileWallpaper : ValueObject
{
  public CompanyProfileWallpaper(string name, string description, byte[] wallpaperImage)
  {
    Name = name ?? throw new ArgumentNullException(nameof(name));
    Description = description;
    WallpaperImage = wallpaperImage ?? throw new ArgumentNullException(nameof(wallpaperImage));
  }
  public string Name { get; private set; }
  public string Description { get; private set; }
  public byte[] WallpaperImage { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Name;
    yield return WallpaperImage;
  }
}
