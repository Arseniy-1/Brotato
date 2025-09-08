using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class PeriodicDamageStatusSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IEffectsFactory _effectsFactory;
        private readonly IGroup<GameEntity> _statuses;

        public PeriodicDamageStatusSystem(GameContext gameContext, ITimeService time, IEffectsFactory effectsFactory)
        {
            _time = time;
            _effectsFactory = effectsFactory;
            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Period,
                    GameMatcher.TimeSinceLastTick,
                    GameMatcher.EffectValue,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            {
                if (status.TimeSinceLastTick >= 0)
                {
                    status.ReplaceTimeSinceLastTick(status.TimeSinceLastTick - _time.DeltaTime);
                }
                else
                {
                    status.ReplaceTimeSinceLastTick(status.Period);
                    
                    _effectsFactory.CreateEffect(new EffectSetup { EffectTypeId = EffectTypeId.Damage, Value = status.EffectValue },
                        status.ProducerId,
                        status.TargetId);
                }
            }
        }
    }
}