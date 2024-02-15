using CodeBase.InfraStructure;
using CodeBase.Services.Input;
using CodeBase.Services.Providers.Asset;
using CodeBase.Services.SaveSystem;
using CodeBase.Services.WorldData;
using UnityEngine;
using Zenject;
using CoroutineRunner = CodeBase.InfraStructure.CoroutineRunner;
using IInitializable = Zenject.IInitializable;

namespace CodeBase.Installers.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindSaveSystem();
            BindLoadingCurtain();
            BindGameStateMachine();
            BindStateFactory();
            BindWorldDataService();
            BindInputService();
            BindAssetProvider();
            Container.BindInterfacesTo<BootstrapInstaller>()
                .FromInstance(this);
        }

        private void BindAssetProvider()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<InputService>().AsSingle();
        }


        public void Initialize()
        {
            var gameStateMachine = Container.Resolve<IGameStateMachine>();
            gameStateMachine.ChangeState<BootstrapState>();
        }
        
        private void BindWorldDataService() =>
            Container
                .Bind<IWorldDataService>()
                .To<WorldDataService>()
                .AsSingle();

        private void BindStateFactory() =>
            Container
                .Bind<IStateFactory>()
                .To<StateFactory>()
                .AsSingle();

        private void BindGameStateMachine() =>
            Container.Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();

        private void BindLoadingCurtain() =>
            Container.Bind<ILoadingCurtain>()
                .FromInstance(_loadingCurtain);

        private void BindSaveSystem() =>
            Container.Bind<ISaveSystem>().To<PlayerPrefsSaveSystem>()
                .AsSingle();

        private void BindCoroutineRunner() =>
            Container.Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(GetComponent<CoroutineRunner>());
    }
}