using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Factory;
using Code.Gameplay.Features.Statuses.Systems;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
    public class ApplyStatusesOnTargetsSystem : IExecuteSystem
    {
        private readonly IStatusApplier _statusApplier;
        private readonly IGroup<GameEntity> _entities;

        public ApplyStatusesOnTargetsSystem(GameContext gameContext, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatusSetups,
                    GameMatcher.TargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetID in entity.TargetsBuffer)
            foreach (StatusSetup setup in entity.StatusSetups)
            {
                _statusApplier.ApplyStatus(setup, ProducerID(entity), targetID);
            }
        }

        private int ProducerID(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}