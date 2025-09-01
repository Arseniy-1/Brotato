using Code.Gameplay.Features.Enemy.Behaviours;
using Code.Gameplay.Features.Hero.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Enemy
{
    [Game] public class Enemy : IComponent { }
    [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
}