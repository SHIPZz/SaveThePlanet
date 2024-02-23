using Agava.YandexGames;
using CodeBase.InfraStructure;
using CodeBase.Services.Input;
using CodeBase.Services.Providers.Asset;
using CodeBase.Services.Save;
using CodeBase.Services.SaveSystem;
using CodeBase.Services.WorldData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using YG;
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
            BindSaveOnApplicationFocusChanged();
            Container.BindInterfacesTo<BootstrapInstaller>()
                .FromInstance(this);
        }

        private void BindSaveOnApplicationFocusChanged()
        {
            Container.BindInterfacesAndSelfTo<SaveOnApplicationFocusChanged>().AsSingle();
        }

        private void BindAssetProvider()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<InputService>().AsSingle();
        }

        public async void Initialize()
        {
#if UNITY_WEBGL
            while (!YandexGame.SDKEnabled)
            {
                await UniTask.Yield();
            }
#endif

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