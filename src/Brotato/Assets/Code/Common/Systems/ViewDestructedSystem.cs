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
            Debug.Log("1");
            foreach (GameEntity entity in _entities)
            {
                Debug.Log("2");
                entity.View.ReleaseEntity();
                Object.Destroy(entity.View.gameObject);
            }
        }
    }
}