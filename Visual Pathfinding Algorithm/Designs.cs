using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Pathfinding_Algorithm
{
  public static class Designs
  {
    /// <summary>
    /// Color interpolation.
    /// </summary>
    /// <param name="s">Color to be used against</param>
    /// <param name="t">Color to be tranformed into</param>
    /// <param name="k">Color strength</param>
    /// <returns></returns>
    public static Color Lerp(this Color s, Color t, float k)
    {
      var bk = (1 - k);
      var a = s.A * bk + t.A * k;
      var r = s.R * bk + t.R * k;
      var g = s.G * bk + t.G * k;
      var b = s.B * bk + t.B * k;
      return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
    }
  }
}
