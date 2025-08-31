using Code.Common.Systems;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Systems;

namespace Code.Common
{
    public class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SelfDestructTimerSystem>());
            Add(systemFactory.Create<CleanupGameDestructedSystem>());
            Add(systemFactory.Create<ViewDestructedSystem>());
        }
    }
}