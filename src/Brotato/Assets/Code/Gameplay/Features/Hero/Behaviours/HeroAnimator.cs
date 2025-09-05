using Code.Gameplay.Common;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
    public class HeroAnimator : MonoBehaviour, IDamageTakenAnimator
    {
        private static readonly int OverlayIntensityProperty = Shader.PropertyToID("_OverlayIntensity");

        private readonly int _movingHash = Animator.StringToHash("Run");
        private readonly int _idleHash = Animator.StringToHash("Idle");
        private readonly int _attackHash = Animator.StringToHash("attack");
        private readonly int _damageTakenHash = Animator.StringToHash("DamageTaken");
        private readonly int _diedHash = Animator.StringToHash("died");

        public Animator Animator;
        public SpriteRenderer SpriteRenderer;
        private Material Material => SpriteRenderer.material;

        public void PlayMove() => Animator.Play(_movingHash);
        public void PlayIdle() => Animator.Play(_idleHash);

        public void PlayAttack() => Animator.SetTrigger(_attackHash);

        public void PlayDied() => Animator.SetTrigger(_diedHash);

        public void PlayDamageTaken()
        {
            Debug.Log("123");
            Animator.Play(_damageTakenHash);
        }

        public void ResetAll()
        {
            Animator.ResetTrigger(_attackHash);
            Animator.ResetTrigger(_diedHash);
        }
    }
}