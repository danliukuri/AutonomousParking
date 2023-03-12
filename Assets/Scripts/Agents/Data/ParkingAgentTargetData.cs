using UnityEngine;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentTargetData : MonoBehaviour
    {
        [field: SerializeField] public float ReachRadius { get; private set; } = 0.15f;
        [field: SerializeField] public float ReachAngle { get; private set; } = 2f;

        public Transform Transform { get; private set; }

        private void Awake() => Transform = transform;
    }
}