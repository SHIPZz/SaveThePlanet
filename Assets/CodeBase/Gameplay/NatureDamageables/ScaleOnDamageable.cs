using CodeBase.Animations;
using CodeBase.Gameplay.Recoverables;
using UnityEngine;

namespace CodeBase.Gameplay.NatureDamageables
{
    [RequireComponent(typeof(TransformScaleAnim))]
    [RequireComponent(typeof(NatureDamageable))]
    public class ScaleOnDamageable : MonoBehaviour, IRecoverableEvent
    {
        private NatureDamageable _natureDamageable;
        private TransformScaleAnim _transformScaleAnim;

        private void Awake()
        {
            _natureDamageable = GetComponent<NatureDamageable>();
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        private void OnEnable() => 
            _natureDamageable.Damaged += UnScale;

        private void OnDisable() => 
            _natureDamageable.Damaged -= UnScale;

        public void OnRecovered() => 
            ToScale();

        private void UnScale() => 
            _transformScaleAnim.UnScale();

        private void ToScale() => 
            _transformScaleAnim.ToScale();
    }
}