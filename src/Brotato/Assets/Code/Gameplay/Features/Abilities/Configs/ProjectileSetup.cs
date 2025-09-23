using System;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    public class ProjectileSetup
    {
        public int ProjectileCount = 1;
        
        public float Speed;
        public int Pierce;
        public float ContactRadius;
        public float Lifetime;
        
        public float OrbitRadius;
    }
}