
using Code.Gameplay;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class ECSRunner : MonoBehaviour
    {
        private GameContext _gameContext;
        private ITimeService _timeService;
        
        private BattleFeature _battleFeature;
        private IInputService _inputService;
        private ICameraProvider _cameraProvider;

        // [Inject]
        // private void Construct(GameContext gameContext, ITimeService timeService, IInputService inputService)
        // {
        //     _gameContext = gameContext;
        //     _timeService = timeService;
        //     _inputService = inputService;
        // }

        private void Awake()
        {
            _gameContext = Contexts.sharedInstance.game;
            _timeService = new UnityTimeService();
            _inputService = new StandaloneInputService();
            _cameraProvider = new CameraProvider();
            _cameraProvider.SetMainCamera(Camera.main);
        }

        private void Start()
        {
            _battleFeature = new BattleFeature(_gameContext, _timeService, _inputService, _cameraProvider);
            _battleFeature.Initialize();
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