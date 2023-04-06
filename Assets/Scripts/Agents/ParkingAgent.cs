using AutomaticParking.Agents.Components;
using AutomaticParking.Agents.Data;
using AutomaticParking.Agents.Target;
using AutomaticParking.Car;
using AutomaticParking.ParkingLot;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

namespace AutomaticParking.Agents
{
    public class ParkingAgent : Agent
    {
        public CarData CarData { get; set; }
        public ParkingAgentData AgentData { get; set; }
        public ParkingAgentTargetTrackingData TargetTrackingData { get; set; }

        public ParkingLotInitializer ParkingLotInitializer { get; set; }
        public ParkingAgentTargetInitializer TargetInitializer { get; set; }

        public ParkingAgentActionsHandler ActionsHandler { get; set; }
        public ParkingAgentMetricsCalculator MetricsCalculator { get; set; }
        public ParkingAgentRewardCalculator RewardCalculator { get; set; }
        public ParkingAgentObservationsCollector ObservationsCollector { get; set; }

        public override void Initialize()
        {
            var initializer = GetComponentInParent<ParkingAgentInitializer>();
            initializer.InitializeExternal(this);
            initializer.InitializeData(this);
            initializer.InitializeComponents(this);
        }

        public override void OnEpisodeBegin()
        {
            AgentData.Reset();
            CarData.Reset();

            ParkingLotInitializer.ReInitialize();
            TargetInitializer.ReInitialize(AgentData.Transform);

            MetricsCalculator.CalculateInitialTargetTrackingMetrics();
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            ObservationsCollector.CollectAgentTransformObservations(sensor);
            ObservationsCollector.CollectAgentVelocityObservations(sensor);

            ObservationsCollector.CollectTargetTransformObservations(sensor);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            ActionsHandler.HandleInputActions(actions);
            MetricsCalculator.CalculateTargetTrackingMetrics();
            AddReward(RewardCalculator.CalculateReward());

            if (TargetTrackingData.IsTargetReached)
                EndEpisode();
        }

        public override void Heuristic(in ActionBuffers actionsOut)
        {
            ActionsHandler.HandleHeuristicInputContinuousActions(actionsOut.ContinuousActions);
            ActionsHandler.HandleHeuristicInputDiscreteActions(actionsOut.DiscreteActions);
        }
    }
}