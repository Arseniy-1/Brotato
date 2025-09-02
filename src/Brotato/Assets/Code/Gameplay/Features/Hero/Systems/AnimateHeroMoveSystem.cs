using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class AnimateHeroMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _inputs;

        public AnimateHeroMoveSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.HeroAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                if (hero.isMoving)
                    hero.HeroAnimator.PlayMove();
                else
                    hero.HeroAnimator.PlayIdle();
            }
        }
    }
}