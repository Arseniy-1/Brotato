using Code.Gameplay.Features.Abilities.PenetratorBoltAbilitySystems;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Abilities
{
    public class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CooldownSystem>());
            Add(systemFactory.Create<PenetratorBoltAbilitySystem>());
        }
    }
}