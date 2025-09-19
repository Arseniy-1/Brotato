using Code.Gameplay.Features.LevelUp.Services;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CollectExperienceSystem : IExecuteSystem
    {
        private readonly ILevelUpService _levelUpService;

        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;

        public CollectExperienceSystem(GameContext gameContext, ILevelUpService levelUpService)
        {
            _levelUpService = levelUpService;
            _collected = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Collected,
                    GameMatcher.Experience));

            _heroes = gameContext.GetGroup(GameMatcher.Hero);
        }

        public void Execute()
        {
            foreach (GameEntity collected in _collected)
            foreach (GameEntity hero in _heroes)
            {
                _levelUpService.AddExperience(hero.Experience + collected.Experience);
                hero.ReplaceExperience(_levelUpService.CurrentExperience);
            }
        }
    }
}