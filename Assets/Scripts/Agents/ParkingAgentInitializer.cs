using AutomaticParking.Car;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentInitializer : MonoBehaviour
    {
        [SerializeField] public Transform target;

        public ParkingAgentData Initialize()
        {
            var data = new ParkingAgentData();
            data.Target = target;

            data.CarData = GetComponentInChildren<CarData>();
            data.Rigidbody = GetComponent<Rigidbody>();
            data.Transform = transform;
            data.InitialPosition = data.Transform.position;
            data.InitialRotation = data.Transform.rotation;

            data.ActionsHandler = new ParkingAgentActionsHandler(data.CarData);
            data.RewardCalculator = new ParkingAgentRewardCalculator(data);
            data.ObservationsCollector = new ParkingAgentObservationsCollector(data, data.Rigidbody);

            data.PreviousDistanceToTarget = Vector3.Distance(data.InitialPosition, data.Target.position);
            data.PreviousAngleToTarget = Quaternion.Angle(data.InitialRotation, data.Target.rotation);
            return data;
        }
    }
}