using Code.Gameplay.Features.Abilities.Upgrade;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public class UpgradeAbilityOnRequestSystem : IExecuteSystem
    {
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IGroup<GameEntity> _upgradeRequests;
        private readonly IGroup<GameEntity> _levelUps;

        public UpgradeAbilityOnRequestSystem(GameContext gameContext, IAbilityUpgradeService abilityUpgradeService)
        {
            _abilityUpgradeService = abilityUpgradeService;

            _levelUps = gameContext.GetGroup(GameMatcher.LevelUp);

            _upgradeRequests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AbilityID,
                    GameMatcher.UpgradeRequest));
        }

        public void Execute()
        {
            foreach (GameEntity upgradeRequest in _upgradeRequests)
            foreach (GameEntity levelUp in _levelUps)
            {
                _abilityUpgradeService.UpgradeAbility(upgradeRequest.AbilityID);

                levelUp.isProcessed = true;
                upgradeRequest.isDestructed = true;
            }
        }
    }
}