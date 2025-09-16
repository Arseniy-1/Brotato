using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityID, AbilityConfig> _abilityById;
        private Dictionary<LootTypeId, LootConfig> _lootById;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;

        public void LoadAll()
        {
            LoadAbilities();
            LoadEnchants();
            LoadLoot(); 
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
            
            throw new Exception($"Enchant with ID {typeId} not found");
        }

        public LootConfig GetLootConfig(LootTypeId lootTypeId)
        {
            if (_lootById.TryGetValue(lootTypeId, out LootConfig lootConfig))
                return lootConfig;
            
            throw new Exception($"Loot with ID {lootTypeId} not found");
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
        
        private void LoadLoot()
        {
            _lootById = Resources
                .LoadAll<LootConfig>("Configs/Loot")
                .ToDictionary(x => x.LootTypeId, x => x);
        }

        private void LoadAbilities()
        {
            _abilityById = Resources
                .LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityID, x => x);
        }
    }
}