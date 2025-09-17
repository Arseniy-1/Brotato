using Code.Gameplay.Features.LevelUp.Behaviour;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.LevelUp.Registrars
{
    public class ExperienceMeterRegistrar : EntityComponentRegistrar
    {
        public ExperienceMeter ExperienceMeter;
        
        public override void RegisterComponents() => 
            Entity.AddExperienceMeter(ExperienceMeter);

        public override void UnregisterComponents()
        {
            if(Entity.hasExperienceMeter)
                Entity.RemoveExperienceMeter();  
        }
    }
}