using Code.Gameplay.Common.Time;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class ECSRunner : MonoBehaviour
    {
        private GameContext _gameContext;
        private ITimeService _timeService;
        
        private BattleFeature _battleFeature;

        private void Construct(GameContext gameContext, ITimeService timeService)
        {
            _gameContext = gameContext;
            _timeService = timeService;
        }

        private void Start()
        {
            _battleFeature = new BattleFeature(_gameContext, _timeService);
        }

        private void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _battleFeature.TearDown();
        }
    }
}