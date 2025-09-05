using Code.Gameplay.Features.TargetCollection;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Systems
{
    public class EnemyDeathSystem : IExecuteSystem
    {
        private const float DeathAnimationTime = 0.9f;

        private readonly IGroup<GameEntity> _enemies;

        public EnemyDeathSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                enemy.isMovementAvailable = false;
                enemy.isTurnedAlongDirection = false;

                enemy.RemoveTargetCollectionComponents();

                if (enemy.hasEnemyAnimator)
                    enemy.EnemyAnimator.PlayDied();

                enemy.ReplaceSelfDestructTimer(DeathAnimationTime);
            }
        }
    }
}