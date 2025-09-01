using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class ApplyDamageOnTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _damageDealers;

        public ApplyDamageOnTargetsSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _damageDealers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Damage,
                    GameMatcher.TargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity damageDealer in _damageDealers)
            {
                foreach (int targetID in damageDealer.TargetsBuffer)
                {
                    GameEntity target = _gameContext.GetEntityWithId(targetID);

                    if (target.hasCurentHP)
                    {
                        target.ReplaceCurentHP(target.CurentHP - damageDealer.Damage);

                        if (target.hasDamageTakenAnimator)
                            target.DamageTakenAnimator.PlayDamageTaken();
                    }
                }
            }
        }
    }
}