using System;
using System.Collections.Generic;
using AutomaticParking.Common.Enumerations;
using UnityEngine;

namespace AutomaticParking.Agents.Data
{
    [Serializable]
    public class ParkingAgentRewardData
    {
        [field: Header("Target Reaching Rewards")]
        [field: SerializeField] public float MaxRewardForInactivityPerStep { get; private set; }
        [field: SerializeField] public float MaxRewardForDecreasingDistanceToTargetPerStep { get; private set; }
        [field: SerializeField] public float MaxRewardForDecreasingAngleToTargetPerStep { get; private set; }

        [field: Header("Parking Rewards")]
        [field: SerializeField] public float MinRewardForParkingPerStep { get; private set; }
        [field: SerializeField] public float MaxRewardForParkingPerStep { get; private set; }
        [field: SerializeField] public float MinRewardForPerfectParking { get; private set; }
        [field: SerializeField] public float MaxRewardForPerfectParking { get; private set; }

        [field: Header("Collision Rewards")]
        [field: SerializeField] public float RewardForWallCollisionEnter { get; private set; }
        [field: SerializeField] public float RewardForCarCollisionEnter { get; private set; }

        public Dictionary<Tag, float> CollisionRewards { get; private set; } = new();

        public void Initialize()
        {
            CollisionRewards[Tag.Wall] = RewardForWallCollisionEnter;
            CollisionRewards[Tag.Car] = RewardForCarCollisionEnter;
        }
    }
}