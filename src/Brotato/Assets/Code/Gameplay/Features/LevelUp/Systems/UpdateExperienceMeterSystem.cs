using Code.Gameplay.Features.LevelUp.Services;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public class UpdateExperienceMeterSystem : IExecuteSystem
    {
        private readonly ILevelUpService _levelUpService;
        
        private readonly IGroup<GameEntity> _experienceMeter;
        private readonly IGroup<GameEntity> _heroes;

        public UpdateExperienceMeterSystem(GameContext gameContext, ILevelUpService levelUpService)
        {
            _levelUpService = levelUpService;
        
            _experienceMeter = gameContext.GetGroup(GameMatcher.ExperienceMeter);

            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Experience));
        }

        public void Execute()
        {
            foreach (GameEntity experienceMeter in _experienceMeter)
            foreach (GameEntity hero in _heroes)
            {
                experienceMeter.ExperienceMeter.SetExperience(hero.Experience, _levelUpService.ExperienceForLevelUp());
            }
        }
    }
}