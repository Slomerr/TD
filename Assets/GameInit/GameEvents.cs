using System;
using UnityEngine;
using Zenject;

namespace TD.Assets.GameInit
{
    public class GameEvents : MonoBehaviour, IInitializable, IGameEvents
    {
        public event Action ApplicationQuit;

        public void Initialize()
        {
            DontDestroyOnLoad(this);
        }

        public void OnApplicationQuit()
        {
            ApplicationQuit?.Invoke();
        }
    }
}
