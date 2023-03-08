namespace AutomaticParking.Common.Extensions
{
    public static class FloatExtensions
    {
        public static float Normalize(this float value, float min, float max) => (value - min) / (max - min);
    }
}