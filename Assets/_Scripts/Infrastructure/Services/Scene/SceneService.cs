using ProjectKYS.Infrasturcture.Services.Save;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectKYS.Infrasturcture.Services.Scene
{
    public class SceneService : ISceneService
    {
        private readonly MonoBehaviour _coroutineRunner;

        private Dictionary<string, AsyncOperation> _sceneLoadProgresses;

        public SceneService(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _sceneLoadProgresses = new Dictionary<string, AsyncOperation>();
        }

        public void Load(string sceneName, Action onLoaded)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, true, onLoaded));
        }

        public void LoadAndActivateAfterAction(ISceneLoadActivator activator, string sceneName, Action onLoaded)
        {
            Action activateAction = () => ActivateScene(sceneName, onLoaded);
            activator.OnActivateScene += activateAction;

            _coroutineRunner.StartCoroutine(LoadScene(sceneName, false, null));

            if(onLoaded != null)
                onLoaded += () => activator.OnActivateScene -= activateAction;
        }

        public void Unload(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        private void ActivateScene(string sceneName, Action onActivate)
        {
            _sceneLoadProgresses[sceneName].allowSceneActivation = true;
            onActivate?.Invoke();

            _sceneLoadProgresses.Remove(sceneName);
        }
        private IEnumerator LoadScene(string sceneName, bool activateScene, Action onLoaded)
        {
            AsyncOperation waitLoadScene = SceneManager.LoadSceneAsync(sceneName);
            waitLoadScene.allowSceneActivation = activateScene;
            _sceneLoadProgresses.Add(sceneName, waitLoadScene);

            do
            {
                yield return null;
            }
            while (!waitLoadScene.isDone);

            onLoaded?.Invoke();

            if(activateScene)
            {
                _sceneLoadProgresses.Remove(sceneName);
            }
        }

        public static string GetActiveSceneName()
            => SceneManager.GetActiveScene().name;
    }
}