using CodeBase.Services.UI;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.ButtonOpeners
{
    public abstract class ButtonOpenerBase : Button
    {
        protected WindowService WindowService;

        [Inject]
        private void Construct(WindowService windowService) =>
            WindowService = windowService;

        protected override void Awake() => 
            onClick.AddListener(Open);

        protected override void OnDisable() =>
            onClick.RemoveListener(Open);

        protected abstract void Open();
    }
}