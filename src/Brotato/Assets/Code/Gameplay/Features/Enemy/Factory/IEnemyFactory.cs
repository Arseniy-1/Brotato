using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Factory
{
    public interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemyTypeId enemyTypeId, Vector3 at);
    }
}