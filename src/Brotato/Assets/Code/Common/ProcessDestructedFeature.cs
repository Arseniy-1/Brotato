using Code.Common.Systems;
using Code.Gameplay.Common.Time;

namespace Code.Common
{
    public class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature(GameContext gameContext, ITimeService timeService)
        {
            Add(new SelfDestructTimerSystem(gameContext, timeService));
            Add(new CleanupGameDestructedSystem(gameContext));
            Add(new ViewDestructedSystem(gameContext));
        }
    }
}