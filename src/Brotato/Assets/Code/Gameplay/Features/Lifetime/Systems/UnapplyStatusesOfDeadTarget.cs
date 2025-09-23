using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class UnapplyStatusesOfDeadTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _dead;

        public UnapplyStatusesOfDeadTarget(GameContext gameContext)
        {
            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.TargetId));
            
            _dead = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Dead));

        }

        public void Execute()
        {
            foreach (GameEntity deadEntity in _dead)
            foreach (GameEntity status in _statuses)
            {
                if(status.TargetId == deadEntity.Id)
                    status.isUnapplied = true;
            }
        }
    }
}