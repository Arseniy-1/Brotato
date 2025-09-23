using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CleanupCollected : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _pullables;

        public CleanupCollected(GameContext gameContext)
        {
            _pullables = gameContext.GetGroup(GameMatcher.Collected);
        }
        
        public void Cleanup()
        {
            foreach (GameEntity pullable in _pullables)
            {
                pullable.isDestructed = true;
            }
        }
    }
}