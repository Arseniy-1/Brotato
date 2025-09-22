using System.Threading;
using Code.Gameplay.Common;
using Code.Gameplay.Common.Constants;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
    public class HeroAnimator : MonoBehaviour, IDamageTakenAnimator
    {
        private static readonly int OverlayIntensityProperty = Shader.PropertyToID("_OverlayIntensity");

        private readonly int _movingHash = Animator.StringToHash(AnimationConstants.Run.ToString());
        private readonly int _idleHash = Animator.StringToHash(AnimationConstants.Idle.ToString());
        private readonly int _attackHash = Animator.StringToHash(AnimationConstants.Attack.ToString());
        private readonly int _damageTakenHash = Animator.StringToHash(AnimationConstants.DamageTaken.ToString());
        private readonly int _diedHash = Animator.StringToHash(AnimationConstants.Died.ToString());

        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private Material Material => _spriteRenderer.material;

        public void PlayMove() => _animator.Play(_movingHash);
        public void PlayIdle() => _animator.Play(_idleHash);

        public void PlayAttack() => _animator.SetTrigger(_attackHash);

        public void PlayDied() => 
            _animator.Play(_idleHash);

        public void PlayDamageTaken()
        {
            if (DOTween.IsTweening(Material))
                return;
      
            Material.DOFloat(0.5f, OverlayIntensityProperty, 0.15f)
                .OnComplete(() =>
                {
                    if (_spriteRenderer)
                        Material.DOFloat(0, OverlayIntensityProperty, 0.15f);
                });
        }

        private async UniTask PlayAndWait(int animationHash, CancellationToken token)
        {
            _animator.Play(animationHash);
            await UniTask.Yield();

            if (token.IsCancellationRequested || _animator == null)
                return;

            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            int attempts = 0;

            while (token.IsCancellationRequested == false && stateInfo.shortNameHash != animationHash && attempts < 60)
            {
                await UniTask.Yield();

                if (token.IsCancellationRequested || _animator == null)
                    return;

                stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
                attempts++;
            }

            while (token.IsCancellationRequested == false && stateInfo.normalizedTime < 1f &&
                   !_animator.IsInTransition(0))
            {
                await UniTask.Yield();

                if (token.IsCancellationRequested || _animator == null)
                    return;

                stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            }
        }
    }
}