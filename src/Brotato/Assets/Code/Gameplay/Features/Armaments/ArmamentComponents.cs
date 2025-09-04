using Entitas;

namespace Code.Gameplay.Features.Armaments
{
    public class ArmamentComponents
    {
        [Game] public class TargetLimit : IComponent { public int Value; }
        [Game] public class Armament : IComponent { }
    }
}