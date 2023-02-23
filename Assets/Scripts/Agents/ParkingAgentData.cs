using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentData : MonoBehaviour
    {
        [field: SerializeField] public Transform Target { get; private set; }
        public Transform Transform { get; private set; }

        public ParkingAgentActionsHandler ActionsHandler { get; private set; }

        public float PreviousDistanceToTarget { get; set; }
        public float PreviousAngleToTarget { get; set; }

        private void Awake()
        {
            Transform = transform;
            ActionsHandler = GetComponentInChildren<ParkingAgentActionsHandler>();
        }

        public void Reset()
        {
            PreviousDistanceToTarget = Vector3.Distance(Transform.position, Target.position);
            PreviousAngleToTarget = Quaternion.Angle(Transform.rotation, Target.rotation);
        }
    }
}