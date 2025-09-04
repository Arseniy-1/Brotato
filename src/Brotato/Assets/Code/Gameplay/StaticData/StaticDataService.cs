using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityID, AbilityConfig> _abilityById;

        public void LoadAll()
        {
            LoadAbilities();
        }

        public AbilityConfig GetAbilityConfig(AbilityID abilityID)
        {
            if (_abilityById.TryGetValue(abilityID, out AbilityConfig abilityConfig))
                return abilityConfig;
            
            throw new Exception($"Ability with ID {abilityID} not found");
        }

        public AbilityLevel GetAbilityLevel(AbilityID abilityID, int level)
        {
            AbilityConfig config = GetAbilityConfig(abilityID);

            if (level > config.Levels.Count)
                level = config.Levels.Count;
            
            return config.Levels[level - 1];
        }

        private void LoadAbilities()
        {
            _abilityById = Resources
                .LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityID, x => x);
        }
    }
}