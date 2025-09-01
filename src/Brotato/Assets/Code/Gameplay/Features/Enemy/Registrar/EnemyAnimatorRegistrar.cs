using Code.Gameplay.Features.Enemy.Behaviours;
using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemy.Registrar
{
    public class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        public EnemyAnimator Enemy;
        
        public override void RegisterComponents()
        {
            Entity.AddEnemyAnimator(Enemy);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveEnemyAnimator();
        }
    }
}