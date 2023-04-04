using AutomaticParking.Agents.Data;
using AutomaticParking.Car;
using AutomaticParking.ParkingLot;
using UnityEngine;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentInitializer : MonoBehaviour
    {
        [field: SerializeField] public ParkingAgentTargetData TargetData { get; private set; }
        [field: SerializeField] public ParkingLotInitializer ParkingLotInitializer { get; private set; }

        public CarData InitializeCarData() => GetComponentInChildren<CarData>();

        public ParkingAgentData InitializeAgentData(ParkingAgent agent)
        {
            var agentRigidbody = GetComponent<Rigidbody>();
            var agentTransform = GetComponent<Transform>();
            return new ParkingAgentData(agent)
            {
                Rigidbody = agentRigidbody,
                Transform = agentTransform,
                InitialPosition = agentTransform.position,
                InitialRotation = agentTransform.rotation
            };
        }
    }
}