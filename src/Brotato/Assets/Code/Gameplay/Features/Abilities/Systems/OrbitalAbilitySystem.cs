using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class OrbitalAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentsFactory _armamentsFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;
        
        private readonly List<GameEntity> _buffer = new(4);

        public OrbitalAbilitySystem(
            GameContext gameContext,
            IStaticDataService staticDataService,
            IArmamentsFactory armamentsFactory, 
            IAbilityUpgradeService abilityUpgradeService)
        {
            _staticDataService = staticDataService;
            _armamentsFactory = armamentsFactory;
            _abilityUpgradeService = abilityUpgradeService;

            _abilities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.OrbitalAbility,
                    GameMatcher.CooldownUp));

            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            foreach (GameEntity hero in _heroes)
            {
                int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.Orbital);
                AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.Orbital, 1);

                int projectileCount = abilityLevel.ProjectileSetup.ProjectileCount;

                for (int i = 0; i < projectileCount; i++)
                {
                    float phase = (2 * Mathf.PI * i / projectileCount);
                    CreateProjectile(level, hero, phase);
                }

                ability.PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.Orbital, 1).Cooldown);
            }
        }

        private void CreateProjectile(int level, GameEntity hero, float phase)
        {
            _armamentsFactory.CreateOrbital(level, hero.WorldPosition + Vector3.up, phase)
                .AddProducerId(hero.Id)
                .AddOrbitCenterPosition(hero.WorldPosition)
                .AddOrbitCenterFollowTargetId(hero.Id)
                .isMoving = true;
        }
    }
}