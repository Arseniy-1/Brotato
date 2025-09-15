using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityID, AbilityConfig> _abilityById;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;

        public void LoadAll()
        {
            LoadAbilities();
            LoadEnchants();
        }

        public AbilityConfig GetAbilityConfig(AbilityID abilityID)
        {
            if (_abilityById.TryGetValue(abilityID, out AbilityConfig abilityConfig))
                return abilityConfig;
            
            throw new Exception($"Ability with ID {abilityID} not found");
        }
        
        public EnchantConfig GetEnchantConfig(EnchantTypeId typeId)
        {
            if (_enchantById.TryGetValue(typeId, out EnchantConfig enchantConfig))
                return enchantConfig;
            
            throw new Exception($"Ability with ID {typeId} not found");
        }


        public AbilityLevel GetAbilityLevel(AbilityID abilityID, int level)
        {
            AbilityConfig config = GetAbilityConfig(abilityID);

            if (level > config.Levels.Count)
                level = config.Levels.Count;
            
            return config.Levels[level - 1];
        }

        private void LoadEnchants()
        {
            _enchantById = Resources
                .LoadAll<EnchantConfig>("Configs/Enchants")
                .ToDictionary(x => x.TypeId, x => x);
        }

        private void LoadAbilities()
        {
            _abilityById = Resources
                .LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityID, x => x);
        }
    }
}