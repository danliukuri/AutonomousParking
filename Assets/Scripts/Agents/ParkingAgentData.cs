using AutomaticParking.Car;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentData : MonoBehaviour
    {
        [field: SerializeField] public Transform Target { get; private set; }
        public Transform Transform { get; private set; }

        public CarData CarData { get; private set; }

        public ParkingAgentActionsHandler ActionsHandler { get; private set; }
        public ParkingAgentRewardCalculator RewardCalculator { get; private set; }

        public Vector3 InitialPosition { get; private set; }
        public Quaternion InitialRotation { get; private set; }

        public float PreviousDistanceToTarget { get; set; }
        public float PreviousAngleToTarget { get; set; }

        private void Awake()
        {
            Transform = transform;
            CarData = GetComponentInChildren<CarData>();

            ActionsHandler = GetComponentInChildren<ParkingAgentActionsHandler>();
            RewardCalculator = new ParkingAgentRewardCalculator(this);

            InitialPosition = Transform.position;
            InitialRotation = Transform.rotation;
        }

        public void Reset()
        {
            CarData.Reset();

            Transform.position = InitialPosition;
            Transform.rotation = InitialRotation;

            PreviousDistanceToTarget = Vector3.Distance(Transform.position, Target.position);
            PreviousAngleToTarget = Quaternion.Angle(Transform.rotation, Target.rotation);
        }
    }
}