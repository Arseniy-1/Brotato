using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsNoLimitSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(64);

        public CastForTargetsNoLimitSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.ReadyToCollectTargets,
                    GameMatcher.WorldPosition,
                    GameMatcher.LayerMask,
                    GameMatcher.Radius)
                .NoneOf(GameMatcher.TargetLimit));

        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {   
                entity.TargetsBuffer.AddRange(TargetsInRadius(entity));

                if (entity.isCollectingTargetsContinuously == false)
                    entity.isReadyToCollectTargets = false;
            }
        }

        private IEnumerable<int> TargetsInRadius(GameEntity entity)
        {
            return _physicsService
                .CircleCast(entity.WorldPosition, entity.Radius, entity.LayerMask)
                .Select(x => x.Id);
        }
    }
}