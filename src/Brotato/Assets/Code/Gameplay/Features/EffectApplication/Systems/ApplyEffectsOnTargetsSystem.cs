using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
    public class ApplyEffectsOnTargetsSystem : IExecuteSystem
    {
        private readonly IEffectsFactory _effectsFactory;
        private readonly IGroup<GameEntity> _entities;

        public ApplyEffectsOnTargetsSystem(GameContext gameContext, IEffectsFactory effectsFactory)
        {
            _effectsFactory = effectsFactory;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectSetups,
                    GameMatcher.TargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetID in entity.TargetsBuffer)
            foreach (EffectSetup setup in entity.EffectSetups)
            {
                _effectsFactory.CreateEffect(setup, ProducerID(entity), targetID);
            }
        }

        private int ProducerID(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}