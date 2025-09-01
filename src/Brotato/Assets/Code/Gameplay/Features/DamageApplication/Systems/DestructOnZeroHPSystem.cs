using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class DestructOnZeroHpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DestructOnZeroHpSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher.CurentHP);
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if(entity.CurentHP <= 0)
                    entity.isDestructed = true;
            }
        }
    }
}