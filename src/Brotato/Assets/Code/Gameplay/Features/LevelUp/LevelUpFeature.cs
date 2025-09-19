using Code.Gameplay.Features.LevelUp.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.LevelUp
{
    public class LevelUpFeature : Feature
    {
        public LevelUpFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<OpenLevelUpWindowSystem>());
            Add(systemFactory.Create<StopTimeOnLevelUpSystem>());
            
            Add(systemFactory.Create<UpgradeAbilityOnRequestSystem>());
            
            Add(systemFactory.Create<StartTimeOnLevelUpSystem>());
            
            Add(systemFactory.Create<FinalizeProcessedLevelUpsSystem>());
        }
    }
}