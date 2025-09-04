﻿using Code.Common;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.DamageApplication;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Lifetime.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<BindViewFeature>());
            
            Add(systemFactory.Create<HeroFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<DeathFeature>());
            
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<AbilityFeature>());
            
            Add(systemFactory.Create<CollectTargetFeature>());
            Add(systemFactory.Create<DamageApplicationFeature>());
            
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}