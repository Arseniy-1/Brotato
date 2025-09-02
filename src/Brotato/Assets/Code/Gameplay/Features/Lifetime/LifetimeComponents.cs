using Entitas;

namespace Code.Gameplay.Features.Lifetime
{
    [Game] public class CurentHP : IComponent { public float Value; }
    [Game] public class MaxHP : IComponent { public float Value; } 
    [Game] public class Dead : IComponent { }
    [Game] public class ProcessingDeath : IComponent { }
}