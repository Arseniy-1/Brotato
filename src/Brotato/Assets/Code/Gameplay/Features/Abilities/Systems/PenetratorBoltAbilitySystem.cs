using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class PenetratorBoltAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentsFactory _armamentsFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;
        
        private readonly List<GameEntity> _buffer = new(4);

        public PenetratorBoltAbilitySystem(
            GameContext gameContext, 
            IStaticDataService staticDataService,
            IArmamentsFactory armamentsFactory, 
            IAbilityUpgradeService abilityUpgradeService)
        {
            _staticDataService = staticDataService;
            _armamentsFactory = armamentsFactory;
            _abilityUpgradeService = abilityUpgradeService;

            _abilities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PenetrationBoltAbility,
                    GameMatcher.CooldownUp));

            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition));

            _enemies = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            foreach (GameEntity hero in _heroes)
            {
                if (_enemies.count == 0)
                    continue;

                int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.PenetratorBolt);
                
                _armamentsFactory
                    .CreatePenetratorBolt(level, hero.WorldPosition)
                    .AddProducerId(hero.Id)
                    .ReplaceDirection((FirstAvailableTarget().WorldPosition - hero.WorldPosition).normalized)
                    .With(x => x.isMoving = true);

                ability.PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.PenetratorBolt, level).Cooldown);
            }
        }

        private GameEntity FirstAvailableTarget()
        {
            return _enemies.AsEnumerable().First();
        }
    }
}