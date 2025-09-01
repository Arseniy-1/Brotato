using Code.Gameplay.Features.Enemy.Registrar;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemy
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ChaseHeroSystem>());
        }
    }
}