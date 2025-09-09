using System.Linq;
using Code.Common.EntityIndices;
using Code.Common.Extensions;
using Code.Gameplay.Features.Statuses.Factory;
using Code.Gameplay.Features.Statuses.Systems;

namespace Code.Gameplay.Features.Statuses.Applier
{
    public class StatusApplier : IStatusApplier
    {
        private readonly IStatusFactory _statusFactory;
        private readonly GameContext _gameContext;

        public StatusApplier(IStatusFactory statusFactory, GameContext gameContext)
        {
            _statusFactory = statusFactory;
            _gameContext = gameContext;
        }

        public GameEntity ApplyStatus(StatusSetup setup, int producedId, int targetId)
        {
            GameEntity status = _gameContext.TargetStatusesOfType(setup.StatusTypeId, targetId).FirstOrDefault();
            
            if(status != null)
                return status.ReplaceTimeLeft(setup.Duration);
            else
                return _statusFactory.CreateStatus(setup, producedId, targetId)
                    .With(x => x.isApplied = true);
        }
    }
}