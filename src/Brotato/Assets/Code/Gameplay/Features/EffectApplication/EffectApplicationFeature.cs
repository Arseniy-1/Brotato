using Code.Gameplay.Features.EffectApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.DamageApplication
{
    public class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyDamageOnTargetsSystem>());
        }
    }
}