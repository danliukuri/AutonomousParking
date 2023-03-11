using AutomaticParking.Agents.Components;
using AutomaticParking.Agents.Data;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

namespace AutomaticParking.Agents
{
    public class ParkingAgent : Agent
    {
        private ParkingAgentData data;

        public override void Initialize()
        {
            var initializer = GetComponentInParent<ParkingAgentInitializer>();
            data = initializer.InitializeAgentData();
            data.TargetTrackingData = initializer.InitializeTargetTrackingData(data);
            data.CarData = initializer.InitializeCarData();
            initializer.InitializeAgentDataComponents(data);
        }

        public override void OnEpisodeBegin()
        {
            data.Reset();
            data.CarData.Reset();
            data.TargetTrackingData.Reset();
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            data.ObservationsCollector.CollectAgentTransformObservations(sensor);
            data.ObservationsCollector.CollectAgentVelocityObservations(sensor);

            data.ObservationsCollector.CollectTargetTransformObservations(sensor);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            data.ActionsHandler.HandleInputActions(actions);
            data.MetricsCalculator.CalculateTargetTrackingMetrics();
            AddReward(data.RewardCalculator.CalculateReward());

            if (data.TargetTrackingData.IsTargetReached)
                EndEpisode();
        }

        public override void Heuristic(in ActionBuffers actionsOut)
        {
            data.ActionsHandler.HandleHeuristicInputContinuousActions(actionsOut.ContinuousActions);
            data.ActionsHandler.HandleHeuristicInputDiscreteActions(actionsOut.DiscreteActions);
        }
    }
}