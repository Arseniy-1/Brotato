using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class CompositionRoot : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindCommonServices();
            BindAssetManagementServices();
            BindCameraProvider();
            BindContexts();

            BindSystemFactory();
        }

        private void BindSystemFactory()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }

        private void BindCommonServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
        }
        
        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }
        
        private void BindCameraProvider()
        {
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
        }
        
        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
            Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
        }
    }
}