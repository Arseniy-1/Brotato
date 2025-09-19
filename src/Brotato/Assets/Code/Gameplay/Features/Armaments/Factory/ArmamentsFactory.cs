using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentsFactory : IArmamentsFactory
    {
        private const int TargetBufferSize = 16;

        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public ArmamentsFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreatePenetratorBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.PenetratorBolt, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                .AddParentAbility(AbilityId.PenetratorBolt)
                .With(x => x.isRotationAlignedAlongDirection = true);
        }

        public GameEntity CreateOrbital(int level, Vector3 at, float phase)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.Orbital, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(at, abilityLevel, setup)
                .AddParentAbility(AbilityId.Orbital)
                .AddOrbitPhase(phase)
                .AddOrbitRadius(setup.OrbitRadius);
        }

        public GameEntity CreateEffectAura(AbilityId parentAbilityID, int producerId, int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.RotAura, level);
            AuraSetup setup = abilityLevel.AuraSetup;

            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddParentAbility(parentAbilityID)
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .With(x => x.AddEffectSetups(abilityLevel.EffectSetups),
                    when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(abilityLevel.StatusSetups),
                    when: !abilityLevel.StatusSetups.IsNullOrEmpty())
                .AddRadius(setup.Radius)
                .AddCollectTargetsInterval(setup.Interval)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .AddTargetsBuffer(new List<int>(TargetBufferSize))
                .With(x => x.isFollowingProducer = true)
                .AddWorldPosition(Vector3.zero)
                .AddProducerId(producerId); 
        }

        private GameEntity CreateProjectileEntity(Vector3 at, AbilityLevel abilityLevel, ProjectileSetup setup)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(at)
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .AddSpeed(setup.Speed)
                .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when: !abilityLevel.StatusSetups.IsNullOrEmpty())
                .With(x => x.AddTargetLimit(setup.Pierce), when: setup.Pierce > 0)
                .AddDamage(1)
                .AddRadius(setup.ContactRadius)
                .AddTargetsBuffer(new List<int>(TargetBufferSize))
                .AddProcessedTargets(new List<int>(TargetBufferSize))
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContinuously = true)
                .With(x => x.isArmament = true)
                .AddSelfDestructTimer(setup.Lifetime);
        }

        public GameEntity CreateExplosion(int producerId, Vector3 at)
        {
            EnchantConfig config = _staticDataService.GetEnchantConfig(EnchantTypeId.ExplosiveArmaments);

            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .AddRadius(config.Radius)
                .AddTargetsBuffer(new List<int>(TargetBufferSize))
                .With(x => x.AddEffectSetups(config.EffectSetups),
                    when: !config.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(config.StatusSetups),
                    when: !config.StatusSetups.IsNullOrEmpty())
                .AddViewPrefab(config.ViewPrefab)
                .AddWorldPosition(at)
                .AddProducerId(producerId)
                .With(x => x.isReadyToCollectTargets = true)
                .AddSelfDestructTimer(1);
        }
    }
}