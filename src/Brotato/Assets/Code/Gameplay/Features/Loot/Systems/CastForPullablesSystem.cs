using Code.Common.Extensions;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CastForPullablesSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _looters;
        private readonly int _layerMask = CollisionLayer.Clicker.AsMask();
        private GameEntity[] _hitBuffer = new GameEntity[128];

        public CastForPullablesSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _looters = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.PickupRadius));
        }

        public void Execute()
        {
            foreach (GameEntity looter in _looters)
            {
                for (int i = 0; i < LootInRadius(looter); i++)
                {
                    if (_hitBuffer[i].isPullalbe)
                    {
                        _hitBuffer[i].isPullalbe = false;
                        _hitBuffer[i].isPulling = true;
                    }
                }

                ClearBuffer();
            }
        }

        private void ClearBuffer()
        {
            for (int i = 0; i < _hitBuffer.Length; i++)
                _hitBuffer[i] = null;
        }

        private int LootInRadius(GameEntity looter)
        {
            return _physicsService.CircleCastNonAlloc(
                looter.WorldPosition,
                looter.PickupRadius,
                _layerMask,
                _hitBuffer);
        }
    }
}