using UnityEngine;
using System.Collections;

public static class MyColor
{
    // Input: RGB color
    // Output: RGB color with inverse Hue
    public static Color Complementary(Color color)
    {
        float h, s, v;
        Color.RGBToHSV(color, out h, out s, out v);
        Debug.Log(color + " => (" + h + ", " + s + ", " + v + ")");
        h = h + 0.5F;
        if (h >= 1) h = h - 1F;
        return Color.HSVToRGB(h, s, v);
    }
}
