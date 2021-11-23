using Newtonsoft.Json;

namespace Anvil.API
{
  /// <summary>
  /// A simple color picker, with no borders or spacing.
  /// </summary>
  public sealed class NuiColorPicker : NuiWidget
  {
    public override string Type
    {
      get => "color_picker";
    }

    [JsonConstructor]
    public NuiColorPicker(NuiProperty<NuiColor> color)
    {
      Color = color;
    }

    [JsonProperty("value")]
    public NuiProperty<NuiColor> Color { get; set; }
  }
}