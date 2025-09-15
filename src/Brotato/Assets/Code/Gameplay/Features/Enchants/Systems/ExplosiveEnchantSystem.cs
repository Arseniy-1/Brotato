using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public class ExplosiveEnchantSystem : ReactiveSystem<GameEntity>
    {
        private readonly IArmamentsFactory _armamentsFactory;
        private readonly IGroup<GameEntity> _enchants;

        public ExplosiveEnchantSystem(GameContext gameContext, IArmamentsFactory armamentsFactory) : base(gameContext)
        {
            _armamentsFactory = armamentsFactory;
            _enchants = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnchantTypeId,
                    GameMatcher.ProducerId,
                    GameMatcher.ExplosiveEnchant));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.Reached)
                .Added());

        protected override bool Filter(GameEntity entity) => 
            entity.isArmament && entity.hasWorldPosition;

        protected override void Execute(List<GameEntity> armaments)
        {
            foreach (var enchant in _enchants)
            foreach (var armament in armaments)
            {
                _armamentsFactory.CreateExplosion(enchant.ProducerId, armament.WorldPosition);
            }
        }
    }
}