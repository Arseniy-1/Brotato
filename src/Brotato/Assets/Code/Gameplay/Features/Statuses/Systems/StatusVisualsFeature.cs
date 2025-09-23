using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Statuses.Systems.StatusVisuals;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class StatusVisualsFeature : Feature
    {
        public StatusVisualsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyPoisonVisualSystem>());
            Add(systemFactory.Create<ApplyFreezeStatusSystem>());
            
            Add(systemFactory.Create<UnapplyPoisonVisualSystem>());
            Add(systemFactory.Create<UnapplyFreezeVisualSystem>());
            
            Add(systemFactory.Create<RemoveUnappliedEnchantFromHolder>());
        }
    }
}