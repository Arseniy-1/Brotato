using Code.Gameplay.Common;
using Code.Gameplay.Common.Constants;
using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Behaviours
{
    public class EnemyAnimator : MonoBehaviour, IDamageTakenAnimator
    {
        private static readonly int OverlayIntensityProperty = Shader.PropertyToID("_OverlayIntensity");

        private readonly int _movingHash = Animator.StringToHash(AnimationConstants.Run.ToString());
        private readonly int _idleHash = Animator.StringToHash(AnimationConstants.Idle.ToString());
        private readonly int _attackHash = Animator.StringToHash(AnimationConstants.Attack.ToString());
        private readonly int _damageTakenHash = Animator.StringToHash(AnimationConstants.DamageTaken.ToString());
        private readonly int _diedHash = Animator.StringToHash(AnimationConstants.Died.ToString());

        public Animator Animator;
        public SpriteRenderer SpriteRenderer;
        private Material Material => SpriteRenderer.material;

        public void PlayMove() => Animator.Play(_movingHash);
        public void PlayIdle() => Animator.Play(_idleHash);

        public void PlayAttack() => Animator.SetTrigger(_attackHash);

        public void PlayDied()
        {
            Animator.Play(_diedHash);
        }

        public void PlayDamageTaken()
        {
            if (DOTween.IsTweening(Material))
                return;
      
            Material.DOFloat(0.4f, OverlayIntensityProperty, 0.15f)
                .OnComplete(() =>
                {
                    if (SpriteRenderer)
                        Material.DOFloat(0, OverlayIntensityProperty, 0.15f);
                });
        }

        private string GetMaterialProperties()
        {
            var properties = new System.Text.StringBuilder();
            for (int i = 0; i < Material.shader.GetPropertyCount(); i++)
            {
                properties.AppendLine($"{Material.shader.GetPropertyName(i)} ({Material.shader.GetPropertyType(i)})");
            }
            return properties.ToString();
        }

        public void ResetAll()
        {
            Animator.ResetTrigger(_attackHash);
            Animator.ResetTrigger(_diedHash);
        }
    }
}