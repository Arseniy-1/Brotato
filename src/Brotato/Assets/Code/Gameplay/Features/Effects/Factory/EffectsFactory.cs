using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effects.Factory
{
    public class EffectsFactory : IEffectsFactory
    {
        private readonly IIdentifierService _identifierService;

        public EffectsFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        private void CreateDamage(int producerId, int targetId, float value)
        {
            CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isEffect = true)
                .With(x => x.isDamageEffect = true)
                .AddEffectValue(value)
                .AddProducerId(producerId)
                .AddTargetId(targetId);
        }

        public GameEntity CreateEffect(EffectSetup effectSetup, int producerId, int targetId)
        {
            switch (effectSetup.EffectTypeId)
            {
                case EffectTypeId.Unknown:
                    break;
                case EffectTypeId.Damage:
                    CreateDamage(producerId, targetId, effectSetup.Value);
                    break;
            }

            throw new Exception($"Effect with type id {effectSetup.EffectTypeId} is not supported");
        }
    }
}