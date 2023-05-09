using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Asteroids.Core.Services
{
    public sealed class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Destroy() { }

        public void Load(string name, Action success)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, success));
        }

        private IEnumerator LoadScene(string name, Action success = null)
        {
            if (SceneManager.GetActiveScene().name != name)
            {
                var operation = SceneManager.LoadSceneAsync(name);

                while (!operation.isDone)
                    yield return null;
            }

            success.SafeInvoke();
        }
    }
}
