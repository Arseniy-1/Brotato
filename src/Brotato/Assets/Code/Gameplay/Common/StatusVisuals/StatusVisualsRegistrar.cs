using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Common.StatusVisuals
{
  public class StatusVisualsRegistrar : EntityComponentRegistrar
  {
    public Common.StatusVisuals.StatusVisuals StatusVisuals;
    
    public override void RegisterComponents()
    {
      Entity.AddStatusVisuals(StatusVisuals);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasStatusVisuals)
        Entity.RemoveStatusVisuals();
    }
  }
}