using System.Collections.Generic;
using Newtonsoft.Json;

namespace Anvil.API
{
  /// <summary>
  /// A list of options (radio buttons).<br/>
  /// Only one can be selected at a time.
  /// </summary>
  public sealed class NuiOptions : NuiElement
  {
    public override string Type
    {
      get => "options";
    }

    [JsonProperty("value")]
    public NuiProperty<int> Selection { get; set; } = -1;

    [JsonProperty("direction")]
    public NuiDirection Direction { get; set; } = NuiDirection.Horizontal;

    [JsonProperty("elements")]
    public List<string> Options { get; set; } = new List<string>();
  }
}
