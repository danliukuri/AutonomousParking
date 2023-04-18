using System.Collections.Generic;
using AutomaticParking.Common.Enumerations;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentRewardData
    {
        public const float MaxRewardForInactivityPerStep = -1f;
        public const float MaxRewardForDecreasingDistanceToTargetPerStep = 0.5f;
        public const float MaxRewardForDecreasingAngleToTargetPerStep = 0.5f;

        public const float MinRewardForParkingPerStep = 1f;
        public const float MaxRewardForParkingPerStep = 1.5f;
        public const float MinRewardForPerfectParking = 700f;
        public const float MaxRewardForPerfectParking = 900f;

        public const float RewardForWallCollisionEnter = -400f;
        public const float RewardForCarCollisionEnter = -500f;

        public static Dictionary<Tag, float> CollisionRewards { get; } = new()
        {
            [Tag.Wall] = RewardForWallCollisionEnter,
            [Tag.Car] = RewardForCarCollisionEnter
        };
    }
}