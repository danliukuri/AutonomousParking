using AutomaticParking.Common.Enumerations;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentCollisionData
    {
        public Tag CollisionTag { get; set; }
        public bool IsAnyCollision => CollisionTag != default;
        
        public void Reset() => CollisionTag = default;
    }
}