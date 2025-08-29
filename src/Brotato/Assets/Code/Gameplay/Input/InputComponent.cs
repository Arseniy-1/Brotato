using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
    public class InputComponent
    {
        [Game] public class Input : IComponent { }
        [Game] public class AxisInput : IComponent { public Vector2 Value; }
    }
}