using System;
using System.Collections.Generic;
using AutomaticParking.Common;
using UnityEngine;
using RewardData = AutomaticParking.Agents.Data.ParkingAgentRewardData;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentCollisionsHandler : MonoBehaviour
    {
        private ParkingAgent agent;
        private Dictionary<string, Action> collisionEnterHandlers;

        private void Awake()
        {
            agent = GetComponentInChildren<ParkingAgent>();
            collisionEnterHandlers = new Dictionary<string, Action> { [Tags.Wall] = HandleWallCollisionEnter };
        }

        private void OnCollisionEnter(Collision collision) =>
            collisionEnterHandlers.GetValueOrDefault(collision.gameObject.tag)?.Invoke();

        private void HandleWallCollisionEnter()
        {
            agent.AddReward(RewardData.RewardForWallCollisionEnter);
            agent.EndEpisode();
        }
    }
}