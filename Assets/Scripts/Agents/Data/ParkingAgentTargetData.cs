using UnityEngine;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentTargetData : MonoBehaviour
    {
        public Transform Transform { get; private set; }

        private void Awake() => Transform = transform;
    }
}