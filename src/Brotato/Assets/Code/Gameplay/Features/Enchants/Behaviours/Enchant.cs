using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class Enchant : MonoBehaviour
    {
        public Image Icon;
        public EnchantTypeId EnchantType;

        public void Set(EnchantConfig config)
        {
            Icon.sprite = config.Icon;
            EnchantType = config.EnchantId;
        }
    }
}