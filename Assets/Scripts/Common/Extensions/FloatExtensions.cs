using UnityEngine;

namespace AutomaticParking.Common.Extensions
{
    public static class FloatExtensions
    {
        public static float Normalize(this float value, float min, float max)
        {
            const float minNormalizedValue = 0f, maxNormalizedValue = 1f;
            float range = max - min;
            float normalizedValue = Mathf.Approximately(range, default) ? minNormalizedValue : (value - min) / range;
            normalizedValue = Mathf.Clamp(normalizedValue, minNormalizedValue, maxNormalizedValue);
            return normalizedValue;
        }

        public static float ChangeBounds(this float value, float oldMin, float oldMax, float newMin, float newMax) =>
            value.Normalize(oldMin, oldMax) * (newMax - newMin) + newMin;
    }
}