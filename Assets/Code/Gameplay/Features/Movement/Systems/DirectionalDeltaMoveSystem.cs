using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class DirectionalDeltaMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly ITimeService _timeService;

        public DirectionalDeltaMoveSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;
            _movers = gameContext.GetGroup(GameMatcher.
                AllOf(
                    GameMatcher.CodeGameplayFeaturesMovementSpeed
                ));
        }

        public void Execute()
        {
            
        }
    }
}