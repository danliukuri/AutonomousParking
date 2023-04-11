namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentCollisionData
    {
        public string CollisionTag { get; set; }
        public bool IsAnyCollision => CollisionTag != default;
        
        public void Reset() => CollisionTag = default;
    }
}