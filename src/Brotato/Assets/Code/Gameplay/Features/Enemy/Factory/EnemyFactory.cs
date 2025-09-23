using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifiers;

        public EnemyFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }
        
        public GameEntity CreateEnemy(EnemyTypeId enemyTypeId, Vector3 at)
        {
            Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.Speed] = 1)
                .With(x => x[Stats.MaxHp] = 5)
                .With(x => x[Stats.Damage] = 1);
            
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddEnemyTypeId(EnemyTypeId.BabyAlient)
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddBaseStats(baseStats)
                .AddStatModifiers(InitStats.EmptyStatDictionary())
                .AddSpeed(baseStats[Stats.Speed])
                .AddCurentHP(baseStats[Stats.MaxHp])
                .AddMaxHP(baseStats[Stats.MaxHp])
                .AddEffectSetups(new List<EffectSetup>(){new EffectSetup(){EffectTypeId = EffectTypeId.Damage, Value = baseStats[Stats.Damage]}})
                .AddRadius(0.3f)
                .AddTargetsBuffer(new List<int>(1))
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddViewPath("Prefabs/BabyAlient")
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .With(x => x.isEnemy = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isTurnedAlongDirection = true);
        }
    }
}