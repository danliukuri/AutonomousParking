using System.Linq;
using AutonomousParking.Car.Creation;
using AutonomousParking.Demonstration.Architecture;
using AutonomousParking.Demonstration.Infrastructure;
using Unity.MLAgents;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutonomousParking.Demonstration.UI
{
    public class MainMenuButtonsEventHandler : MonoBehaviour
    {
        public void OnExitButtonClick()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
            Application.Quit();
            Application.OpenURL("https://yuriy-danyliuk.itch.io/");
#else
            Application.Quit();
#endif
        }

        public void OnSceneLoad(string sceneName)
        {
            Academy.Instance.Dispose();
            foreach (CarSpawner carSpawner in ServiceLocator.Instance.Get<CarSpawner>())
                carSpawner.DeSpawnAll();

            SceneLoader sceneLoader = ServiceLocator.Instance.Get<SceneLoader>().First();
            CarControlTypeChanger carControlTypeChanger = ServiceLocator.Instance.Get<CarControlTypeChanger>().First();
            sceneLoader.UnLoad(sceneLoader.CurrentSceneName, () =>
                sceneLoader.Load(sceneName, LoadSceneMode.Additive, carControlTypeChanger.SetCarControlBehaviorType));
        }
    }
}