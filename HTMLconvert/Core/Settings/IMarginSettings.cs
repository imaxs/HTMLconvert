namespace HTMLconvert.Core.Settings
{
    public interface IMarginSettings : ISettings
    {
        public Unit Unit { get; set; }

        public double? Top { get; set; }

        public double? Bottom { get; set; }

        public double? Left { get; set; }

        public double? Right { get; set; }
        
        public string GetMarginValue(double? value);
    }
}