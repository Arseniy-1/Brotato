using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
    public class FinalizeEnemyDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(128);

        public FinalizeEnemyDeathProcessingSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Enemy,
                    GameMatcher.ProcessingDeath,
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
            {
                enemy.isProcessingDeath = false;
            }
        }
    }
}