using CodeBase.Gameplay.PlayerSystem;
using CodeBase.Services.Input;
using Zenject;

namespace CodeBase.Installers.GO
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
            Container.Bind<PlayerHandContainer>().AsSingle();
        }
    }
}