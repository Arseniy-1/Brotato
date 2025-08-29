using Code.Gameplay.Input.Service;
using Code.Gameplay.Input.Systems;
using UnityEngine;

namespace Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(GameContext gameContext, IInputService inputService)
        {
            Add(new InitializeInputSystem());
            Add(new EmitInputSystem(gameContext, inputService));
        }
    }
}