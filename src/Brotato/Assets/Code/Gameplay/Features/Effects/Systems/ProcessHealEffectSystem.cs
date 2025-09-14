using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessHealEffectSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _effects;

        public ProcessHealEffectSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _effects = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HealEffect,
                    GameMatcher.EffectValue,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            {
                GameEntity target = effect.Target();

                effect.isProcessed = true;

                if (target.isDead)
                    continue;

                if (target.hasMaxHP && target.hasCurentHP)
                {
                    float newValue = Mathf.Min(target.CurentHP + effect.EffectValue);
                    target.ReplaceCurentHP(newValue);
                }
            }
        }
    }
}