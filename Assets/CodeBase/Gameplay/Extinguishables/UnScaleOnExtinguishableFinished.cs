using CodeBase.Anims;
using UnityEngine;

namespace CodeBase.Gameplay.Extinguishables
{
    public class UnScaleOnExtinguishableFinished : MonoBehaviour
    {
        private TransformScaleAnim _transformScaleAnim;
        private Extinguishable _extinguishable;

        private void Awake()
        {
            _extinguishable = GetComponent<Extinguishable>();
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        private void OnEnable()
        {
            _extinguishable.Finished += OnPutOut;
        }

        private void OnDisable()
        {
            _extinguishable.Finished -= OnPutOut;
        }

        private void OnPutOut()
        {
            _transformScaleAnim.UnScale();
        }
    }
}