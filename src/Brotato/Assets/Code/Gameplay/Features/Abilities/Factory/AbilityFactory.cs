using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public AbilityFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
            _staticDataService.LoadAll();
        }

        public GameEntity CreatePenetratorBoltAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityID.PenetratorBolt, level);

            return CreateEntity
                .Empty()
                .AddAbilityID(AbilityID.PenetratorBolt) 
                .AddId(_identifiers.Next())
                .AddCooldown(abilityLevel.Cooldown)
                .AddCooldownLeft(abilityLevel.Cooldown)
                .With(x => x.isPenetrationBoltAbility = true)
                .PutOnCooldown();
        }
        
        public GameEntity CreateOrbitalAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityID.Orbital, level);

            return CreateEntity
                .Empty()
                .AddId(_identifiers.Next())
                .AddAbilityID(AbilityID.Orbital) 
                .AddCooldown(abilityLevel.Cooldown)
                .AddCooldownLeft(abilityLevel.Cooldown)
                .With(x => x.isOrbitalAbility = true)
                .PutOnCooldown();
        }
    }
}