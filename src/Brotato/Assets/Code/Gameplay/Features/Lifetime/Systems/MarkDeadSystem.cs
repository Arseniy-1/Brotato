using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class MarkDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new (128);

        public MarkDeadSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CurentHP,
                    GameMatcher.MaxHP)
                .NoneOf(GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (entity.CurentHP <= 0)
                {
                    entity.isDead = true;   
                    entity.isProcessingDeath = true;   
                }
            }
        }
    }
}