using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class SetEnemyDirectionByHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;

        public SetEnemyDirectionByHeroSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher.Enemy);
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                enemy.isMoving = true;

                enemy.ReplaceDirection(Vector3.zero.normalized);
            }
        }
    }
}