using Code.Gameplay.Features.Abilities;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IArmamentsFactory
    {
        GameEntity CreatePenetratorBolt(int level, Vector3 at);
        GameEntity CreateOrbital(int level, Vector3 at, float phase);
        GameEntity CreateEffectAura(AbilityID parentAbilityID, int producerId, int level);
        GameEntity CreateExplosion(int producerId, Vector3 at);
    }
}