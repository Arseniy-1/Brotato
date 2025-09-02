using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
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
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddEnemyTypeId(EnemyTypeId.BabyAlient)
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddSpeed(1)
                .AddCurentHP(3)
                .AddMaxHP(3)
                .AddDamage(1)
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