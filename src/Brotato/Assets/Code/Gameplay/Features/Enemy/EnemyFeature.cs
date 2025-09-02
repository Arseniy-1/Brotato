using Code.Gameplay.Features.Enemy.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemy
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeSpawnTimeSystem>());
            Add(systemFactory.Create<EnemySpawnSystem>());
            Add(systemFactory.Create<ChaseHeroSystem>());
            Add(systemFactory.Create<EnemyDeathSystem>());
            
            Add(systemFactory.Create<FinalizeEnemyDeathProcessingSystem>());
        }
    }
}