using System;
using UnityEngine;

namespace TD.Assets.InputControl
{
    public interface IInputService
    {
        event Action<Vector2> Click;
    }
}