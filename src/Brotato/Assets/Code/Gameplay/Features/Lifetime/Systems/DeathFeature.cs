using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkDeadSystem>());
            Add(systemFactory.Create<UnapplyStatusesOfDeadTarget>());
        }
    }
}