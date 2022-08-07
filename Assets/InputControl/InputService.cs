using System;
using UnityEngine;
using Zenject;

namespace TD.Assets.InputControl
{
    public class InputService : IInputService, ITickable
    {
        public event Action<Vector2> Click;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Click?.Invoke(Input.mousePosition);
            }
        }
    }
}