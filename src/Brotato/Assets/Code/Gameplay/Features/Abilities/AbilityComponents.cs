using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Abilities
{
        [Game] public class AbilityIDComponent : IComponent { public AbilityId Value; }
        [Game] public class ParentAbility : IComponent { [EntityIndex] public AbilityId Value; }
        [Game] public class PenetrationBoltAbility : IComponent { }
        [Game] public class OrbitalAbility : IComponent { }
        [Game] public class RotAuraAbility : IComponent { }
        
        [Game] public class UpgradeRequest : IComponent { }
        [Game] public class RecreatedOnUpgrade : IComponent { }
}