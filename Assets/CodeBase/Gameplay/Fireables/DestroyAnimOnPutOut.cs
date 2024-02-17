using CodeBase.Anims;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Fireables
{
    [RequireComponent(typeof(TransformScaleAnim))]
    [RequireComponent(typeof(Fireable))]
    public class DestroyAnimOnPutOut : MonoBehaviour
    {
        public float DestroyDelay = 3f;

        private Fireable _fireable;
        private TransformScaleAnim _transformScaleAnim;

        private void Awake()
        {
            _fireable = GetComponent<Fireable>();
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        private void OnEnable() => 
            _fireable.OnPutOut += PlayAnim;

        private void OnDisable() => 
        _fireable.OnPutOut -= PlayAnim;

        private void PlayAnim()
        {
            DOTween.Sequence()
                .AppendInterval(DestroyDelay)
                .OnComplete(() => _transformScaleAnim.UnScale(() => Destroy(gameObject)));
        }
    }
}