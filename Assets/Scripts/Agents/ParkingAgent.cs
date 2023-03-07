﻿using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgent : Agent
    {
        private ParkingAgentData data;

        public override void Initialize() => data = GetComponentInParent<ParkingAgentInitializer>().Initialize();

        public override void OnEpisodeBegin()
        {
            data.Reset();
            data.CarData.Reset();

            data.PreviousDistanceToTarget = Vector3.Distance(data.InitialPosition, data.Target.position);
            data.PreviousAngleToTarget = Quaternion.Angle(data.InitialRotation, data.Target.rotation);
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
            AddReward(data.RewardCalculator.CalculateReward());
        }

        public override void Heuristic(in ActionBuffers actionsOut)
        {
            data.ActionsHandler.HandleHeuristicInputContinuousActions(actionsOut.ContinuousActions);
            data.ActionsHandler.HandleHeuristicInputDiscreteActions(actionsOut.DiscreteActions);
        }
    }
}