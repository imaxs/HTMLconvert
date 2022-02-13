using System.Globalization;

namespace HTMLconvert.Core.Settings
{
    public class MarginSettings : ISettings
    {
        public Unit Unit { get; set; }

        public double? Top { get; set; }

        public double? Bottom { get; set; }

        public double? Left { get; set; }

        public double? Right { get; set; }

        public MarginSettings()
        {
            Unit = Unit.Millimeters;
        }

        public MarginSettings(double top, double right, double bottom, double left) : this()
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }

        public string GetMarginValue(double? value)
        {
            if (!value.HasValue)
                return null;

            string strUnit = String.Empty;

            switch (Unit)
            {
                case Unit.Inches: strUnit = "in";
                    break;
                case Unit.Millimeters: strUnit = "mm";
                    break;
                case Unit.Centimeters: strUnit = "cm";
                    break;
                default: strUnit = "in";
                    break;
            }

            return value.Value.ToString("0.##", CultureInfo.InvariantCulture) + strUnit;
        }
    }
}