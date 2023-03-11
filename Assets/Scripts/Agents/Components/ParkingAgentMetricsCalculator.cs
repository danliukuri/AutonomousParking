using AutomaticParking.Agents.Data;
using AutomaticParking.Common.Extensions;
using UnityEngine;
using static AutomaticParking.Agents.Data.ParkingAgentTargetTrackingData;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentMetricsCalculator
    {
        private readonly ParkingAgentData agentData;
        private readonly ParkingAgentTargetTrackingData data;

        public ParkingAgentMetricsCalculator(ParkingAgentData agentData, ParkingAgentTargetTrackingData data)
        {
            this.agentData = agentData;
            this.data = data;
        }

        public void CalculateTargetTrackingMetrics()
        {
            data.PreviousDistanceToTarget = data.CurrentDistanceToTarget;
            data.CurrentDistanceToTarget = CalculateCurrentDistanceToTarget();
            data.PreviousAngleToTarget = data.CurrentAngleToTarget;
            data.CurrentAngleToTarget = CalculateCurrentAngleToTarget();

            data.DistancesDifference = CalculateDistancesDifference();
            data.DistancesDifferenceNormalized = CalculateDistancesDifferenceNormalized();
            data.AngleDifference = CalculateAngleDifference();
            data.AngleDifferenceNormalized = CalculateAngleDifferenceNormalized();

            data.IsTargetReached = CalculateWhetherTargetHasBeenReached();
        }

        private float CalculateCurrentDistanceToTarget() =>
            Vector3.Distance(agentData.Transform.position, data.Transform.position);

        private float CalculateDistancesDifference() =>
            Mathf.Abs(data.PreviousDistanceToTarget - data.CurrentDistanceToTarget);

        private float CalculateDistancesDifferenceNormalized() =>
            CalculateDistancesDifference().Normalize(data.MinDistanceToTarget, data.MaxDistanceToTarget);

        private float CalculateCurrentAngleToTarget() =>
            Quaternion.Angle(agentData.Transform.rotation, data.Transform.rotation);

        private float CalculateAngleDifference() => Mathf.Abs(data.PreviousAngleToTarget - data.CurrentAngleToTarget);

        private float CalculateAngleDifferenceNormalized() =>
            CalculateAngleDifference().Normalize(data.MinAngleToTarget, data.MaxAngleToTarget);

        private bool CalculateWhetherTargetHasBeenReached() =>
            Mathf.Abs(data.CurrentDistanceToTarget) < TargetReachRadius &&
            Mathf.Abs(data.CurrentAngleToTarget) < TargetReachAngle;
    }
}