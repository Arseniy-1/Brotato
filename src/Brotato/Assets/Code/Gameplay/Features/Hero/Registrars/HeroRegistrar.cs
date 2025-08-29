using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : MonoBehaviour
    {
        private GameEntity _entity;

        public HeroAnimator HeroAnimator;
        public float Speed = 2;

        private void Awake()
        {
            _entity = CreateEntity
                .Empty()
                .AddWorldPosition(transform.position)
                .AddTransform(transform)
                .AddDirection(transform.forward)
                .AddSpeed(Speed)
                .AddSpriteRenderer(HeroAnimator.SpriteRenderer)
                .AddHeroAnimator(HeroAnimator)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true);
        }
    }
}