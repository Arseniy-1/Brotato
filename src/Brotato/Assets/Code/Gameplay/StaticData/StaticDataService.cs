using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.LevelUp;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityId, AbilityConfig> _abilityById;
        private Dictionary<LootTypeId, LootConfig> _lootById;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;
        private Dictionary<WindowId, GameObject> _windowPrefabsById;
        private LevelUpConfig _levelUpConfig;

        public void LoadAll()
        {
            LoadAbilities();
            LoadEnchants();
            LoadLoot();
            LoadLevelUpRules();
            LoadWindows();
        }

        public AbilityConfig GetAbilityConfig(AbilityId abilityID)
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

        public AbilityLevel GetAbilityLevel(AbilityId abilityID, int level)
        {
            AbilityConfig config = GetAbilityConfig(abilityID);

            if (level > config.Levels.Count)
                level = config.Levels.Count;
            
            return config.Levels[level - 1];
        }

        public GameObject GetWindowPrefab(WindowId id) =>
            _windowPrefabsById.TryGetValue(id, out GameObject prefab)
                ? prefab
                : throw new Exception($"Prefab config for window {id} was not found");

        public int MaxLevel() => 
            _levelUpConfig.MaxLevel;

        public float ExperienceForLevel(int level) => 
            _levelUpConfig.ExperienceForLevelUp[level];

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

        private void LoadWindows()
        {
                _windowPrefabsById = Resources
                .Load<WindowsConfig>("Configs/Windows/WindowsConfig")
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }

        private void LoadLevelUpRules()
        {
            _levelUpConfig = Resources.Load<LevelUpConfig>("Configs/LevelUp/LevelUpConfig");
        }
    }
}