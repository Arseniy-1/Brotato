using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
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
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityID.PenetratorBolt, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            return CreateEntity
                .Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(at)
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .AddSpeed(setup.Speed)
                .AddEffectSetups(abilityLevel.EffectSetups)
                .AddStatusSetups(abilityLevel.StatusSetups)
                .AddDamage(1)
                .AddRadius(setup.ContactRadius)
                .AddTargetsBuffer(new List<int>(TargetBufferSize))
                .AddProcessedTargets(new List<int>(TargetBufferSize))
                .AddTargetLimit(setup.Pierce)
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isArmament = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContinuously = true)
                .AddSelfDestructTimer(setup.Lifetime);

        }
    }
}