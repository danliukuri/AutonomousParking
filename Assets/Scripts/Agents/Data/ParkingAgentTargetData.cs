using UnityEngine;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentTargetData : MonoBehaviour
    {
        [field: SerializeField] public float ParkingRadius { get; private set; } = 0.5f;
        [field: SerializeField] public float ParkingAngle { get; private set; } = 6f;

        public Transform Transform { get; private set; }

        private void Awake() => Transform = transform;
    }
}