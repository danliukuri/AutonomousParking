using AutomaticParking.Agents.Components;
using AutomaticParking.Agents.Data;
using AutomaticParking.Car;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

namespace AutomaticParking.Agents
{
    public class ParkingAgent : Agent
    {
        private CarData carData;
        private ParkingAgentData agentData;
        private ParkingAgentTargetData targetData;
        private ParkingAgentTargetTrackingData targetTrackingData;

        private ParkingAgentActionsHandler actionsHandler;
        private ParkingAgentMetricsCalculator metricsCalculator;
        private ParkingAgentRewardCalculator rewardCalculator;
        private ParkingAgentObservationsCollector observationsCollector;

        public override void Initialize()
        {
            var initializer = GetComponentInParent<ParkingAgentInitializer>();

            carData = initializer.InitializeCarData();
            agentData = initializer.InitializeAgentData(this);
            targetData = initializer.InitializeTargetData();
            targetTrackingData = initializer.InitializeTargetTrackingData(agentData);

            actionsHandler = new ParkingAgentActionsHandler(carData);
            metricsCalculator = new ParkingAgentMetricsCalculator(agentData, targetData, targetTrackingData);
            rewardCalculator = new ParkingAgentRewardCalculator(agentData, targetTrackingData);
            observationsCollector = new ParkingAgentObservationsCollector(agentData, targetData);
        }

        public override void OnEpisodeBegin()
        {
            agentData.Reset();
            carData.Reset();
            targetTrackingData.Reset();
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            observationsCollector.CollectAgentTransformObservations(sensor);
            observationsCollector.CollectAgentVelocityObservations(sensor);

            observationsCollector.CollectTargetTransformObservations(sensor);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            actionsHandler.HandleInputActions(actions);
            metricsCalculator.CalculateTargetTrackingMetrics();
            AddReward(rewardCalculator.CalculateReward());

            if (targetTrackingData.IsTargetReached)
                EndEpisode();
        }

        public override void Heuristic(in ActionBuffers actionsOut)
        {
            actionsHandler.HandleHeuristicInputContinuousActions(actionsOut.ContinuousActions);
            actionsHandler.HandleHeuristicInputDiscreteActions(actionsOut.DiscreteActions);
        }
    }
}