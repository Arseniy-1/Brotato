using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class SetEnemyDirectionByHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public SetEnemyDirectionByHeroSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher.Enemy);
            _heroes = gameContext.GetGroup(GameMatcher.Hero);
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                enemy.isMoving = true;

                enemy.ReplaceDirection((_heroes.GetEntities()[0].WorldPosition - enemy.WorldPosition).normalized);
            }
        }
    }
}