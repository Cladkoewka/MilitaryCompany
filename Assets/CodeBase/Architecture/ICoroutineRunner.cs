using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Architecture
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);

    }
}