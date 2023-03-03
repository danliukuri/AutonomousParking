using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

namespace AutomaticParking.Agents
{
    public class ParkingAgent : Agent
    {
        private ParkingAgentData data;

        public override void Initialize() => data = GetComponentInParent<ParkingAgentData>();

        public override void OnEpisodeBegin() => data.Reset();

        public override void CollectObservations(VectorSensor sensor)
        {
            data.ObservationsCollector.CollectAgentTransformObservations(sensor);
            data.ObservationsCollector.CollectAgentVelocityObservations(sensor);

            data.ObservationsCollector.CollectTargetTransformObservations(sensor);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            data.ActionsHandler.HandleInputActions(actions);
            AddReward(data.RewardCalculator.CalculateReward());
        }

        public override void Heuristic(in ActionBuffers actionsOut)
        {
            data.ActionsHandler.HandleHeuristicInputContinuousActions(actionsOut.ContinuousActions);
            data.ActionsHandler.HandleHeuristicInputDiscreteActions(actionsOut.DiscreteActions);
        }
    }
}