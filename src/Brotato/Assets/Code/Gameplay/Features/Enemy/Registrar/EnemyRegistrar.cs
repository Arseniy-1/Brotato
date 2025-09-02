using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemy.Registrar
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        public float Speed = 2;
        public float MaxHP = 10;
        public float Damage = 3;

        public override void RegisterComponents()
        {
            Entity
                .AddEnemyTypeId(EnemyTypeId.BabyAlient)
                .AddWorldPosition(transform.position)
                .AddDirection(transform.forward)
                .AddSpeed(Speed)
                .AddCurentHP(MaxHP)
                .AddMaxHP(MaxHP)
                .AddDamage(Damage)
                .AddTargetsBuffer(new List<int>(1))
                .AddRadius(0.3f)
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .With(x => x.isEnemy = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isTurnedAlongDirection = true);
        }

        public override void UnregisterComponents()
        {
        }
    }
}