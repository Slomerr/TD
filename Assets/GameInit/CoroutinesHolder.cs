using System;
using System.Collections;
using UnityEngine;

namespace TD.Assets.GameInit
{
    public class CoroutinesHolder : MonoBehaviour
    {
        public Coroutine StartCoroutine(Func<IEnumerator> coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}
