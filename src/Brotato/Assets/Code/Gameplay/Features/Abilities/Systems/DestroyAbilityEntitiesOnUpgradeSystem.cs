using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DestroyAbilityEntitiesOnUpgradeSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        
        private readonly IGroup<GameEntity> _upgradeRequests;
        private readonly IGroup<GameEntity> _abilities;

        public DestroyAbilityEntitiesOnUpgradeSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _abilities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AbilityID,
                    GameMatcher.RecreatedOnUpgrade));
            
            _upgradeRequests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.UpgradeRequest,
                    GameMatcher.AbilityID));
        }

        public void Execute()
        {
            foreach (GameEntity request in _upgradeRequests)
            foreach (GameEntity ability in _abilities)
            {
                if (request.AbilityID == ability.AbilityID)
                {
                    foreach (GameEntity entity in _gameContext.GetEntitiesWithParentAbility(ability.AbilityID)) 
                        entity.isDestructed = true;
                    
                    ability.isActive = false;
                }   
            }
        }
    }
}