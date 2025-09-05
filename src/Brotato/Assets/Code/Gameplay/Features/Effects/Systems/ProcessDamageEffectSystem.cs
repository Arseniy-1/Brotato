using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _effects;

        public ProcessDamageEffectSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _effects = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageEffect,
                    GameMatcher.EffectValue,
                    GameMatcher.TargetId));
        }
        
        public void Execute()
        {
            foreach (var effect in _effects)
            {
                GameEntity target = effect.Target();

                effect.isProcessed = true;
                
                if(target.isDead)
                    continue;
                
                target.ReplaceCurentHP(target.CurentHP - effect.EffectValue);
                
                if(target.hasDamageTakenAnimator)
                    target.DamageTakenAnimator.PlayDamageTaken();
            }
        }
    }
}