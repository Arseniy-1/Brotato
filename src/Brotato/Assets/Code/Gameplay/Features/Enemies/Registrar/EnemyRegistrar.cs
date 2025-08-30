using Code.Common.Entity;
using Code.Common.Extensions;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrar
{
    public class EnemyRegistrar : MonoBehaviour
    {
        private GameEntity _entity;

        public float Speed = 1;

        private void Awake()
        {
            _entity = CreateEntity
                .Empty()
                .AddWorldPosition(transform.position)
                .AddTransform(transform)
                .AddDirection(transform.forward)
                .AddSpeed(Speed)
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true);
        }
    }
}