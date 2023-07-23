using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutomaticParking.Demonstration.Infrastructure
{
    public class SceneLoader
    {
        public string CurrentSceneName { get; private set; }

        public AsyncOperation Load(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single,
            Action onLoaded = default)
        {
            AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
            loadingOperation.completed += OnLoadingCompleted;
            return loadingOperation;

            void OnLoadingCompleted(AsyncOperation operation)
            {
                CurrentSceneName = sceneName;
                onLoaded?.Invoke();
                operation.completed -= OnLoadingCompleted;
            }
        }

        public AsyncOperation UnLoad(string sceneName, Action onUnloaded = default)
        {
            AsyncOperation unloadingOperation = SceneManager.UnloadSceneAsync(sceneName);
            unloadingOperation.completed += OnUnloadingCompleted;
            return unloadingOperation;

            void OnUnloadingCompleted(AsyncOperation operation)
            {
                CurrentSceneName = string.Empty;
                onUnloaded?.Invoke();
                operation.completed -= OnUnloadingCompleted;
            }
        }
    }
}