using System.Collections;
using UnityEngine;

namespace Asteroids.Core.Services
{
    public interface ICoroutineRunner : IService
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
