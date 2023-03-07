using AutomaticParking.Car;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentInitializer : MonoBehaviour
    {
        [SerializeField] public Transform target;

        public ParkingAgentData Initialize()
        {
            var data = new ParkingAgentData
            {
                CarData = GetComponentInChildren<CarData>(),
                Rigidbody = GetComponent<Rigidbody>(),
                Transform = transform
            };
            data.InitialPosition = data.Transform.position;
            data.InitialRotation = data.Transform.rotation;

            data.TargetTrackingData = new()
            {
                Transform = target,
                InitialDistanceToTarget = Vector3.Distance(data.InitialPosition, target.position),
                InitialAngleToTarget = Quaternion.Angle(data.InitialRotation, target.rotation)
            };
            
            data.ActionsHandler = new ParkingAgentActionsHandler(data.CarData);
            data.RewardCalculator = new ParkingAgentRewardCalculator(data, data.TargetTrackingData);
            data.ObservationsCollector = new ParkingAgentObservationsCollector(data);
            return data;
        }
    }
}