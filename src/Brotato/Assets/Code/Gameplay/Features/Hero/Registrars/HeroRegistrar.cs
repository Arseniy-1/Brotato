using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : EntityComponentRegistrar
    {
        public float Speed = 2;
        public float MaxHP = 100;

        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(transform.forward)
                .AddSpeed(Speed)
                .AddCurentHP(MaxHP)
                .AddMaxHP(MaxHP)
                .With(x => x.isHero = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isTurnedAlongDirection = true);
        }

        public override void UnregisterComponents()
        {
            
        }
    }
}