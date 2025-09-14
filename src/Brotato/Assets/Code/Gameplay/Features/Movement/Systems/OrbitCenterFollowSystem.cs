using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class OrbitCenterFollowSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _orbitCenters;
        private readonly IGroup<GameEntity> _targets;
        private readonly ITimeService _time;

        public OrbitCenterFollowSystem(GameContext game)
        {
            _orbitCenters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.OrbitCenterPosition,
                    GameMatcher.OrbitCenterFollowTargetId));

            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity orbitCenter in _orbitCenters)
            foreach (GameEntity target in _targets)
            {
                if (orbitCenter.OrbitCenterFollowTargetId == target.Id)
                    orbitCenter.ReplaceOrbitCenterPosition(target.WorldPosition);
            }
        }
    }
}