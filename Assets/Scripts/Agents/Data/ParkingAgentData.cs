using UnityEngine;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentData
    {
        public Rigidbody Rigidbody { get; set; }
        public Transform Transform { get; set; }
        public Vector3 InitialPosition { get; set; }
        public Quaternion InitialRotation { get; set; }

        public void Reset()
        {
            Rigidbody.velocity = default;
            Transform.position = InitialPosition;
            Transform.rotation = InitialRotation;
        }
    }
}