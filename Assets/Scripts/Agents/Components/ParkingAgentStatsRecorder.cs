using System;
using AutonomousParking.Agents.Data;
using AutonomousParking.Common.Enumerations;
using Unity.MLAgents;
using static AutonomousParking.Agents.Data.ParkingAgentRecordKey;

namespace AutonomousParking.Agents.Components
{
    public class ParkingAgentStatsRecorder
    {
        private readonly ParkingAgentCollisionData agentCollisionData;
        private readonly ParkingAgentTargetTrackingData targetTrackingData;

        public ParkingAgentStatsRecorder(ParkingAgentCollisionData agentCollisionData,
            ParkingAgentTargetTrackingData targetTrackingData)
        {
            this.agentCollisionData = agentCollisionData;
            this.targetTrackingData = targetTrackingData;
        }

        public void RecordStats()
        {
            Record(DistanceToTarget, targetTrackingData.DistanceToTarget);
            Record(AngleToTarget, targetTrackingData.AngleToTarget);

            Record(Parked, targetTrackingData.IsParked);
            if (targetTrackingData.IsParked)
                Record(PerfectlyParked, targetTrackingData.IsPerfectlyParked);

            foreach (Tag tag in Tag.List)
                Record(Header.Collision + tag, agentCollisionData.CollisionTag == tag);
        }

        private void Record(string key, float value, StatAggregationMethod aggregationMethod = default) =>
            Academy.Instance.StatsRecorder.Add(key, value, aggregationMethod);

        private void Record(string key, bool value = true, StatAggregationMethod aggregationMethod = default) =>
            Record(key, Convert.ToSingle(value), aggregationMethod);
    }
}