using System.Linq;
using AutonomousParking.Agents.Data;
using AutonomousParking.Common.Enumerations;
using UnityEngine;

namespace AutonomousParking.Agents.Components
{
    public class ParkingAgentCollisionsHandler : MonoBehaviour
    {
        private ParkingAgentCollisionData collisionData;

        private void OnCollisionEnter(Collision collision)
        {
            string gameObjectTag = collision.gameObject.tag;
            if (Tag.List.Contains(gameObjectTag))
                collisionData.CollisionTag = gameObjectTag;
        }

        public ParkingAgentCollisionsHandler Initialize(ParkingAgentCollisionData collisionData)
        {
            this.collisionData = collisionData;
            return this;
        }
    }
}