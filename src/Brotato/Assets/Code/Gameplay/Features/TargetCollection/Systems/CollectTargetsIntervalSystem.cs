using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CollectTargetsIntervalSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;

        private IGroup<GameEntity> _entities;

        public CollectTargetsIntervalSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.CollectTargetsInterval,
                    GameMatcher.CollectTargetsTimer));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.CollectTargetsTimer > 0)
                {
                    entity.ReplaceCollectTargetsTimer(entity.CollectTargetsTimer - _timeService.DeltaTime);
                }
                else
                {
                    entity.isReadyToCollectTargets = true;
                    entity.ReplaceCollectTargetsTimer(entity.CollectTargetsInterval);
                }
            }
        }
    }

    public class MarkReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(128);

        public MarkReachedSystem(GameContext gameContext, ITimeService timeService)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.TargetsBuffer)
                .NoneOf(GameMatcher.Reached));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (entity.TargetsBuffer.Count > 0)
                    entity.isReached = true;
            }
        }
    }
}