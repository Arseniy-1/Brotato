using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IInputService _inputService;

        private  IGroup<GameEntity> _inputs;

        public EmitInputSystem(GameContext gameContext, IInputService inputService)
        {
            _gameContext = gameContext;
            _inputService = inputService;

            _inputs = _gameContext.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                if (_inputService.HasAxisInput())
                {
                    input.ReplaceAxisInput(
                        new Vector2(
                            _inputService.GetHorizontalAxis(),
                            _inputService.GetVerticalAxis()));
                }
                else if (input.hasAxisInput)
                {
                    input.RemoveAxisInput();
                }
            }
        }
    }
}