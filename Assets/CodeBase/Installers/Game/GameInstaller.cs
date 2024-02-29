using CodeBase.EntryPointSystem;
using CodeBase.Gameplay.Terrain;
using CodeBase.Gameplay.Tutorial;
using CodeBase.Services.Camera;
using CodeBase.Services.Factories;
using CodeBase.Services.GarbageDeathableServices;
using CodeBase.Services.Pause;
using CodeBase.Services.Providers.CameraProviders;
using CodeBase.Services.Providers.GameProviders;
using CodeBase.Services.Providers.LocationProviders;
using CodeBase.Services.Providers.PlayerProviders;
using CodeBase.Services.Settings;
using CodeBase.Services.StaticData;
using CodeBase.Services.UI;
using CodeBase.Services.Warning;
using CodeBase.UI.Windows.Pause;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LocationProvider _locationProvider;
        [SerializeField] private GameProvider _gameProvider;
        
        public override void InstallBindings()
        {
            BindProviders();
            BindGameFactory();
            BindStaticDataServices();
            BindGarbageDeathableService();
            InitEntryPoint();
            BindTerrainLayerChanger();
            BindWindowService();
            BindUIService();
            BindSettingService();
            BindWarningDataService();
            BindPauseServices();
            BindCameraService();
            BindTutorialServices();
        }

        private void BindTutorialServices()
        {
            Container.Bind<TutorialRunner>().AsSingle();
            Container.BindInterfacesAndSelfTo<TutorialService>().AsSingle();
        }

        private void BindCameraService()
        {
            Container.Bind<CameraService>().AsSingle();
        }

        private void BindPauseServices()
        {
            Container.BindInterfacesAndSelfTo<PauseOnWindowOpened>().AsSingle();
            Container.Bind<IPauseService>().To<PauseService>().AsSingle();
        }

        private void BindWarningDataService()
        {
            Container.Bind<WarningDataService>().AsSingle();
        }

        private void BindSettingService()
        {
            Container.BindInterfacesAndSelfTo<SettingService>().AsSingle();
        }

        private void BindUIService()
        {
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle();
        }

        private void BindWindowService()
        {
            Container.Bind<WindowService>().AsSingle();
        }

        private void BindTerrainLayerChanger()
        {
            Container.Bind<TerrainLayerChanger>().AsSingle();
        }

        private void BindGarbageDeathableService()
        {
            Container.Bind<GarbageDeathableService>().AsSingle();
        }

        private void BindStaticDataServices()
        {
            Container.Bind<GameStaticDataService>().AsSingle();
            Container.Bind<UIStaticDataService>().AsSingle();
        }

        private void InitEntryPoint()
        {
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle();
        }

        private void BindGameFactory()
        {
            Container.Bind<GameFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();
        }

        private void BindProviders()
        {
            Container.BindInstance(_locationProvider);
            Container.BindInstance(_gameProvider);
            Container.Bind<CameraProvider>().AsSingle();
            Container.Bind<PlayerProvider>().AsSingle();
        }
    }
}