using AutomaticParking.Agents.Data;
using AutomaticParking.Common.Extensions;
using UnityEngine;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentMetricsCalculator
    {
        private readonly ParkingAgentData agentData;
        private readonly ParkingAgentTargetTrackingData data;
        private readonly ParkingAgentTargetData targetData;

        public ParkingAgentMetricsCalculator(ParkingAgentData agentData, ParkingAgentTargetData targetData,
            ParkingAgentTargetTrackingData data)
        {
            this.agentData = agentData;
            this.targetData = targetData;
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
            Vector3.Distance(agentData.Transform.position, targetData.Transform.position);

        private float CalculateDistancesDifference() =>
            Mathf.Abs(data.PreviousDistanceToTarget - data.CurrentDistanceToTarget);

        private float CalculateDistancesDifferenceNormalized() =>
            CalculateDistancesDifference().Normalize(data.MinDistanceToTarget, data.MaxDistanceToTarget);

        private float CalculateCurrentAngleToTarget() =>
            Quaternion.Angle(agentData.Transform.rotation, targetData.Transform.rotation);

        private float CalculateAngleDifference() => Mathf.Abs(data.PreviousAngleToTarget - data.CurrentAngleToTarget);

        private float CalculateAngleDifferenceNormalized() =>
            CalculateAngleDifference().Normalize(data.MinAngleToTarget, data.MaxAngleToTarget);

        private bool CalculateWhetherTargetHasBeenReached() =>
            Mathf.Abs(data.CurrentDistanceToTarget) < targetData.ReachRadius &&
            Mathf.Abs(data.CurrentAngleToTarget) < targetData.ReachAngle;
    }
}