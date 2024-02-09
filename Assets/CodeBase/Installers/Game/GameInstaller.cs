using CodeBase.EntryPointSystem;
using CodeBase.Services.Factories;
using CodeBase.Services.Providers.LocationProviders;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LocationProvider _locationProvider;
        
        public override void InstallBindings()
        {
            BindLocationProvider();
            BindGameFactory();
            InitEntryPoint();
        }

        private void InitEntryPoint()
        {
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle();
        }

        private void BindGameFactory()
        {
            Container.Bind<GameFactory>().AsSingle();
        }

        private void BindLocationProvider()
        {
            Container.BindInstance(_locationProvider);
        }
    }
}