using UnityEngine;

namespace AutonomousParking.Agents.Data
{
    public class ParkingAgentTargetData : MonoBehaviour
    {
        [field: SerializeField] public float ParkingRadius { get; private set; } = 0.5f;
        [field: SerializeField] public float ParkingAngle { get; private set; } = 6f;
        [field: SerializeField] public float PerfectParkingRadius { get; private set; } = 0.15f;
        [field: SerializeField] public float PerfectParkingAngle { get; private set; } = 2f;

        public Transform Transform { get; private set; }

        private void Awake() => Transform = transform;
    }
}