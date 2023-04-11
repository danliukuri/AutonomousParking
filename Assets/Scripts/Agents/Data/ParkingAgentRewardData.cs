using System.Collections.Generic;
using AutomaticParking.Common;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentRewardData
    {
        public const float MaxRewardForInactivityPerStep = -1f;
        public const float MaxRewardForDecreasingDistanceToTargetPerStep = 0.5f;
        public const float MaxRewardForDecreasingAngleToTargetPerStep = 0.5f;

        public const float MinRewardForTargetReach = 400f;
        public const float MaxRewardForTargetReach = 500f;

        public const float RewardForWallCollisionEnter = -400f;
        public const float RewardForCarCollisionEnter = -500f;

        public static Dictionary<string, float> CollisionRewards { get; } = new()
        {
            [Tags.Wall] = RewardForWallCollisionEnter,
            [Tags.Car] = RewardForCarCollisionEnter
        };
    }
}