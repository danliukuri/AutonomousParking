using UnityEngine;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentData
    {
        private readonly ParkingAgent agent;
        public ParkingAgentData(ParkingAgent agent) => this.agent = agent;

        public int StepCount => agent.StepCount;
        public bool HasReachedMaxStep => agent.StepCount == agent.MaxStep;

        public Rigidbody Rigidbody { get; set; }
        public Transform Transform { get; set; }

        public void Reset() => Rigidbody.velocity = Rigidbody.angularVelocity = default;
    }
}