using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemy.Registrar
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        public float Speed = 2;

        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(transform.forward)
                .AddSpeed(Speed)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true);
        }

        public override void UnregisterComponents()
        {
            throw new System.NotImplementedException();
        }
    }
    
    
}