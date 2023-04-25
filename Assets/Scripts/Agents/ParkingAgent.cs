using AutomaticParking.Agents.Components;
using AutomaticParking.Agents.Data;
using AutomaticParking.Car;
using AutomaticParking.ParkingLot.ObjectPlacers;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgent : Agent
    {
        [field: SerializeField] public ParkingAgentData AgentData { get; private set; }
        [field: SerializeField] public ParkingAgentTargetTrackingData TargetTrackingData { get; private set; }
        [field: SerializeField] public ParkingAgentRewardData RewardData { get; private set; }
        public CarData CarData { get; set; }
        public ParkingAgentTargetData TargetData { get; set; }
        public ParkingAgentCollisionData CollisionData { get; set; }

        public ParkingLotEnteringCarPlacer AgentPlacer { get; set; }
        public ParkingLotAgentTargetPlacer TargetPlacer { get; set; }
        public ParkingLotParkedCarsPlacer ParkedCarsPlacer { get; set; }

        public ParkingAgentActionsHandler ActionsHandler { get; set; }
        public ParkingAgentMetricsCalculator MetricsCalculator { get; set; }
        public ParkingAgentRewardCalculator RewardCalculator { get; set; }
        public ParkingAgentObservationsCollector ObservationsCollector { get; set; }
        public ParkingAgentCollisionsHandler CollisionsHandler { get; set; }
        public ParkingAgentStatsRecorder StatsRecorder { get; set; }

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

            ParkedCarsPlacer.Remove();
            ParkedCarsPlacer.Place();
            AgentPlacer.Place(AgentData.Transform);
            TargetPlacer.Place(TargetData.Transform, AgentData.Transform);

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

            bool isNeededToEndEpisode = CollisionData.IsAnyCollision || TargetTrackingData.IsPerfectlyParked;
            bool isLastStep = AgentData.HasReachedMaxStep || isNeededToEndEpisode;

            if (isLastStep)
                StatsRecorder.RecordStats();

            if (isNeededToEndEpisode)
                EndEpisode();

            CollisionData.Reset();
        }

        public override void Heuristic(in ActionBuffers actionsOut)
        {
            ActionsHandler.HandleHeuristicInputContinuousActions(actionsOut.ContinuousActions);
            ActionsHandler.HandleHeuristicInputDiscreteActions(actionsOut.DiscreteActions);
        }
    }
}