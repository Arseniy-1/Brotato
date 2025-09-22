using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class TurnAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public TurnAlongDirectionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TurnedAlongDirection,
                    GameMatcher.Transform,
                    GameMatcher.Direction));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {   
                float scale = Mathf.Abs(mover.Transform.localScale.x);
                mover.Transform.SetScaleX(scale * FaceDirection(mover));
            }
        }

        private float FaceDirection(GameEntity mover)
        {
            return mover.Direction.x <= 0 
                ? -1 
                : 1; 
        }
    }
}