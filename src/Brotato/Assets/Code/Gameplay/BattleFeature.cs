using Code.Common;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input;
using Code.Gameplay.Input.Service;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<HeroFeature>());
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}