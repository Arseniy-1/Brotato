using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{ 
    [CreateAssetMenu(menuName = "Configs/AbilityConfig", fileName = "AbilityConfig", order = 51)]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityId AbilityID;
        public List<AbilityLevel> Levels;
    }
}