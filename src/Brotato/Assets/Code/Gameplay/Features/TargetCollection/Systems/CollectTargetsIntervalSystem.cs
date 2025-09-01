using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

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
}