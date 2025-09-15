using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class RotAuraAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentsFactory _armamentsFactory;
        
        private readonly List<GameEntity> _buffer = new(4);

        public RotAuraAbilitySystem(GameContext gameContext, IArmamentsFactory armamentsFactory)
        {
            _armamentsFactory = armamentsFactory;
            _abilities = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.RotAuraAbility)
                .NoneOf(GameMatcher.Active));
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Hero));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            foreach (GameEntity hero in _heroes)
            {
                _armamentsFactory.CreateEffectAura(AbilityID.RotAura, hero.Id, 1);
                
                ability.isActive = true;
            }
        }
    }
}