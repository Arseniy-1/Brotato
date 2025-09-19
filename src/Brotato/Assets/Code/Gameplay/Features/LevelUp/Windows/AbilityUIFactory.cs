using Code.Gameplay.Features.LevelUp.Behaviour;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
    public class AbilityUIFactory : IAbilityUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private const string AbilityCardPrefabPath = "UI/Abilities/AbilityCard";

        public AbilityUIFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public AbilityCard CreateAbilityCard(Transform parent) =>
            _instantiator.InstantiatePrefabForComponent<AbilityCard>(
                _assetProvider.LoadAsset<AbilityCard>(AbilityCardPrefabPath),
                parent);
    }
}