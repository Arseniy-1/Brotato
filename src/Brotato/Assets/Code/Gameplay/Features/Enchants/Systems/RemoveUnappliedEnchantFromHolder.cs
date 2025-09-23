using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enchants
{
    public class RemoveUnappliedEnchantFromHolder : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _enchantHolder;

        public RemoveUnappliedEnchantFromHolder(GameContext gameContext) : base(gameContext)
        {
            _enchantHolder = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.EnchantHolder));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher
                .AllOf(
                    GameMatcher.EnchantTypeId,
                    GameMatcher.Unapplied)
                .Added());

        protected override bool Filter(GameEntity entity) => 
            true;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            foreach (GameEntity holder in _enchantHolder)
                holder.EnchantHolder.RemoveEnchant(entity.EnchantTypeId);
        }
    }
}