using Code.Gameplay.Features.Loot.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Loot
{
    public class LootingFeature : Feature
    {
        public LootingFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CastForPullablesSystem>());
            
            Add(systemFactory.Create<PullTowardsHeroSystem>());
            Add(systemFactory.Create<CollectWhenNearSystem>());
            Add(systemFactory.Create<CollectExperienceSystem>());
            Add(systemFactory.Create<CollectEffectItemSystem>());
            Add(systemFactory.Create<CollectStatusItemSystem>());
             
            Add(systemFactory.Create<CleanupCollected>());
        }
    }
}