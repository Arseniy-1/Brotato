using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Armaments 
{
    public sealed class ArmamentFeature : Feature
    {
        public ArmamentFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkProcessedOnTargetLimitExceededSystem>());
            Add(systemFactory.Create<FollowProducerSystem>());
            Add(systemFactory.Create<FinalizeProcessedArmamentSystem>());
        }
    }
}