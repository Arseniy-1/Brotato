using Code.Gameplay.Features.LevelUp.Behaviour;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp.Windows
{
    public interface IAbilityUIFactory
    {
        AbilityCard CreateAbilityCard(Transform parent);
    }
}