using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CollectEffectItemSystem : IExecuteSystem
    {
        private readonly IEffectsFactory _effectsFactory;
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;

        public CollectEffectItemSystem(GameContext gameContext, IEffectsFactory effectsFactory)
        {
            _effectsFactory = effectsFactory;
            _collected = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Collected,
                    GameMatcher.EffectSetups));

            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity collected in _collected)
            foreach (GameEntity hero in _heroes)
            foreach (EffectSetup effectSetup in collected.EffectSetups)
            {
                _effectsFactory.CreateEffect(effectSetup, hero.Id, hero.Id);
            }
        }
    }
}