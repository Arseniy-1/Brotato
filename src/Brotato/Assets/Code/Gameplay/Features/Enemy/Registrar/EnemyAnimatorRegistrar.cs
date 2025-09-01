using Code.Gameplay.Features.Enemy.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemy.Registrar
{
    public class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        public EnemyAnimator EnemyAnimator;

        public override void RegisterComponents()
        {
            Entity.AddEnemyAnimator(EnemyAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEnemyAnimator)
                Entity.RemoveEnemyAnimator();
        }
    }
}