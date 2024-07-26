namespace SlottyMedia.Components.Partial.Enum;

/// <summary>
/// Provides utility functions to convert enums to actual useful values
/// </summary>
public static class EnumUtility
{
    /// <summary>
    /// Converts ColorWay Enum and typeOfColor into a tailwind css usable class
    /// </summary>
    /// <param name="color">
    /// Naming as defined in tailwind.config.js
    /// </param>
    /// <param name="typeOfColor">
    /// Value range as defined in tailwind.config.js
    /// </param>
    /// <returns>
    /// Return a tailwind css usable css class
    /// </returns>
    /// <exception cref="Exception"></exception>
    public static string GetColorClass(ColorWay color, int typeOfColor){
        int[] allowedTypeOfColors = { 50, 100, 200,  300, 400,  500, 600, 700, 800,  900, 950};

        if (!allowedTypeOfColors.Contains(typeOfColor))
        {
            //TODO: Add customized exception when excpetion handling was planned
            throw new Exception("ColorType not defined");
        }

        switch (color)
        {
            case ColorWay.AthensGray:
                return "athens-gray-" + typeOfColor;
            case ColorWay.CadetGray:
                return "cadet-gray-" + typeOfColor;
            case ColorWay.CrayolaOrange:
                return "crayola-orange-" + typeOfColor;
            case ColorWay.RaisinBlack:
                return "raisin-black-" + typeOfColor;
            case ColorWay.SavoyBlue:
                return "savoy-blue-" + typeOfColor;
            default:
                return $"{color.ToString().ToLower()}-{typeOfColor}";
        }
    }
}