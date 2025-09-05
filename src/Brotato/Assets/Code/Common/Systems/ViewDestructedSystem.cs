using Entitas;
using UnityEngine;

namespace Code.Common.Systems
{
    public class ViewDestructedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public ViewDestructedSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Destructed,
                    GameMatcher.View));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.View.ReleaseEntity();
                Object.Destroy(entity.View.gameObject);
            }
        }
    }
}