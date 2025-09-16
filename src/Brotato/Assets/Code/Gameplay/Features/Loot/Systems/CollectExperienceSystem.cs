using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CollectExperienceSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _collected;
        private IGroup<GameEntity> _heroes;

        public CollectExperienceSystem(GameContext gameContext)
        {
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
             hero.ReplaceExperience(hero.Experience + collected.Experience);   
            }
        }
    }
}