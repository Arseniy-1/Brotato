using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IArmamentsFactory
    {
        GameEntity CreatePenetratorBolt(int level, Vector3 at);
        GameEntity CreateOrbital(int level, Vector3 at, float phase);
    }
}