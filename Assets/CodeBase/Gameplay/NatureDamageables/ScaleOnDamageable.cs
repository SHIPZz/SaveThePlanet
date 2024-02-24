using CodeBase.Animations;
using CodeBase.Gameplay.Recoverables;
using UnityEngine;

namespace CodeBase.Gameplay.NatureDamageables
{
    [RequireComponent(typeof(TransformScaleAnim))]
    [RequireComponent(typeof(Damageable))]
    public class ScaleOnDamageable : MonoBehaviour, IRecoverableEvent
    {
        private Damageable _damageable;
        private TransformScaleAnim _transformScaleAnim;

        private void Awake()
        {
            _damageable = GetComponent<Damageable>();
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        private void OnEnable() => 
            _damageable.Damaged += UnScale;

        private void OnDisable() => 
            _damageable.Damaged -= UnScale;

        public void OnRecovered() => 
            ToScale();

        private void UnScale() => 
            _transformScaleAnim.UnScale();

        private void ToScale() => 
            _transformScaleAnim.ToScale();
    }
}