namespace AutomaticParking.Common.Extensions
{
    public static class FloatExtensions
    {
        public static float Normalize(this float value, float min, float max) => (value - min) / (max - min);

        public static float ChangeBounds(this float value, float oldMin, float oldMax, float newMin, float newMax) =>
            value.Normalize(oldMin, oldMax) * (newMax - newMin) + newMin;
    }
}