using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsWithLimitSystem : IExecuteSystem, ITearDownSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(64);
        private GameEntity[] _targetCastBuffer = new GameEntity[128];

        public CastForTargetsWithLimitSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReadyToCollectTargets,
                    GameMatcher.Radius,
                    GameMatcher.TargetsBuffer,
                    GameMatcher.ProcessedTargets,
                    GameMatcher.TargetLimit,
                    GameMatcher.WorldPosition,
                    GameMatcher.LayerMask));    
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                for (int i = 0; i < Math.Min(TargetCountInRadius(entity), entity.TargetLimit); i++)
                {
                    int targetId  = _targetCastBuffer[i].Id;
                    
                    if (AlreadyProcessed(entity, targetId) == false)
                    {
                        entity.TargetsBuffer.Add(targetId);
                        entity.ProcessedTargets.Add(targetId);
                    }
                }

                if (entity.isCollectingTargetsContinuously == false)
                    entity.isReadyToCollectTargets = false;
            }
        }

        private bool AlreadyProcessed(GameEntity entity, int targetId)
        {
            return entity.ProcessedTargets.Contains(targetId);
        }

        private int TargetCountInRadius(GameEntity entity)
        {
            return _physicsService.CircleCastNonAlloc(entity.WorldPosition, entity.Radius, entity.LayerMask, _targetCastBuffer);
        }

        public void TearDown()
        {
            _targetCastBuffer = null;
        }
    }
}