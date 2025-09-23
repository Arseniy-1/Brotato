using System.Collections.Generic;
using Code.Gameplay.Features.Enchants.UIFactories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class EnchantHolder : MonoBehaviour
    {
        public Transform EnchantLayout;
        private IEnchantUIFactory _uiFactory;
        private readonly List<Enchant> _enchants = new();

        [Inject]
        private void Construct(IEnchantUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void AddEnchant(EnchantTypeId enchantType)
        {
            if (EnchantAlreadyHeld(enchantType))
                return;

            Enchant enchant = _uiFactory.CreateEnchant(EnchantLayout, enchantType);
            _enchants.Add(enchant);
        }

        public void RemoveEnchant(EnchantTypeId enchantType)
        {
            Enchant enchant = _enchants.Find(enchant => enchant.EnchantType == enchantType);

            if (enchant != null)
            {
                _enchants.Remove(enchant);
                Destroy(enchant.gameObject);
            }
        }

        private bool EnchantAlreadyHeld(EnchantTypeId enchantType) => 
            _enchants.Find(x => x.EnchantType == enchantType) != null;
    }
}