using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
    public class LevelUpWindow : BaseWindow
    {
        public Transform AbilityLayout;

        private IAbilityUpgradeService _abilityUpgradeService;
        private IAbilityUIFactory _abilityUIFactory;
        private IStaticDataService _staticData;
        private IWindowService _windowService;

        [Inject]
        private void Construct(
            IAbilityUIFactory abilityUIFactory,
            IAbilityUpgradeService abilityUpgradeService,
            IStaticDataService staticDataService,
            IWindowService windowService)
        {
            RootWindowId = WindowId.LevelUpWindow;

            _abilityUIFactory = abilityUIFactory;
            _abilityUpgradeService = abilityUpgradeService;
            _staticData = staticDataService;
            _windowService = windowService;
        }

        protected override void Initialize()
        {
            foreach (AbilityUpgradeOption upgradeOption in _abilityUpgradeService.GetUpgradeOptions())
            {
                AbilityLevel abilityLevel = _staticData.GetAbilityLevel(upgradeOption.Id, upgradeOption.Level);

                _abilityUIFactory
                    .CreateAbilityCard(AbilityLayout)
                    .Setup(upgradeOption.Id, abilityLevel, OnSelected);
            }
        }

        private void OnSelected(AbilityId id)
        {
            CreateEntity
                .Empty()
                .AddAbilityID(id)
                .With(x => x.isUpgradeRequest = true);
            
            _windowService.Close(RootWindowId);           
        }
    }
}