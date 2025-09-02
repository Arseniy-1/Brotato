using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class DirectionalDeltaMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly ITimeService _time;

        public DirectionalDeltaMoveSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.WorldPosition,
                    GameMatcher.Speed,
                    GameMatcher.MovementAvailable,
                    GameMatcher.Moving));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.ReplaceWorldPosition((Vector2)mover.WorldPosition + mover.Direction * mover.Speed * _time.DeltaTime);
            }
        }
    }
}