using CodeBase.EntryPointSystem;
using CodeBase.Services.Factories;
using CodeBase.Services.Providers.CameraProviders;
using CodeBase.Services.Providers.LocationProviders;
using CodeBase.Services.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LocationProvider _locationProvider;
        
        public override void InstallBindings()
        {
            BindProviders();
            BindGameFactory();
            BindStaticDataServices();
            InitEntryPoint();
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
            Container.Bind<UIFactory>().AsSingle();
        }

        private void BindProviders()
        {
            Container.BindInstance(_locationProvider);
            Container.Bind<CameraProvider>().AsSingle();
            Container.Bind<PlayerProvider>().AsSingle();
        }
    }
}