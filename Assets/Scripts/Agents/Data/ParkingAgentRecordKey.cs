namespace AutomaticParking.Agents.Data
{
    public static class ParkingAgentRecordKey
    {
        public const string DistanceToTarget = Header.Agent + nameof(DistanceToTarget);
        public const string AngleToTarget = Header.Agent + nameof(AngleToTarget);

        public const string Parked = Header.Agent + nameof(Parked);
        public const string PerfectlyParked = Header.Agent + nameof(PerfectlyParked);

        public static class Header
        {
            private const string Separator = "/";
            public const string Agent = nameof(Agent) + Separator;
            public const string Collision = Agent + nameof(Collision) + Separator;
        }
    }
}