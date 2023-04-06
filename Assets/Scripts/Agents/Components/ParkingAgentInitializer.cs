using AutomaticParking.Agents.Data;
using AutomaticParking.Agents.Target;
using AutomaticParking.Car;
using AutomaticParking.ParkingLot;
using UnityEngine;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentInitializer : MonoBehaviour
    {
        [field: SerializeField] public ParkingAgentTargetInitializer TargetInitializer { get; private set; }
        [field: SerializeField] public ParkingLotInitializer ParkingLotInitializer { get; private set; }

        public void InitializeExternal(ParkingAgent agent)
        {
            agent.ParkingLotInitializer = ParkingLotInitializer;
            agent.TargetInitializer = TargetInitializer;
        }

        public void InitializeData(ParkingAgent agent)
        {
            agent.CarData = GetComponentInChildren<CarData>();
            agent.AgentData = InitializeAgentData();
            agent.TargetTrackingData = new ParkingAgentTargetTrackingData();

            ParkingAgentData InitializeAgentData()
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

        public void InitializeComponents(ParkingAgent agent)
        {
            CarData carData = agent.CarData;
            ParkingAgentData agentData = agent.AgentData;
            ParkingAgentTargetData targetData = TargetInitializer.TargetData;
            ParkingAgentTargetTrackingData targetTrackingData = agent.TargetTrackingData;

            agent.ActionsHandler = new ParkingAgentActionsHandler(carData);
            agent.MetricsCalculator = new ParkingAgentMetricsCalculator(agentData, targetData, targetTrackingData);
            agent.RewardCalculator = new ParkingAgentRewardCalculator(agentData, targetTrackingData);
            agent.ObservationsCollector = new ParkingAgentObservationsCollector(agentData, targetData);
        }
    }
}