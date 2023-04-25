using AutomaticParking.Agents.Data;
using AutomaticParking.Car;
using AutomaticParking.ParkingLot.ObjectPlacers;
using UnityEngine;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentInitializer : MonoBehaviour
    {
        [field: SerializeField] private ParkingAgentTargetData targetData;

        [field: SerializeField] private ParkingLotEnteringCarPlacer agentPlacer;
        [field: SerializeField] private ParkingLotAgentTargetPlacer targetPlacer;
        [field: SerializeField] private ParkingLotParkedCarsPlacer parkedCarsPlacer;

        public void InitializeExternal(ParkingAgent agent)
        {
            agent.TargetData = targetData;

            agent.AgentPlacer = agentPlacer;
            agent.TargetPlacer = targetPlacer;
            agent.ParkedCarsPlacer = parkedCarsPlacer;
        }

        public void InitializeData(ParkingAgent agent)
        {
            agent.CarData = GetComponentInChildren<CarData>();
            agent.CollisionData = new ParkingAgentCollisionData();

            agent.AgentData.Agent = agent;
            agent.AgentData.Rigidbody = GetComponent<Rigidbody>();
            agent.AgentData.Transform = GetComponent<Transform>();
        }

        public void InitializeComponents(ParkingAgent agent)
        {
            CarData carData = agent.CarData;
            ParkingAgentData agentData = agent.AgentData;
            ParkingAgentTargetTrackingData targetTrackingData = agent.TargetTrackingData;
            ParkingAgentCollisionData collisionData = agent.CollisionData;

            agent.ActionsHandler = new ParkingAgentActionsHandler(carData);
            agent.MetricsCalculator = new ParkingAgentMetricsCalculator(agentData, targetData, targetTrackingData);
            agent.RewardCalculator = new ParkingAgentRewardCalculator(agentData, targetTrackingData, collisionData);
            agent.ObservationsCollector = new ParkingAgentObservationsCollector(agentData, targetData);
            agent.CollisionsHandler = GetComponent<ParkingAgentCollisionsHandler>().Initialize(collisionData);
            agent.StatsRecorder = new ParkingAgentStatsRecorder(collisionData, targetTrackingData);
        }
    }
}