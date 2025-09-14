using Entitas;

namespace Code.Gameplay.Features.Abilities
{
        [Game] public class AbilityIDComponent : IComponent { public AbilityID Value; }
        [Game] public class ParentAbility : IComponent { public AbilityID Value; }
        [Game] public class PenetrationBoltAbility : IComponent { }
        [Game] public class OrbitalAbility : IComponent { }
}