using CodeBase.Services.Input;
using Zenject;

namespace CodeBase.Installers.GO
{
    public class PlayerInstaller : MonoInstaller
    {
        [Inject]
        private void Construct(PlayerProvider playerProvider)
        {
            
        }
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
        }
    }
}