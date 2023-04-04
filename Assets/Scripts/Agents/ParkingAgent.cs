using AutomaticParking.Agents.Components;
using AutomaticParking.Agents.Data;
using AutomaticParking.Car;
using AutomaticParking.ParkingLot;
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

        private ParkingLotInitializer parkingLotInitializer;

        private ParkingAgentActionsHandler actionsHandler;
        private ParkingAgentMetricsCalculator metricsCalculator;
        private ParkingAgentRewardCalculator rewardCalculator;
        private ParkingAgentObservationsCollector observationsCollector;

        public override void Initialize()
        {
            var initializer = GetComponentInParent<ParkingAgentInitializer>();
            ExtractExisting();
            InitializeData();
            InitializeComponents();

            void ExtractExisting()
            {
                parkingLotInitializer = initializer.ParkingLotInitializer;
                targetData = initializer.TargetData;
            }

            void InitializeData()
            {
                carData = initializer.InitializeCarData();
                agentData = initializer.InitializeAgentData(this);
                targetTrackingData = new ParkingAgentTargetTrackingData();
            }

            void InitializeComponents()
            {
                actionsHandler = new ParkingAgentActionsHandler(carData);
                metricsCalculator = new ParkingAgentMetricsCalculator(agentData, targetData, targetTrackingData);
                rewardCalculator = new ParkingAgentRewardCalculator(agentData, targetTrackingData);
                observationsCollector = new ParkingAgentObservationsCollector(agentData, targetData);
            }
        }

        public override void OnEpisodeBegin()
        {
            agentData.Reset();
            carData.Reset();
            metricsCalculator.CalculateInitialTargetTrackingMetrics();
            parkingLotInitializer.ReInitialize();
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