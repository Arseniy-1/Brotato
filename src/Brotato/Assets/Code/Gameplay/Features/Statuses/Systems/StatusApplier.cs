using Code.Gameplay.Features.Statuses.Factory;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class StatusApplier
    {
        private readonly IStatusFactory _statusFactory;

        public StatusApplier(IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
        }

        public GameEntity ApplyStatus(StatusSetup setup, int producedId, int targetId)
        {
            
            
            return _statusFactory.CreateStatus(setup, producedId, targetId);
        }
    }
}