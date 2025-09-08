using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
    public class ApplyStatusesOnTargetsSystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _entities;

        public ApplyStatusesOnTargetsSystem(GameContext gameContext, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
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
                _statusFactory.CreateStatus(setup, ProducerID(entity), targetID);
            }
        }

        private int ProducerID(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}