using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class RotAuraAbilitySystem : IExecuteSystem
    {
        private readonly IArmamentsFactory _armamentsFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _abilities;

        private readonly List<GameEntity> _buffer = new(4);

        public RotAuraAbilitySystem(
            GameContext gameContext,
            IArmamentsFactory armamentsFactory, 
            IAbilityUpgradeService abilityUpgradeService)
        {
            _armamentsFactory = armamentsFactory;
            _abilityUpgradeService = abilityUpgradeService;
            
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
                int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.RotAura);
                
                _armamentsFactory.CreateEffectAura(AbilityId.RotAura, hero.Id, level);
                
                ability.isActive = true;
            }
        }
    }
}