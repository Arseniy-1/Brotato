using Code.Common.Entity;
using Code.Gameplay.Common;
using Entitas;

namespace Code.Gameplay.Features.Enemy.Systems
{
    public class InitializeSpawnTimeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddSpawnTimer(GameplayConstants.EnemySpawnTimer);
        }
    }
}