using CodeBase.Services;
using CodeBase.Services.WorldData;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace CodeBase.InfraStructure
{
    public class BootstrapState : IState, IEnter
    {
        private readonly IWorldDataService _worldDataService;
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IWorldDataService worldDataService,
            IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _worldDataService = worldDataService;
        }

        public async void Enter()
        {
            DOTween.KillAll();
            DOTween.Clear();
            DOTween.Init();
            
            await _worldDataService.Load();

            _gameStateMachine.ChangeState<LevelLoadState>();
        }
    }
}