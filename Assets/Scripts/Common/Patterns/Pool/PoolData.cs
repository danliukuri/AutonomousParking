using UnityEngine;

namespace AutonomousParking.Common.Patterns.Pool
{
    public class PoolData : MonoBehaviour
    {
        [field: SerializeField, Min(default)] public int StartCount { get; private set; }
        [field: SerializeField, Min(default)] public int StartCapacity { get; private set; }
        [field: SerializeField, Min(default)] public int MaxSize { get; private set; }
        [field: SerializeField] public bool ThrowErrorIfItemAlreadyInPoolWhenRelease { get; private set; } = true;
    }
}