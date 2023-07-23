﻿using AutonomousParking.Demonstration.Architecture;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutonomousParking.Demonstration.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private string entrySceneName;

        private void Awake()
        {
            ServiceLocator.Instance.Register(new CarControlTypeChanger());
            SceneLoader sceneLoader = ServiceLocator.Instance.Register(new SceneLoader());
            sceneLoader.Load(entrySceneName, LoadSceneMode.Additive);
        }
    }
}