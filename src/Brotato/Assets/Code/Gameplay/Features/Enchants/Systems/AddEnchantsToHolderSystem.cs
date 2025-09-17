using Entitas;

namespace Code.Gameplay.Features.Enchants
{
    public class AddEnchantsToHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enchantHolder;
        private readonly IGroup<GameEntity> _enchants;

        public AddEnchantsToHolderSystem(GameContext gameContext)
        {
            _enchantHolder = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.EnchantHolder));

            _enchants = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnchantTypeId,
                    GameMatcher.TimeLeft));
        }

        public void Execute()
        {
            foreach (GameEntity holder in _enchantHolder)
            foreach (GameEntity enchant in _enchants)
                holder.EnchantHolder.AddEnchant(enchant.EnchantTypeId);
        }
    }
}