using CodeBase.UI.Effects;
using UnityEngine;

namespace CodeBase.UI.FrameMessage
{
    public class EffectOnMessage : MonoBehaviour
    {
        [SerializeField] private FrameMessageView _frameMessageView;
        [SerializeField] private EffectPlayer _effectPlayer;

        private void OnEnable()
        {
            _frameMessageView.Shown += _effectPlayer.PlayEffects;
        }

        private void OnDisable()
        {
            _frameMessageView.Shown -= _effectPlayer.PlayEffects;
        }
    }
}