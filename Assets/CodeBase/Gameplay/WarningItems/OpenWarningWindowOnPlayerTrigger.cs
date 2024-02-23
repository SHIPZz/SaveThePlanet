using System;
using CodeBase.Services.TriggerObserves;
using CodeBase.Services.UI;
using CodeBase.Services.Warning;
using CodeBase.UI.Windows.Warning;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.WarningItems
{
    public class OpenWarningWindowOnPlayerTrigger : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;

        private WindowService _windowService;
        private WarningItem _warningItem;
        private WarningDataService _warningDataService;

        [Inject]
        private void Construct(WindowService windowService, WarningDataService warningDataService)
        {
            _warningDataService = warningDataService;
            _windowService = windowService;
        }

        private void Awake() => 
            _warningItem = GetComponent<WarningItem>();

        private void Start()
        {
            if (_warningDataService.HasShown(_warningItem.WarningItemType))
            {
                Destroy(this);
            }
        }

        private void OnEnable() => 
            TriggerObserver.TriggerEntered += OnPlayerEntered;

        private void OnDisable() => 
            TriggerObserver.TriggerEntered -= OnPlayerEntered;

        private void OnPlayerEntered(Collider player)
        {
            if (_warningDataService.HasShown(_warningItem.WarningItemType))
            {
                Destroy(this);
                return;
            }
            
            WarningWindow window = _windowService.Get<WarningWindow>();
            window.Init(_warningItem.WarningItemType);
            _windowService.OpenCurrentWindow();
            _warningDataService.SetShownWarning(_warningItem.WarningItemType, true);
        }
    }
}